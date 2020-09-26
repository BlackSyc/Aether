using UnityEngine;

namespace Aether.Levels.StartEnvironment.TargetDummy
{
	public class DummySpawner : MonoBehaviour
	{

		[SerializeField] private TargetDummyCombatSystem dummyPrefab;

		private void Awake()
		{
			SpawnNewDummy();
		}

		public void SpawnNewDummy()
		{
			Instantiate(dummyPrefab, gameObject.transform).Spawner = this;
		}
	}
}
