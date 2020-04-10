using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;

    private Health health;

    private Camera camera;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    [SerializeField]
    private TextMeshProUGUI damageText;

    [SerializeField]
    private TextMeshProUGUI healText;

    [SerializeField]
    private Vector3 extraOffset = new Vector3(0,1,0);

    [SerializeField]
    private float fadeAt = 25;

    public void SetHealth(Health health)
    {
        this.health = health;
        nameText.text = health.gameObject.name;
        health.OnHealthChanged += HealthChanged;
        health.OnHealthObjectDestroyed += Destroy;

    }

    private void Destroy()
    {
        if(gameObject)
            Destroy(gameObject);
    }

    private void HealthChanged(float delta)
    {
        if(delta > 0)
        {
            healText.text = "+" + delta.ToString();
            healText.GetComponent<Animation>().Play();
        }
        if(delta < 0)
        {
            damageText.text = delta.ToString();
            damageText.GetComponent<Animation>().Play();
        }
    }

    public void Start()
    {
        camera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnDestroy()
    {
        if (health != null)
        {
            health.OnHealthChanged -= HealthChanged;
            health.OnHealthObjectDestroyed -= Destroy;
        }
    }

    private void Update()
    {
        if(health == null) {
            Destroy(gameObject);
        }

        UpdateHealthBar();

        UpdateTooltipPosition();
        UpdateTooltipAlpha();
    }

    private void UpdateTooltipPosition()
    {
        TooltipOffset tooltipOffset = health.transform.GetComponent<TooltipOffset>();
        rectTransform.position = camera.WorldToScreenPoint(health.transform.position + (tooltipOffset != null ? tooltipOffset.Offset : Vector3.zero) + extraOffset);
    }

    private void UpdateHealthBar()
    {
        GetComponent<Animation>()["Health"].speed = 0;
        GetComponent<Animation>()["Health"].time = health.CurrentHealth / health.MaxHealth;
    }

    private void UpdateTooltipAlpha()
    {
        // If health transform is currently behind camera, position.z will be less than 0. Set alpha to 0.
        if (rectTransform.position.z < 0)
        {
            canvasGroup.alpha = 0;
            return;
        }

        // If the current target of the targetmanager (locked or not) is the same as the health transform, set alpha to 1.
        Target target = Player.Instance.TargetManager.Target;
        if (target.HasTargetTransform)
        {
            if (target.TargetTransform == health.transform)
            {
                canvasGroup.alpha = 1;
                return;
            }
        }

        // If the current (or locked) target is not the same as the health transform, but the health transform is in front of the camera, set its
        // alpha to decrease with the distance to the transform.
        if (rectTransform.position.z > 0)
        {
            canvasGroup.alpha = 1 - (Vector3.Distance(camera.transform.position, health.transform.position) / fadeAt);
        }
    }
}
