using UnityEngine;

namespace Aether.Levels.StartEnvironment
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
