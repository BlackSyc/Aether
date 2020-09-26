using Aether.Core;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
    public class PlayerTargetIndicator : MonoBehaviour
    {
        private SpellCast _currentSpellCast;

        private ICombatSystem _combatSystem;

        [SerializeField]
        private Image image;

        public void SetCombatSystem(ICombatSystem combatSystem)
        {
            _combatSystem = combatSystem;
        }
        
        private void Awake()
        {
            if (Player.Instance.Has(out ICombatSystem combatSystem) 
                && Player.Instance.Has(out CastingSystem castingSystem))
            {
                castingSystem.OnNewSpellCast += OnPlayerSpellCast;
            }
        }

        private void OnPlayerSpellCast(SpellCast spellCast)
        {
            if (spellCast.Spell.CastTime < 0.01f)
                return;

            _currentSpellCast = spellCast;
            spellCast.OnSpellCancelled += ClearCurrentSpellCast;
            spellCast.OnSpellCompleted += ClearCurrentSpellCast;
        }

        private void ClearCurrentSpellCast(SpellCast spellCast)
        {
            if (spellCast == _currentSpellCast)
            {
                _currentSpellCast.OnSpellCancelled -= ClearCurrentSpellCast;
                _currentSpellCast.OnSpellCompleted -= ClearCurrentSpellCast;
            }

            _currentSpellCast = null;
            image.enabled = false;

        }

        // Update is called once per frame
        void Update()
        {
            if (_currentSpellCast == null)
                return;

            if (_currentSpellCast.Target.IsCombatTarget)
                image.enabled = _currentSpellCast.Target.CombatSystem == _combatSystem;
        }

        private void OnDestroy()
        {
            if (Player.Instance.Has(out ICombatSystem combatSystem) 
                && Player.Instance.Has(out CastingSystem castingSystem))
            {
                castingSystem.OnNewSpellCast += OnPlayerSpellCast;
            }

            if (_currentSpellCast == null)
                return;

            _currentSpellCast.OnSpellCancelled -= ClearCurrentSpellCast;
            _currentSpellCast.OnSpellCompleted -= ClearCurrentSpellCast;
            _currentSpellCast = null;
        }
    }
}
