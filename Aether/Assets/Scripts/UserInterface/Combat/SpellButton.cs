using Aether.Core;
using System.Collections;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aether.UserInterface.Combat
{
    public class SpellButton : MonoBehaviour
    {
        [SerializeField] private int index;

        [SerializeField] private GameObject mainPanel;

        [SerializeField] private Image icon;

        [SerializeField] private TextMeshProUGUI cooldownText;

        [SerializeField] private Image globalCooldownOverlay;

        [SerializeField] private Image cooldownOverlay;

        [SerializeField] private Animator castBar;

        [SerializeField] private Animation keybindAnimation;

        private SpellState _spellState;
        private SpellCast _spellCast;

        private Coroutine _globalCooldownCoroutine;

        public void ShowTooltip()
        {
            TooltipManager.Instance.ShowTooltipFor(_spellState.Spell);
        }

        public void HideTooltip()
        {
            TooltipManager.Instance.HideTooltipFor(_spellState.Spell);
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
            playerSpellRack.OnGlobalCooldownStarted += StartGlobalCooldown;
            playerSpellRack.OnGlobalCooldownCancelled += CancelGlobalCooldown;

            _spellState = playerSpellRack.GetSpell(index);

            if (_spellState?.Spell == null)
                return;
            
            mainPanel.SetActive(true);
            icon.sprite = _spellState.Spell.Icon
                ? _spellState.Spell.Icon
                : icon.sprite;
        }

        private void CancelGlobalCooldown()
        {
            if(_globalCooldownCoroutine != null)
                StopCoroutine(_globalCooldownCoroutine);
            
            globalCooldownOverlay.fillAmount = 0;
        }

        private void StartGlobalCooldown(float globalCooldownRemaining)
        {
            if (!(_spellState?.Spell is null) && _spellState.Spell.OnGlobalCooldown)
            {
                _globalCooldownCoroutine = StartCoroutine(GlobalCooldownCoroutine(globalCooldownRemaining));
            }
        }

        private IEnumerator GlobalCooldownCoroutine(float globalCooldownRemaining)
        {
            var startingGlobalCooldown = globalCooldownRemaining;
            
            while (globalCooldownRemaining > 0)
            {
                globalCooldownOverlay.fillAmount = globalCooldownRemaining / startingGlobalCooldown;
                yield return null;
                globalCooldownRemaining -= Time.deltaTime;
            }

            globalCooldownOverlay.fillAmount = 0;
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
            icon.sprite = _spellState.Spell.Icon 
                ? _spellState.Spell.Icon 
                : icon.sprite;
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
            cooldownOverlay.enabled = true;
            while (Time.time < until)
            {
                cooldownText.text = ((int)(until - Time.time) + 1).ToString();
                yield return null;
            }

            if (_spellState != default)
                cooldownText.text = string.Empty;

            cooldownOverlay.enabled = false;
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
