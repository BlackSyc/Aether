using Aether.Core.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Castbar : MonoBehaviour
{
    [SerializeField]
    private Image castbarImage;

    [SerializeField]
    private TextMeshProUGUI castbarText;

    private ISpellCast currentSpellCast;

    private ISpellSystem spellSystem;

    public void SetSpellSystem(ISpellSystem spellSystem)
    {
        this.spellSystem = spellSystem;
        this.spellSystem.OnSpellIsCast += ShowSpellCast;
    }

    private void ShowSpellCast(ISpellCast newSpellCast)
    {
        currentSpellCast = newSpellCast;
        ShowCastBar();
    }

    private void ShowCastBar()
    {
        castbarText.text = currentSpellCast.Spell.Name;
        castbarImage.fillAmount = 0;
        currentSpellCast.CastProgress += x => castbarImage.fillAmount = x;

        castbarImage.enabled = true;
        castbarText.enabled = true;

        currentSpellCast.CastCancelled += _ => HideCastBar();
        currentSpellCast.CastComplete += _ => HideCastBar();
        currentSpellCast.CastInterrupted += _ => HideCastBar();
    }

    private void HideCastBar()
    {
        currentSpellCast.CastProgress -= x => castbarImage.fillAmount = x;
        currentSpellCast.CastCancelled -= _ => HideCastBar();
        currentSpellCast.CastComplete -= _ => HideCastBar();
        currentSpellCast.CastInterrupted -= _ => HideCastBar();

        currentSpellCast = null;
        castbarText.enabled = false;
        castbarImage.enabled = false;
    }

    private void OnDestroy()
    {
        if (spellSystem != null)
            spellSystem.OnSpellIsCast -= ShowSpellCast;
    }
}
