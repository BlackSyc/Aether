using Aether.Core.Combat.ScriptableObjects;
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
        private Spell activeSpell = null;

        [SerializeField]
        private List<Spell> library = new List<Spell>();
        #endregion

        #region Public Properties
        public event Action<Spell> OnActiveSpellChanged;

        public bool HasActiveSpell => ActiveSpell != null;

        public float CoolDownUntil { get; private set; }

        public bool IsOnCoolDown => Time.time < CoolDownUntil;

        public Spell ActiveSpell => activeSpell;
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
        public void Add(Spell spell, bool makeActive = true)
        {
            if (spell != null && !Contains(spell))
                library.Add(spell);

            if (makeActive)
            {
                MakeSpellActive(spell);
            }
        }

        // Tested in Editmode Tests
        public bool Contains(Spell spell)
        {
            return library.Contains(spell);
        }

        // Tested in Editmode Tests
        public void Remove(Spell spell)
        {
            library.Remove(spell);

            if (ActiveSpell.Equals(spell))
            {
                activeSpell = null;
                OnActiveSpellChanged?.Invoke(null);
            }
        }

        // Tested in Editmode Tests
        public bool TryCast(out SpellCast spellCast, Transform castParent, ISpellSystem caster, ICombatSystem target)
        {
            spellCast = null;

            if (ActiveSpell == null)
                return false;

            if (target == null)
                return false;

            if (IsOnCoolDown)
                return false;

            SpellCast newSpellCast = new SpellCast(ActiveSpell, castParent, caster, target);
            newSpellCast.CastComplete += SetCoolDown;
            spellCast = newSpellCast;
            return true;
        }
        #endregion

        #region Private Methods
        private void SetCoolDown(ISpellCast spellCast)
        {
            CoolDownUntil = Time.time + spellCast.Spell.CoolDown;
        }

        private void MakeSpellActive(Spell spell)
        {
            activeSpell = spell;
            OnActiveSpellChanged?.Invoke(ActiveSpell);
        }
        #endregion
    }
}
