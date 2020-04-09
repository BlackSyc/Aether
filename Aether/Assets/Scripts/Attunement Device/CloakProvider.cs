using System;
using System.Collections;
using UnityEngine;

public class CloakProvider : MonoBehaviour
{
    public readonly struct Events
    {
        public static event Action<CloakProvider> OnInteract;

        public static void Interact(CloakProvider cloakObject)
        {
            OnInteract?.Invoke(cloakObject);
        }
    }

    [SerializeField]
    private float showDelay = 4;

    [SerializeField]
    private GameObject cloakObject;

    [SerializeField]
    private Cloak cloak;

    public Cloak Cloak => cloak;

    public void Equip()
    {
        Player.Instance.Shoulder.EquipCloak(cloak);
        CheckEquip(cloak);
    }

    public void Interact(Interactor interactor, Interactable interactable)
    {
        Events.Interact(this);
    }

    public void Unequip()
    {
        Player.Instance.Shoulder.UnequipCloak();
        CheckEquip(cloak);
    }

    private void Start()
    {
        Puzzle1_Manager.Events.OnStage2Completed += Show;
        Cloak.Events.OnCloakEquipped += CheckEquip;
        Cloak.Events.OnCloakUnequipped += CheckEquip;
    }

    private void CheckEquip(Cloak cloak)
    {
        if (cloak != Cloak)
            return;

        if (Cloak.IsEquipped)
        {
            cloakObject.SetActive(false);
        }
        else
        {
            cloakObject.SetActive(true);
        }
    }

    private void Show()
    {
        StartCoroutine(ShowAfter(showDelay));
    }

    private IEnumerator ShowAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cloakObject.SetActive(true);
        GetComponent<Interactable>().IsActive = true;
    }

    private void OnDestroy()
    {
        Puzzle1_Manager.Events.OnStage2Completed -= Show;
        Cloak.Events.OnCloakEquipped -= CheckEquip;
        Cloak.Events.OnCloakUnequipped -= CheckEquip;
    }
}
