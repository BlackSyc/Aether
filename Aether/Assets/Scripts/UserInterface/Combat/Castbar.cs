using Syc.Combat.SpellSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Castbar : MonoBehaviour
{
    [SerializeField]
    private Image castbarImage;

    [SerializeField]
    private TextMeshProUGUI castbarText;

    private SpellCast _currentSpellCast;

    private CastingSystem _castingSystem;

    public void SetCastingSystem(CastingSystem castingSystem)
    {
        _castingSystem = castingSystem;
        _castingSystem.OnNewSpellCast += ShowSpellCast;
    }

    private void ShowSpellCast(SpellCast newSpellCast)
    {
        _currentSpellCast = newSpellCast;
        ShowCastBar();
    }

    private void ShowCastBar()
    {
        castbarText.text = _currentSpellCast.SpellBehaviour.SpellName;
        castbarImage.fillAmount = 0;
        _currentSpellCast.OnSpellCastProgress += UpdateCastProgress;

        castbarImage.enabled = true;
        castbarText.enabled = true;

        _currentSpellCast.OnSpellCancelled += HideCastBar;
        _currentSpellCast.OnSpellCompleted += HideCastBar;
    }

    private void UpdateCastProgress(SpellCast spellCast)
    {
        castbarImage.fillAmount = spellCast.CurrentCastTime / spellCast.SpellBehaviour.CastTime;
    }

    private void HideCastBar(SpellCast spellCast)
    {
        _currentSpellCast.OnSpellCastProgress -= UpdateCastProgress;
        _currentSpellCast.OnSpellCancelled -= HideCastBar;
        _currentSpellCast.OnSpellCompleted -= HideCastBar;

        _currentSpellCast = null;
        castbarText.enabled = false;
        castbarImage.enabled = false;
    }

    private void OnDestroy()
    {
        if (_castingSystem != null)
            _castingSystem.OnNewSpellCast -= ShowSpellCast;
    }
}
