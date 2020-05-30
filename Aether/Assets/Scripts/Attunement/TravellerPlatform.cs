using Aether.Core.Interaction;
using UnityEngine;

namespace Aether.Attunement
{
    public class TravellerPlatform : MonoBehaviour
    {
        public Traveller Traveller;

        [SerializeField]
        private bool travelReverse;

        public void Travel(IInteractor _, IInteractable __)
        {
            Traveller.StartTravel(travelReverse);
        }
    }
}
