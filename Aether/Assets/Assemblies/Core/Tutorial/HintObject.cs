using UnityEngine;

namespace Aether.Core.Tutorial
{
    public class HintObject : MonoBehaviour
    {
        public void Destroy()
        {
            GetComponent<Animation>().Play("HintDespawn");
            StopAllCoroutines();
            Destroy(gameObject, .5f);
        }
    }
}
