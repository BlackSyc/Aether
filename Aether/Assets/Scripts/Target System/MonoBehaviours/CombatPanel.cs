using UnityEngine;

namespace Aether.TargetSystem
{
    public class CombatPanel : MonoBehaviour
    {
        private ICombatSystem combatSystem;
        private Transform cameraTransform;

        [SerializeField]
        private HealthBar healthBar;

        private void Start()
        {
            cameraTransform = Camera.main.transform;
            combatSystem = transform.parent.GetComponent<ICombatSystem>();

            if (combatSystem.Has(out IHealth health))
                healthBar.SetHealth(health);
            else
                healthBar.enabled = false;
        }

        private void Update()
        {
            transform.position = transform.parent.position + combatSystem.PanelOffset;
            transform.LookAt(cameraTransform, Vector3.up);
        }
    }
}