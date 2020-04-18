using Aether.Spells.ScriptableObjects;
using System;
using System.Linq;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Aether.Spells
{
    [RequireComponent(typeof(TargetManager))]
    public class SpellSystem : MonoBehaviour, ISpellSystem
    {
        #region Private Fields
        [SerializeField]
        private Transform castParent = null;

        [SerializeField]
        private SpellLibrary[] preFillOnAwake;

        private SpellCast currentSpellCast;

        private bool castOnSelf = false;

        private TargetManager targetManager;
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
            targetManager = GetComponent<TargetManager>();
            SpellLibraries = new ISpellLibrary[preFillOnAwake.Length];
            Array.Copy(preFillOnAwake, 0, SpellLibraries, 0, preFillOnAwake.Length);
            SpellLibraries.ForEach(x => x.OnActiveSpellChanged += _ => OnActiveSpellChanged?.Invoke(x));
        }

        private void OnDestroy()
        {
            SpellLibraries.ForEach(x => x.OnActiveSpellChanged -= _ => OnActiveSpellChanged?.Invoke(x));
        }
        #endregion

        #region Input Methods
        public void ToggleCastOnSelf(CallbackContext context)
        {
            castOnSelf = !context.canceled;
        }

        public void CastSpell1(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(0);
        }

        public void CastSpell2(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(1);
        }

        public void CastSpell3(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(2);
        }

        public void CastSpell4(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(3);
        }

        public void CastSpell5(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(4);
        }

        public void CastSpell6(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(5);
        }

        public void CastSpell7(CallbackContext context)
        {
            if (!context.performed)
                return;

            CastSpell(6);
        }

        public void CancelCast(CallbackContext context)
        {
            if (!context.performed)
                return;

            currentSpellCast?.Cancel();
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
            if (currentSpellCast != null)
            {
                if (currentSpellCast.Spell == SpellLibraries[index].ActiveSpell)
                {
                    if (castOnSelf && !currentSpellCast.OnSelf)
                    {
                        Debug.Log("Cast was on target, but will now be on self!");
                        currentSpellCast.OnSelf = true;
                        targetManager.UnlockTarget();
                    }
                    if (!castOnSelf && currentSpellCast.OnSelf)
                    {
                        Debug.Log("Cast was on self, but will now be on target!");
                        currentSpellCast.OnSelf = false;
                        UpdateTargetLock(currentSpellCast.Spell.LayerMask);
                    }

                    return;
                }
                currentSpellCast.Cancel();
            }

            if (!SpellLibraries[index].TryCast(out currentSpellCast, castParent, this, targetManager, castOnSelf))
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

        private void UpdateTargetLock(LayerMask layerMask)
        {
            if (targetManager.GetCurrentTarget().HasTargetTransform && layerMask.Contains(targetManager.GetCurrentTarget().TargetTransform.gameObject))
            {
                if (targetManager.HasLockedTarget)
                    targetManager.UnlockTarget();

                targetManager.LockCurrentTarget();
            }
        }
        #endregion
    }
}
