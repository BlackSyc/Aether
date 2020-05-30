using Aether.Core;
using Aether.Core.Cloaks;
using Aether.Core.Cloaks.ScriptableObjects;
using Aether.Core.Interaction;
using System.Collections;
using UnityEngine;

internal class CloakProvider : MonoBehaviour, ICloakProvider
{
    [SerializeField]
    private float showDelay = 4;

    [SerializeField]
    private GameObject cloakObject;

    [SerializeField]
    private Cloak cloak;

    public Cloak Cloak => cloak;

    public void Equip()
    {
        Player.Instance.Get<IShoulder>().EquipCloak(cloak);
        CheckEquip(cloak);
    }

    public void Interact(IInteractor interactor, IInteractable interactable)
    {
        Aether.Core.Cloaks.Events.Interact(this);
    }

    public void Unequip()
    {
        Player.Instance.Get<IShoulder>().UnequipCloak();
        CheckEquip(cloak);
    }

    private void Start()
    {
        Aether.Core.Cloaks.Events.OnCloakEquipped += CheckEquip;
        Aether.Core.Cloaks.Events.OnCloakUnequipped += CheckEquip;
        StartCoroutine(ShowAfter(showDelay));
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

    private IEnumerator ShowAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cloakObject.SetActive(true);
        GetComponent<IInteractable>().IsActive = true;
    }

    private void OnDestroy()
    {
        Aether.Core.Cloaks.Events.OnCloakEquipped -= CheckEquip;
        Aether.Core.Cloaks.Events.OnCloakUnequipped -= CheckEquip;
    }
}
