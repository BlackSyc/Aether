using Aether.SpellSystem.ScriptableObjects;
using Aether.TargetSystem;
using System;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Aether.SpellSystem
{
    [RequireComponent(typeof(ITargetSystem))]
    public class SpellSystem : MonoBehaviour, ISpellSystem
    {
        #region Private Fields
        [SerializeField]
        private Transform castParent = null;

        [SerializeField]
        private SpellLibrary[] preFillOnAwake;

        private SpellCast currentSpellCast;

        private TargetSystem.ITargetSystem targetSystem;
        #endregion

        #region Public Properties
        public event Action<ISpellLibrary> OnActiveSpellChanged;
        public event Action<SpellCast> OnSpellIsCast;

        public ISpellLibrary[] SpellLibraries { get; private set; }
        public Transform CastParent => castParent;

        public bool IsCasting => currentSpellCast != null;
        public bool HasActiveSpells => SpellLibraries.Any(x => x.HasActiveSpell);

        #endregion

        #region MonoBehaviour
        private void Awake()
        {
            targetSystem = GetComponent<ITargetSystem>();
            SpellLibraries = new ISpellLibrary[preFillOnAwake.Length];
            Array.Copy(preFillOnAwake, 0, SpellLibraries, 0, preFillOnAwake.Length);
            SpellLibraries.ForEach(x => x.OnActiveSpellChanged += _ => OnActiveSpellChanged?.Invoke(x));
        }

        private void OnDestroy()
        {
            SpellLibraries.ForEach(x => x.OnActiveSpellChanged -= _ => OnActiveSpellChanged?.Invoke(x));
        }
        #endregion

        #region Public Methods
        // Tested in Editmode Tests
        public void AddSpell(int libraryIndex, Spell spell, bool makeActive = true)
        {
            EnsureSize(libraryIndex);

            if (SpellLibraries[libraryIndex] == null)
            {
                SpellLibraries[libraryIndex] = new SpellLibrary();
                SpellLibraries[libraryIndex].OnActiveSpellChanged += _ => OnActiveSpellChanged?.Invoke(SpellLibraries[libraryIndex]);
            }

            SpellLibraries[libraryIndex].Add(spell, makeActive);
        }

        // Tested in Editmode Tests
        public void RemoveSpell(int libraryIndex, Spell spell)
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

        // NOT YET: Tested in Playmode Tests
        public void CastSpell(int index)
        {
            Spell requestedSpell = SpellLibraries[index].ActiveSpell;

            if (IsCasting)
            {
                if (currentSpellCast.Spell == requestedSpell)
                {
                    currentSpellCast.UpdateTarget(targetSystem.GetCurrentTarget(requestedSpell.LayerMask));
                    return;
                }
                CancelSpellCast();
            }

            if (!SpellLibraries[index].TryCast(out currentSpellCast, castParent, this, targetSystem.GetCurrentTarget(requestedSpell.LayerMask)))
                return;

            currentSpellCast.CastCancelled += ClearCurrentCast;
            currentSpellCast.CastComplete += ClearCurrentCast;
            StartCoroutine(currentSpellCast.Start());
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
                SpellLibraries = new ISpellLibrary[1];
            }

            if (libraryIndex > SpellLibraries.Length - 1)
            {
                ISpellLibrary[] tempArray = new ISpellLibrary[libraryIndex + 1];
                Array.Copy(SpellLibraries, 0, tempArray, 0, SpellLibraries.Length);
                SpellLibraries = tempArray;
            }
        }

        private void ClearCurrentCast(SpellCast spellCast)
        {
            currentSpellCast.CastCancelled -= ClearCurrentCast;
            currentSpellCast.CastComplete -= ClearCurrentCast;
            this.currentSpellCast = null;
        }
        #endregion
    }
}
