using Aether.Core;
using TMPro;
using UnityEngine;

namespace Aether.UserInterface.Combat
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(Rigidbody))]
    public class EmittedText : MonoBehaviour
    {

        public TextMeshProUGUI Text;

        public Rigidbody RigidBodyComponent;

        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            RigidBodyComponent = GetComponent<Rigidbody>();
            Destroy(gameObject, 2);
        }

        protected virtual void LateUpdate()
        {

            transform.rotation = Quaternion.LookRotation(Player.Instance.Get<Camera>().transform.forward, Player.Instance.Get<Camera>().transform.up);

            float distanceToCamera = Vector3.Distance(transform.position, Player.Instance.Get<Camera>().transform.position);

            canvasGroup.alpha = distanceToCamera - 3;
        }
    }
}
