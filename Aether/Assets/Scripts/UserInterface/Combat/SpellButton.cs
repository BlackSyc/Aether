using Aether.Core;
using Aether.Core.Combat;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class SpellButton : MonoBehaviour
    {
        private ISpellLibrary spellLibrary;

        [SerializeField]
        private int spellLibraryIndex;

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

        public void ShowTooltip()
        {
            spellTooltip.Show(spellLibrary.ActiveSpell);
        }

        public void HideTooltip()
        {
            spellTooltip.Hide();
        }

        private void Start()
        {
            var playerSpellSystem = Player.Instance.Get<ICombatSystem>().Get<ISpellSystem>();

            spellLibrary = playerSpellSystem.GetSpellLibrary(spellLibraryIndex);

            if (spellLibrary == null)
                return;

            if (spellLibrary.HasActiveSpell)
            {
                mainPanel.SetActive(true);
                text.text = spellLibrary.ActiveSpell.Name;
            }

            spellLibrary.OnActiveSpellChanged += ChangeSpell;
            playerSpellSystem.OnSpellIsCast += StartSpellCast;
        }

        private void ChangeSpell(ISpell spell)
        {
            if (spell == null)
            {
                mainPanel.SetActive(false);
                return;
            }

            mainPanel.SetActive(true);
            text.text = spell.Name;
            //TODO: Change button icon like: icon.sprite = linkedSpellSlot.Spell.Icon;
        }

        private void StartSpellCast(ISpellCast spellCast)
        {
            if (spellCast == null || spellCast.Spell != spellLibrary.ActiveSpell)
                return;

            keybindAnimation.Play();
            castBar.Play("Cast", -1, 0f);
            SubscribeToSpellCast(spellCast);
        }

        private void UpdateCast(float progress)
        {
            castBar.Play("Cast", -1, progress);
        }

        private void CancelCast(ISpellCast spellCast)
        {
            castBar.SetTrigger("CastCancelled");
            UnSubscribeFromSpellCast(spellCast);
        }

        private void CompleteCast(ISpellCast spellCast)
        {
            castBar.SetTrigger("CastComplete");
            StartCoroutine(CoolDown(spellCast.Spell.CoolDown + Time.time));
            UnSubscribeFromSpellCast(spellCast);
        }

        private void SubscribeToSpellCast(ISpellCast spellCast)
        {
            spellCast.CastProgress += UpdateCast;
            spellCast.CastCancelled += CancelCast;
            spellCast.CastComplete += CompleteCast;
        }

        private void UnSubscribeFromSpellCast(ISpellCast spellCast)
        {
            spellCast.CastCancelled -= CancelCast;
            spellCast.CastComplete -= CompleteCast;
        }

        private IEnumerator CoolDown(float until)
        {
            while (Time.time < until)
            {
                text.text = ((int)(until - Time.time) + 1).ToString();
                yield return null;
            }

            if (spellLibrary.HasActiveSpell)
                text.text = spellLibrary.ActiveSpell.Name;
        }

        private void OnDestroy()
        {
            if (spellLibrary != null)
                spellLibrary.OnActiveSpellChanged -= ChangeSpell;

            Player.Instance.Get<ICombatSystem>().Get<ISpellSystem>().OnSpellIsCast -= StartSpellCast;
        }
    }
}
