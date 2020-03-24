using UnityEngine;

public class TravellerPlatform : MonoBehaviour
{
    public Traveller Traveller;

    [SerializeField]
    private bool travelReverse;

    public void Travel(Interactor _, Interactable __)
    {
        StartCoroutine(Traveller.PlayAnimation(travelReverse));
    }
}
