using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTooltipManager : MonoBehaviour
{
    [SerializeField]
    private GameObject healthTooltipPrefab;
    private List<HealthTooltip> healthTooltips = new List<HealthTooltip>();

    private void Start()
    {
        Health.Events.OnHealthActivated += CreateHealthTooltip;
    }

    private void CreateHealthTooltip(Health health)
    {
        if (health.CompareTag("Player"))
            return;

        Debug.Log("Creating HealthTooltip!");
        GameObject newHealthTooltipObject = GameObject.Instantiate(healthTooltipPrefab, transform);
        HealthTooltip newHealthTooltip = newHealthTooltipObject.GetComponent<HealthTooltip>();
        newHealthTooltip.SetHealth(health);
        healthTooltips.Add(newHealthTooltip);
    }

    private void OnDestroy()
    {
        Health.Events.OnHealthActivated -= CreateHealthTooltip;
    }
}
