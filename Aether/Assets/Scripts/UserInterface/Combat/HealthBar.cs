using Syc.Combat.HealthSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class HealthBar : MonoBehaviour
    {
        private HealthSystem health;

        public void SetHealth(HealthSystem health)
        {
            this.health = health;
        }

        private void Update()
        {
            if (health != null)
                UpdateHealthBar();
        }

        private void UpdateHealthBar()
        {
            GetComponent<Animation>()["Health"].speed = 0;
            GetComponent<Animation>()["Health"].time = health.CurrentHealth / health.MaxHealth;
        }
    }
}
