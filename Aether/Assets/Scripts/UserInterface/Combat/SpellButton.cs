using Aether.Core;
using System.Collections;
using Syc.Combat;
using Syc.Combat.SpellSystem;
using Syc.Combat.SpellSystem.ScriptableObjects;
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

        private SpellBehaviour _spellBehaviour;

        public void ShowTooltip()
        {
            spellTooltip.Show(_spellBehaviour);
        }

        public void HideTooltip()
        {
            spellTooltip.Hide();
        }

        // private void Start()
        // {
        //     var playerSpellSystem = Player.Instance.Get<ICombatSystem>().Get<SpellRack>();
        //
        //     playerSpellSystem.OnSpellAdded += PlayerSpellSystemOnOnSpellAdded;
        //     playerSpellSystem.OnSpellRemoved += PlayerSpellSystemOnOnSpellRemoved;
        //     
        //     _spellRack = playerSpellSystem.GetSpellLibrary(spellLibraryIndex);
        //
        //     if (_spellRack == null)
        //         return;
        //
        //     if (_spellRack.HasActiveSpell)
        //     {
        //         mainPanel.SetActive(true);
        //         text.text = _spellRack.ActiveSpell.Name;
        //     }
        //
        //     _spellRack.OnActiveSpellChanged += ChangeSpell;
        //     playerSpellSystem.OnSpellIsCast += StartSpellCast;
        // }
        //
        // private void PlayerSpellSystemOnOnSpellRemoved(Spell removedSpell, int index)
        // {
        //     if (index != this.index)
        //         return;
        //
        //     _spellBehaviour = default;
        // }
        //
        // private void PlayerSpellSystemOnOnSpellAdded(Spell newSpell, int index)
        // {
        //     if (index != this.index)
        //         return;
        //
        //     _spellBehaviour = newSpell.SpellBehaviour;
        // }
        //
        // private void ChangeSpell(ISpell spell)
        // {
        //     if (spell == null)
        //     {
        //         mainPanel.SetActive(false);
        //         return;
        //     }
        //
        //     mainPanel.SetActive(true);
        //     text.text = spell.Name;
        //     //TODO: Change button icon like: icon.sprite = linkedSpellSlot.Spell.Icon;
        // }
        //
        // private void StartSpellCast(ISpellCast spellCast)
        // {
        //     if (spellCast == null || spellCast.Spell != _spellRack.ActiveSpell)
        //         return;
        //
        //     keybindAnimation.Play();
        //     castBar.Play("Cast", -1, 0f);
        //     SubscribeToSpellCast(spellCast);
        // }
        //
        // private void UpdateCast(float progress)
        // {
        //     castBar.Play("Cast", -1, progress);
        // }
        //
        // private void CancelCast(ISpellCast spellCast)
        // {
        //     castBar.SetTrigger("CastCancelled");
        //     UnSubscribeFromSpellCast(spellCast);
        // }
        //
        // private void CompleteCast(ISpellCast spellCast)
        // {
        //     castBar.SetTrigger("CastComplete");
        //     StartCoroutine(CoolDown(spellCast.Spell.CoolDown + Time.time));
        //     UnSubscribeFromSpellCast(spellCast);
        // }
        //
        // private void SubscribeToSpellCast(ISpellCast spellCast)
        // {
        //     spellCast.CastProgress += UpdateCast;
        //     spellCast.CastCancelled += CancelCast;
        //     spellCast.CastComplete += CompleteCast;
        // }
        //
        // private void UnSubscribeFromSpellCast(ISpellCast spellCast)
        // {
        //     spellCast.CastCancelled -= CancelCast;
        //     spellCast.CastComplete -= CompleteCast;
        // }
        //
        // private IEnumerator CoolDown(float until)
        // {
        //     while (Time.time < until)
        //     {
        //         text.text = ((int)(until - Time.time) + 1).ToString();
        //         yield return null;
        //     }
        //
        //     if (_spellRack.HasActiveSpell)
        //         text.text = _spellRack.ActiveSpell.Name;
        // }
        //
        // private void OnDestroy()
        // {
        //     if (_spellRack != null)
        //         _spellRack.OnActiveSpellChanged -= ChangeSpell;
        //
        //     Player.Instance.Get<ICombatSystem>().Get<ISpellSystem>().OnSpellIsCast -= StartSpellCast;
        // }
    }
}
