using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    [SerializeField]
    private Interactor interactor;

    [SerializeField]
    private GameObject modelObject;

    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private PlayerMovement playerMovement;

    private Vector3? travelToPosition;

    private void Start()
    {
        AetherEvents.GameEvents.PlayerEvents.OnSetPlayerPosition += SetPosition;
        AetherEvents.GameEvents.PlayerEvents.OnTravelToPosition += TravelToPosition;
        AetherEvents.GameEvents.PlayerEvents.OnActivateInteractor += ActivateInteractor;
        AetherEvents.GameEvents.PlayerEvents.OnShowModel += ShowModel;
    }

    public void Update()
    {
        if (travelToPosition is Vector3 position)
        {
            playerMovement.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 50);
            if (Vector3.Distance(transform.position, position) < 0.05f)
            {
                transform.position = position;
                travelToPosition = null;
                playerMovement.enabled = true;
            }
        }   
    }

    private void SetPosition(Vector3 newPosition)
    {
        characterController.Move(newPosition - transform.position);
    }

    private void TravelToPosition(Vector3 position)
    {
        travelToPosition = position;
    }

    private void ActivateInteractor(bool flag)
    {
        interactor.IsActive = flag;

        if (!flag)
            interactor.CancelCurrentlyProposedInteraction();
    }

    private void ShowModel(bool flag)
    {
        modelObject.SetActive(flag);
    }

    private void OnDestroy()
    {
        AetherEvents.GameEvents.PlayerEvents.OnSetPlayerPosition -= SetPosition;
        AetherEvents.GameEvents.PlayerEvents.OnTravelToPosition -= TravelToPosition;
        AetherEvents.GameEvents.PlayerEvents.OnActivateInteractor -= ActivateInteractor;
        AetherEvents.GameEvents.PlayerEvents.OnShowModel -= ShowModel;
    }
}
