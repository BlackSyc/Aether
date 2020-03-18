using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPointManager : MonoBehaviour
{

    private AccessPoint activeAccessPoint;

    private void Start()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated += CreateAccessPoint;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated += DestroyAccessPoint;
    }

    private void CreateAccessPoint(Keystone keystone)
    {
        if (activeAccessPoint)
                Destroy(activeAccessPoint.gameObject);

        GameObject accessPoint = Instantiate(keystone.AccessPointPrefab, transform);
        activeAccessPoint = accessPoint.GetComponent<AccessPoint>();
    }

    private void DestroyAccessPoint(Keystone keystone)
    {
        if (activeAccessPoint)
        {
            if(activeAccessPoint.Keystone == keystone)
            {
                Destroy(activeAccessPoint.gameObject);
                activeAccessPoint = null;
            }
        }
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneActivated -= CreateAccessPoint;
        AetherEvents.GameEvents.AttunementEvents.OnKeystoneDeactivated -= DestroyAccessPoint;
    }
}
