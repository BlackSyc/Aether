using System.Collections;
using System.Collections.Generic;
using Aether.Levels.StartPlatform;
using UnityEngine;

namespace Aether.StartPlatform
{
    public class AspectPlatform : MonoBehaviour
    {

        [SerializeField]
        private Material glowingMaterial;

        private Material defaultMaterial;

        void Start()
        {
            defaultMaterial = GetComponent<MeshRenderer>().material;

            Puzzle1_Manager.Events.OnStage1Completed += ChangeToGlowingMaterial;
            AspectOfCreation.Events.OnDialogComplete += ChangeToDefaultMaterial;
        }

        private void ChangeToGlowingMaterial()
        {
            GetComponent<MeshRenderer>().material = glowingMaterial;
        }

        private void ChangeToDefaultMaterial()
        {
            GetComponent<MeshRenderer>().material = defaultMaterial;
        }

        void OnDestroy()
        {
            Puzzle1_Manager.Events.OnStage1Completed -= ChangeToGlowingMaterial;
            AspectOfCreation.Events.OnDialogComplete -= ChangeToDefaultMaterial;
        }
    }
}