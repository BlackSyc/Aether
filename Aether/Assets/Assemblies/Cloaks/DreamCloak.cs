﻿using Aether.Core;
using Aether.Core.Companion;
using Aether.Core.Items.ScriptableObjects;
using UnityEngine;

namespace Aether.Cloaks
{
    public class DreamCloak : MonoBehaviour
    {
        [SerializeField]
        private GameObject robinPrefab;

        [SerializeField]
        private Keystone spawnRobinIfFound;

        private void Start()
        {
            if (spawnRobinIfFound.IsFound && Player.Instance.Has<ICompanion>())
            {
                Instantiate(robinPrefab, Player.Instance.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
            }
        }
    }
}
