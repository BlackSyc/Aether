using Syc.Core.Interaction;
using UnityEngine;

namespace Aether.Attunement
{
    public class TravellerPlatform : MonoBehaviour
    {
        public Traveller Traveller;

        [SerializeField]
        private bool travelReverse;

        public void Travel(Interactor _, Interactable __)
        {
            Traveller.StartTravel(travelReverse);
        }
    }
}
