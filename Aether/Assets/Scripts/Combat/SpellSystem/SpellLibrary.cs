using Aether.Core.Combat;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aether.Combat.SpellSystem
{
    [Serializable]
    internal class SpellLibrary : ISpellLibrary
    {

        #region Private Fields
        [SerializeField]
        private ISpell activeSpell = null;

        [SerializeField]
        private List<ISpell> library = new List<ISpell>();
        #endregion

        #region Public Properties
        public event Action<ISpell> OnActiveSpellChanged;

        public bool HasActiveSpell => ActiveSpell != null;

        public float GlobalCooldownUntil { get; private set; }

        public float CoolDownUntil { get; private set; }

        public bool IsOnCoolDown => Time.time < CoolDownUntil;

        public ISpell ActiveSpell => activeSpell;

        public bool IsOnGlobalCoolDown => Time.time < GlobalCooldownUntil;
        #endregion

        #region Constructors
        public SpellLibrary()
        {

        }

        public SpellLibrary(float initialCooldown)
        {
            CoolDownUntil = Time.time + initialCooldown;
        }
        #endregion

        #region Public Methods
        // Tested in Editmode Tests
        public void Add(ISpell spell, bool makeActive = true)
        {
            if (spell != null && !Contains(spell))
                library.Add(spell);

            if (makeActive)
            {
                MakeSpellActive(spell);
            }
        }

        // Tested in Editmode Tests
        public bool Contains(ISpell spell)
        {
            return library.Contains(spell);
        }

        // Tested in Editmode Tests
        public void Remove(ISpell spell)
        {
            library.Remove(spell);

            if (ActiveSpell.Equals(spell))
            {
                activeSpell = null;
                OnActiveSpellChanged?.Invoke(null);
            }
        }

        // Tested in Editmode Tests
        public bool TryCast(out SpellCast spellCast, Transform castOrigin, ICombatSystem caster, ICombatSystem target)
        {
            spellCast = null;

            if (ActiveSpell == null)
                return false;

            if (target == null)
                return false;

            if (IsOnCoolDown)
                return false;

            if (IsOnGlobalCoolDown)
                return false;

            SpellCast newSpellCast = new SpellCast(ActiveSpell, castOrigin, caster, target);
            newSpellCast.CastComplete += SetCoolDown;
            spellCast = newSpellCast;
            return true;
        }


        public void RemoveAll()
        {
            activeSpell = null;
            OnActiveSpellChanged?.Invoke(null);
            library.Clear();
        }

        public void AddGlobalCooldown(float seconds)
        {
            if (ActiveSpell != null && ActiveSpell.OnGlobalCooldown)
                GlobalCooldownUntil = Time.time + seconds;
        }

        public void CancelGlobalCooldown()
        {
            GlobalCooldownUntil = Time.time;
        }
        #endregion

        #region Private Methods
        private void SetCoolDown(Core.Combat.ISpellCast spellCast)
        {
            CoolDownUntil = Time.time + spellCast.Spell.CoolDown;
        }

        private void MakeSpellActive(ISpell spell)
        {
            activeSpell = spell;
            OnActiveSpellChanged?.Invoke(ActiveSpell);
        }
        #endregion
    }
}
