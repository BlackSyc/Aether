using Aether.TargetSystem;
using TMPro;
using UnityEngine;

public class CombatPanel : MonoBehaviour
{
    protected ICombatSystem combatSystem;
    protected Transform cameraTransform;

    [SerializeField]
    protected TextMeshProUGUI nameText;

    [SerializeField]
    protected HealthBar healthBar;

    [SerializeField]
    protected ModifiersBar modifiersBar;

    protected virtual void Start()
    {
        cameraTransform = Camera.main.transform;
        combatSystem = transform.parent.GetComponent<ICombatSystem>();

        if (nameText != null)
            nameText.text = combatSystem.Name;

        if (healthBar != null)
            LinkHealthBar();

        if (modifiersBar != null)
            LinkModifiersBar();
    }

    protected void LinkHealthBar()
    {
        if (combatSystem.Has(out IHealth health))
            healthBar.SetHealth(health);
        else
            healthBar.enabled = false;
    }

    protected void LinkModifiersBar()
    {
        if (combatSystem.Has(out IModifierSlots modifierSlots))
            modifiersBar.SetModifierSlots(modifierSlots);
        else
            modifiersBar.enabled = false;
    }

    protected virtual void Update()
    {
        transform.position = transform.parent.position + combatSystem.PanelOffset;
        transform.LookAt(cameraTransform, Vector3.up);
    }
}
