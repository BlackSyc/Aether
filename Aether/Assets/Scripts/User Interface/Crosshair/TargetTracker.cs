using Aether.SpellSystem;
using UnityEngine;
using UnityEngine.UI;

public class TargetTracker : MonoBehaviour
{
    public SpellCast SpellCast;

    public Camera Camera;

    public Vector3 Offset = Vector3.zero;

    private RectTransform rectTransform;

    private Image image;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        SpellCast.CastCancelled += _ => Destroy(gameObject);
        SpellCast.CastComplete += _ => Destroy(gameObject);
        SpellCast.CastInterrupted += _ => Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!SpellCast.Target.HasTargetTransform)
            Destroy(gameObject);

        rectTransform.position = Camera.WorldToScreenPoint(SpellCast.Target.TargetTransform.position + Offset);
        image.enabled = rectTransform.position.z > 0;
    }

    private void OnDestroy()
    {
        SpellCast.CastCancelled -= _ => Destroy(gameObject);
        SpellCast.CastComplete -= _ => Destroy(gameObject);
        SpellCast.CastInterrupted -= _ => Destroy(gameObject);
    }

}
