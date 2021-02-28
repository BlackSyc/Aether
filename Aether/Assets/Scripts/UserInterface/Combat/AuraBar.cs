using System.Collections.Generic;
using Syc.Combat.Auras;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    public class AuraBar : MonoBehaviour
    {
        [SerializeField]
        private GameObject auraIconPrefab;

        private List<AuraIcon> _auraIcons;

        private AuraSystem _auraSystem;

        [SerializeField]
        private float iconScale = 1;

        private void Start()
        {
            _auraIcons = new List<AuraIcon>();
        }

        public void SetAuraSystem(AuraSystem auraSystem)
        {
            if (auraSystem != null)
            {
                _auraSystem = auraSystem;
                auraSystem.OnAuraAdded += AddAuraIcon;
                auraSystem.OnAuraRemoved += RemoveAuraIcon;
                return;
            }
            else
            {
                if (_auraSystem != null)
                {
                    _auraSystem.OnAuraAdded -= AddAuraIcon;
                    _auraSystem.OnAuraRemoved -= RemoveAuraIcon;
                    _auraSystem = null;
                }
            }
            
        }

        private void OnDestroy()
        {
            if (_auraSystem == null)
                return;

            _auraSystem.OnAuraAdded -= AddAuraIcon;
            _auraSystem.OnAuraRemoved -= RemoveAuraIcon;
        }

        private void RemoveAuraIcon(AuraState auraState)
        {
            _auraIcons.RemoveAll(x =>
            {
                if (x.AuraState == auraState)
                {
                    Destroy(x.gameObject);
                    return true;
                }
                return false;
            });
        }

        private void AddAuraIcon(AuraState auraState)
        {
            var newIcon = Instantiate(auraIconPrefab, transform).GetComponent<AuraIcon>();
            newIcon.transform.localScale = new Vector3(iconScale, iconScale, iconScale);
            newIcon.SetAuraState(auraState);
            _auraIcons.Add(newIcon);
        }
    }
}
