using Aether.Core.Combat;
using Aether.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    [RequireComponent(typeof(IMovementSystem))]
    [RequireComponent(typeof(ICombatSystem))]
    internal class SpellSystem : MonoBehaviour, ISpellSystem
    {
        #region Private Fields
        [SerializeField]
        private Transform castOrigin = null;

        private SpellCast currentSpellCast;

        private IMovementSystem movementSystem;

        private readonly float globalCooldownSeconds = 1.5f;
        #endregion

        #region Public Properties
        public event Action<Core.Combat.ISpellLibrary> OnActiveSpellChanged;
        public event Action<Core.Combat.ISpellCast> OnSpellIsCast;

        public List<ISpellLibrary> SpellLibraries { get; private set; } = new List<ISpellLibrary>() {
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary(),
            new SpellLibrary()};

        public Transform CastOrigin => castOrigin;

        public bool IsCasting => currentSpellCast != null;
        public bool HasActiveSpells => SpellLibraries.Any(x => x.HasActiveSpell);

        public bool MovementInterrupt => movementSystem.IsMoving;

        public ICombatSystem CombatSystem { get; set; }

        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            CombatSystem = GetComponent<ICombatSystem>();
            movementSystem = GetComponent<IMovementSystem>();
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
            if (SpellLibraries[libraryIndex] == null)
            {
                SpellLibraries[libraryIndex] = new SpellLibrary();
                SpellLibraries[libraryIndex].OnActiveSpellChanged += _ => OnActiveSpellChanged?.Invoke(SpellLibraries[libraryIndex]);
            }

            SpellLibraries[libraryIndex].Add(spell, makeActive);
        }

        // Tested in Editmode Tests
        public void RemoveSpell(int libraryIndex, ISpell spell)
        {
            if (SpellLibraries.Count < libraryIndex - 1 || SpellLibraries[libraryIndex] == null)
                return;

            SpellLibraries[libraryIndex].Remove(spell);
        }

        // Tested in Editmode Tests
        public void CastSpell(int index, Target target)
        {
            ISpell requestedSpell = SpellLibraries[index].ActiveSpell;

            if (requestedSpell == null)
                return;

            if (IsCasting)
            {
                if (currentSpellCast.Spell == requestedSpell)
                {
                    currentSpellCast.UpdateTarget(requestedSpell.OnlyCastOnSelf ? new Target(CombatSystem) : target);
                    return;
                }

                if (!SpellLibraries[index].IsOnCoolDown)
                    CancelSpellCast();
                else
                    return;
            }

            if (!SpellLibraries[index].TryCast(out currentSpellCast, castOrigin, CombatSystem, target))
                return;

            if (currentSpellCast.Spell.OnGlobalCooldown)
                ApplyGlobalCooldown();

            currentSpellCast.CastCancelled += CancelCurrentCast;
            currentSpellCast.CastComplete += ClearCurrentCast;
            currentSpellCast.Start();
            OnSpellIsCast?.Invoke(currentSpellCast);
            return;
        }

        private void ApplyGlobalCooldown()
        {
            if (CombatSystem.Has(out Attributes attributes))
                SpellLibraries.ForEach(x => ((SpellLibrary)x).AddGlobalCooldown(globalCooldownSeconds / (attributes.Haste / 100)));
            else
                SpellLibraries.ForEach(x => ((SpellLibrary)x).AddGlobalCooldown(globalCooldownSeconds));
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
            SpellLibraries.ForEach(x => ((SpellLibrary)x).CancelGlobalCooldown());
        }
        #endregion

        #region Private Methods

        private void CancelCurrentCast(Core.Combat.ISpellCast spellCast)
        {
            SpellLibraries.ForEach(x => ((SpellLibrary)x).CancelGlobalCooldown());
            ClearCurrentCast(spellCast);
        }

        private void ClearCurrentCast(Core.Combat.ISpellCast spellCast)
        {
            currentSpellCast.CastCancelled -= ClearCurrentCast;
            currentSpellCast.CastComplete -= ClearCurrentCast;
            this.currentSpellCast = null;
        }

        public Core.Combat.ISpellLibrary GetSpellLibrary(int index)
        {
            Core.Combat.ISpellLibrary result = null;
            try
            {
                result = SpellLibraries[index];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.LogError(e);
            }
            return result;

        }

        public void RemoveAllSpells()
        {
            this.SpellLibraries.ForEach(x => x.RemoveAll());
        }
        #endregion
    }
}
