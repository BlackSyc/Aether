using System;
using System.Globalization;
using Aether.Core;
using Syc.Combat.HealthSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Aether.UserInterface.Combat
{
    public class TextEmitter : MonoBehaviour, ILocalPlayerLink
    {
        [SerializeField]
        private Color healColour;

        [SerializeField]
        private Color damageColour;

        [SerializeField]
        private EmittedText emittedTextPrefab;

        private HealthSystem _linkedHealth;

        private Player _player;

        private void Awake()
        {
            Player.LinkToLocalPlayer(this);
        }

        public void SetHealth(HealthSystem health)
        {
            _linkedHealth = health;
            _linkedHealth.OnDamageReceived += DamageReceived;
            _linkedHealth.OnHealingReceived += HealingReceived;
        }

        private void HealingReceived(HealRequest healRequest)
        {
            if(_player && healRequest.Cause == _player.gameObject)
                EmitText(healRequest.AmountDealt, false);
        }

        private void DamageReceived(DamageRequest damageRequest)
        {
            if(_player && damageRequest.Cause == _player.gameObject)
                EmitText(-damageRequest.AmountDealt, damageRequest.IsCriticalStrike);
        }

        private void EmitText(float healthDelta, bool isCriticalStrike)
        {
            var emittedText = Instantiate(emittedTextPrefab, transform.position, Quaternion.identity).GetComponent<EmittedText>();
            emittedText.text.text = $"{Mathf.Abs(healthDelta):0}";

            emittedText.text.color = healthDelta <= 0 
                ? damageColour 
                : healColour;

            if (isCriticalStrike)
                emittedText.text.fontSize *= 2;

            emittedText.rigidBodyComponent.AddForce(new Vector3(Random.Range(-200f, 200f), Random.Range(100f, 200f), 0));
        }

        private void OnDestroy()
        {
            Player.UnlinkFromLocalPlayer(this);
            if (_linkedHealth == null)
                return;

            _linkedHealth.OnDamageReceived -= DamageReceived;
            _linkedHealth.OnHealingReceived -= HealingReceived;
        }

        public void OnLocalPlayerLinked(Player player)
        {
            _player = player;
        }

        public void OnLocalPlayerUnlinked(Player player)
        {
            _player = null;
        }
    }
}
