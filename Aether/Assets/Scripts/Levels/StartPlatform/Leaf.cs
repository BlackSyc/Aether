using UnityEngine;

namespace Aether.StartPlatform
{
    public class Leaf : MonoBehaviour
    {
        public void DespawnPlatform()
        {
            GetComponent<Animator>().SetBool("Spawn", false);
        }

        public void SpawnPlatform()
        {
            GetComponent<Animator>().SetBool("Spawn", true);
        }
    }
}
