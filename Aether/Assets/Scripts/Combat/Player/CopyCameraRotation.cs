using UnityEngine;

namespace Aether.Combat.Player
{
    public class CopyCameraRotation : MonoBehaviour
    {

        private Transform _cameraTransform;
        
        // Start is called before the first frame update
        void Start()
        {
            if (!(Camera.main is null))
                _cameraTransform = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = _cameraTransform.rotation;
        }
    }
}
