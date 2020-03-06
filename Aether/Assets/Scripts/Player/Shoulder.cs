using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    [SerializeField]
    private GameObject dreamCloakPrefab;

    [SerializeField]
    private GameObject nightmareCloakPrefab;

    [SerializeField]
    private GameObject illusionCloakPrefab;

    public void EquipDreamCloak()
    {
        GameObject dreamCloak = Instantiate(dreamCloakPrefab, transform);
        dreamCloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[]{ GetComponent<CapsuleCollider>()};
    }

    public void EquipNightmareCloak()
    {
        GameObject nightmareCloak = Instantiate(nightmareCloakPrefab, transform);
        nightmareCloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
    }

    public void EquipIllusionCloak()
    {
        GameObject illusionCloak = Instantiate(illusionCloakPrefab, transform);
        illusionCloak.GetComponent<Cloth>().capsuleColliders = new CapsuleCollider[] { GetComponent<CapsuleCollider>() };
    }
}
