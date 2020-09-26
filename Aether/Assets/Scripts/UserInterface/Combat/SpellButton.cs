using Aether.Core;
using System.Collections;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class SpellButton : MonoBehaviour
    {
        [SerializeField]
        private int index;

        [SerializeField]
        private GameObject mainPanel;

        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private Animator castBar;

        [SerializeField]
        private Animation keybindAnimation;

        [SerializeField]
        private SpellTooltip spellTooltip;

        private SpellState _spellState;

        private SpellCast _spellCast;

        public void ShowTooltip()
        {
            spellTooltip.Show(_spellState.Spell);
        }

        public void HideTooltip()
        {
            spellTooltip.Hide();
        }

        private void Start()
        {
            var playerSpellRack = Player.Instance.Has(out ICombatSystem combatSystem)
                ? combatSystem.Get<SpellRack>()
                : default;

            if (playerSpellRack == default)
                return;
        
            playerSpellRack.OnSpellAdded += OnSpellAdded;
            playerSpellRack.OnSpellRemoved += OnSpellRemoved;
            playerSpellRack.OnNewSpellCast += OnNewSpellCast;

            _spellState = playerSpellRack.GetSpell(index);

            if (_spellState?.Spell == null)
                return;
            
            mainPanel.SetActive(true);
            text.text = _spellState.Spell.SpellName;
        }

        private void OnSpellRemoved(SpellState spellState, int changedIndex)
        {
            if (changedIndex != index)
                return;
            
            _spellState = default;
            
            mainPanel.SetActive(false);
        }

        private void OnNewSpellCast(SpellCast newSpellCast)
        {
            if (_spellState?.Spell == default)
                return;
            
            if (newSpellCast?.Spell != _spellState.Spell)
                return;
            
            _spellCast = newSpellCast;
            
            keybindAnimation.Play();
            castBar.Play("Cast", -1, 0f);
            SubscribeToSpellCast(newSpellCast);
        }

        private void OnSpellAdded(SpellState spellState, int changedIndex)
        {
            if (changedIndex != index)
                return;

            _spellState = spellState;
        
            mainPanel.SetActive(true);
            text.text = _spellState.Spell.SpellName;
            //TODO: Change button icon like: icon.sprite = linkedSpellSlot.Spell.Icon;
        }
        
        private void UpdateCast(SpellCast spellCast)
        {
            castBar.Play("Cast", -1, spellCast.CurrentCastTime / _spellState.Spell.CastTime);
        }
        
        private void CancelCast(SpellCast spellCast)
        {
            castBar.SetTrigger("CastCancelled");
            UnSubscribeFromSpellCast(spellCast);
        }
        
        private void CompleteCast(SpellCast spellCast)
        {
            castBar.SetTrigger("CastComplete");
            StartCoroutine(CoolDown(_spellState.Spell.CoolDown + Time.time));
            UnSubscribeFromSpellCast(spellCast);
        }
        
        private void SubscribeToSpellCast(SpellCast spellCast)
        {
            spellCast.OnSpellCastProgress += UpdateCast;
            spellCast.OnSpellCancelled += CancelCast;
            spellCast.OnSpellCompleted += CompleteCast;
        }
        
        private void UnSubscribeFromSpellCast(SpellCast spellCast)
        {
            spellCast.OnSpellCancelled -= CancelCast;
            spellCast.OnSpellCompleted -= CompleteCast;
        }
        
        private IEnumerator CoolDown(float until)
        {
            while (Time.time < until)
            {
                text.text = ((int)(until - Time.time) + 1).ToString();
                yield return null;
            }

            if (_spellState != default)
                text.text = _spellState.Spell.SpellName;
        }
        
        private void OnDestroy()
        {
            var playerSpellRack = Player.Instance.Has(out ICombatSystem combatSystem)
                ? combatSystem.Get<SpellRack>()
                : default;

            if (playerSpellRack == default)
                return;

            playerSpellRack.OnNewSpellCast -= OnNewSpellCast;
            playerSpellRack.OnSpellAdded -= OnSpellAdded;
            playerSpellRack.OnSpellRemoved -= OnSpellRemoved;
        }
    }
}
