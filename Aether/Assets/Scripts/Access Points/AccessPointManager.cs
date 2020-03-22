using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AetherEvents;

public class AccessPointManager : MonoBehaviour
{

    private AccessPoint activeAccessPoint;

    private void Start()
    {
        KeystoneEvents.OnKeystoneActivated += CreateAccessPoint;
        KeystoneEvents.OnKeystoneDeactivated += DestroyAccessPoint;
    }

    private void CreateAccessPoint(Keystone keystone)
    {
        if (activeAccessPoint)
                Destroy(activeAccessPoint.gameObject);

        if (keystone == null)
            return;

        if (keystone.AccessPointPrefab == null)
            return;

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
        KeystoneEvents.OnKeystoneActivated -= CreateAccessPoint;
        KeystoneEvents.OnKeystoneDeactivated -= DestroyAccessPoint;
    }
}
