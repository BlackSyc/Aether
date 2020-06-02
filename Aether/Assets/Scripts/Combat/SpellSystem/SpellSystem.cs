using Aether.Core.Combat;
using Aether.Core.Extensions;
using Aether.Movement;
using System;
using System.Linq;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    [RequireComponent(typeof(TargetSystem.ITargetSystem))]
    [RequireComponent(typeof(IMovementSystem))]
    [RequireComponent(typeof(ICombatSystem))]
    internal class SpellSystem : MonoBehaviour, ISpellSystem
    {
        #region Private Fields
        [SerializeField]
        private Transform castOrigin = null;

        [SerializeField]
        private SpellLibrary[] spellLibraries;

        private SpellCast currentSpellCast;

        private IMovementSystem movementSystem;
        #endregion

        #region Public Properties
        public event Action<Core.Combat.ISpellLibrary> OnActiveSpellChanged;
        public event Action<Core.Combat.ISpellCast> OnSpellIsCast;

        public ISpellLibrary[] SpellLibraries => spellLibraries;

        public Transform CastOrigin => castOrigin;

        public bool IsCasting => currentSpellCast != null;
        public bool HasActiveSpells => SpellLibraries.Any(x => x.HasActiveSpell);

        public bool MovementInterrupt => movementSystem.IsMoving;

        public ICombatSystem CombatSystem { get; set; }

        public TargetSystem.ITargetSystem TargetSystem { get; private set; }

        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            TargetSystem = GetComponent<TargetSystem.ITargetSystem>();
            CombatSystem = GetComponent<ICombatSystem>();
            movementSystem = GetComponent<IMovementSystem>();

            SpellLibraries.ForEach(x => x.OnActiveSpellChanged += _ => OnActiveSpellChanged?.Invoke(x));
        }

        private void OnDestroy()
        {
            SpellLibraries.ForEach(x => x.OnActiveSpellChanged -= _ => OnActiveSpellChanged?.Invoke(x));
        }

        private void Update()
        {
            if (currentSpellCast == null)
                return;

            currentSpellCast.Update();
        }
        #endregion

        #region Public Methods
        // Tested in Editmode Tests
        public void AddSpell(int libraryIndex, ISpell spell, bool makeActive = true)
        {
            EnsureSize(libraryIndex);

            if (spellLibraries[libraryIndex] == null)
            {
                spellLibraries[libraryIndex] = new SpellLibrary();
                spellLibraries[libraryIndex].OnActiveSpellChanged += _ => OnActiveSpellChanged?.Invoke(spellLibraries[libraryIndex]);
            }

            spellLibraries[libraryIndex].Add(spell, makeActive);
        }

        // Tested in Editmode Tests
        public void RemoveSpell(int libraryIndex, ISpell spell)
        {
            if (SpellLibraries.Length < libraryIndex - 1 || SpellLibraries[libraryIndex] == null)
                return;

            SpellLibraries[libraryIndex].Remove(spell);
        }

        // Tested in Editmode Tests
        public LayerMask GetCombinedLayerMask()
        {
            LayerMask layerMask = new LayerMask();

            if (SpellLibraries != null) 
            { 
                SpellLibraries
                    .Where(x => x.HasActiveSpell)
                    .Select(x => x.ActiveSpell.LayerMask)
                    .ForEach(x => layerMask |= x);
            }

            return layerMask;
        }

        // Tested in Editmode Tests
        public void CastSpell(int index)
        {
            ISpell requestedSpell = SpellLibraries[index].ActiveSpell;

            if (requestedSpell == null)
                return;

            if (IsCasting)
            {
                if (currentSpellCast.Spell == requestedSpell)
                {
                    currentSpellCast.UpdateTarget(requestedSpell.OnlyCastOnSelf ? CombatSystem : TargetSystem.GetCurrentTarget(requestedSpell.LayerMask));
                    return;
                }

                if(!SpellLibraries[index].IsOnCoolDown)
                    CancelSpellCast();
                else
                    return;
            }

            if (!SpellLibraries[index].TryCast(out currentSpellCast, castOrigin, CombatSystem, requestedSpell.OnlyCastOnSelf ? CombatSystem : TargetSystem.GetCurrentTarget(requestedSpell.LayerMask)))
                return;

            currentSpellCast.CastCancelled += ClearCurrentCast;
            currentSpellCast.CastComplete += ClearCurrentCast;
            currentSpellCast.Start();
            OnSpellIsCast?.Invoke(currentSpellCast);
            return;
        }

        // NOT YET: Tested in Playmode Tests
        public void CancelSpellCast()
        {
            if (IsCasting)
                currentSpellCast.Cancel();
        }

        // NOT YET: Tested in Playmode Tests
        public void InterruptSpellCast()
        {

        }
        #endregion

        #region Private Methods
        private void EnsureSize(int libraryIndex)
        {
            if(SpellLibraries == null)
            {
                spellLibraries = new SpellLibrary[1];
            }

            if (libraryIndex > SpellLibraries.Length - 1)
            {
                SpellLibrary[] tempArray = new SpellLibrary[libraryIndex + 1];
                Array.Copy(spellLibraries, 0, tempArray, 0, spellLibraries.Length);
                spellLibraries = tempArray;
            }
        }

        private void ClearCurrentCast(Core.Combat.ISpellCast spellCast)
        {
            currentSpellCast.CastCancelled -= ClearCurrentCast;
            currentSpellCast.CastComplete -= ClearCurrentCast;
            this.currentSpellCast = null;
        }

        public Core.Combat.ISpellLibrary GetSpellLibrary(int index)
        {
            return SpellLibraries[index];
        }
        #endregion
    }
}
