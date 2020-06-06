using Aether.Core;
using Aether.Core.Combat;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTargetIndicator : MonoBehaviour
{
    private ISpellCast currentSpellCast;

    private ICombatSystem combatSystem;

    [SerializeField]
    private Image image;

    public void SetCombatSystem(ICombatSystem combatSystem)
    {
        this.combatSystem = combatSystem;
    }
    private void Awake()
    {
        Player.Instance.Get<ICombatSystem>().Get<ISpellSystem>().OnSpellIsCast += OnPlayerSpellCast;
    }

    private void OnPlayerSpellCast(ISpellCast spellCast)
    {
        if (spellCast.Spell.CastDuration < 0.01f)
            return;

        currentSpellCast = spellCast;
        spellCast.CastCancelled += ClearCurrentSpellCast;
        spellCast.CastComplete += ClearCurrentSpellCast;
        spellCast.CastInterrupted += ClearCurrentSpellCast;
    }

    private void ClearCurrentSpellCast(ISpellCast spellCast)
    {
        if (spellCast == currentSpellCast)
        {
            currentSpellCast.CastCancelled -= ClearCurrentSpellCast;
            currentSpellCast.CastComplete -= ClearCurrentSpellCast;
            currentSpellCast.CastInterrupted -= ClearCurrentSpellCast;
        }

        currentSpellCast = null;
        image.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpellCast != null)
            image.enabled = currentSpellCast.Target == combatSystem;
    }

    private void OnDestroy()
    {
        Player.Instance.Get<ICombatSystem>().Get<ISpellSystem>().OnSpellIsCast += OnPlayerSpellCast;
        if (currentSpellCast != null)
        {
            currentSpellCast.CastCancelled -= ClearCurrentSpellCast;
            currentSpellCast.CastComplete -= ClearCurrentSpellCast;
            currentSpellCast.CastInterrupted -= ClearCurrentSpellCast;
            currentSpellCast = null;
        }
    }
}
