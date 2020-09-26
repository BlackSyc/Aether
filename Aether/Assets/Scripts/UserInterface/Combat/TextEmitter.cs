using System.Globalization;
using Syc.Combat.HealthSystem;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class TextEmitter : MonoBehaviour
    {
        [SerializeField]
        private Color healColour;

        [SerializeField]
        private Color damageColour;

        [SerializeField]
        private EmittedText emittedTextPrefab;

        private HealthSystem _linkedHealth;

        public void SetHealth(HealthSystem health)
        {
            _linkedHealth = health;
            _linkedHealth.OnDamageReceived += DamageReceived;
            _linkedHealth.OnHealingReceived += HealingReceived;
        }

        private void HealingReceived(HealRequest healRequest)
        {
            EmitText(healRequest.AmountDealt, false);
        }

        private void DamageReceived(DamageRequest damageRequest)
        {
            EmitText(-damageRequest.AmountDealt, damageRequest.IsCriticalStrike);
        }

        private void EmitText(float healthDelta, bool isCriticalStrike)
        {
            var emittedText = Instantiate(emittedTextPrefab, transform.position, Quaternion.identity).GetComponent<EmittedText>();
            emittedText.text.text = Mathf.Abs(healthDelta).ToString(CultureInfo.InvariantCulture);

            emittedText.text.color = healthDelta <= 0 
                ? damageColour 
                : healColour;

            if (isCriticalStrike)
                emittedText.text.fontSize *= 2;

            emittedText.rigidBodyComponent.AddForce(new Vector3(Random.Range(-200f, 200f), Random.Range(100f, 200f), 0));
        }

        private void OnDestroy()
        {
            if (_linkedHealth == null)
                return;

            _linkedHealth.OnDamageReceived -= DamageReceived;
            _linkedHealth.OnHealingReceived -= HealingReceived;
        }
    }
}
