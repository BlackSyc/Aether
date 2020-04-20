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

        SpellCast.CastCancelled += _ => Destroy();
        SpellCast.CastComplete += _ => Destroy();
        SpellCast.CastInterrupted += _ => Destroy();
    }

    // Update is called once per frame
    private void Update()
    {
        if (SpellCast.Target.HasTargetTransform)
        {
            rectTransform.position = Camera.WorldToScreenPoint(SpellCast.Target.TargetTransform.position + Offset);
            image.enabled = rectTransform.position.z > 0;
        }
        else
        {
            rectTransform.position = Camera.WorldToScreenPoint(SpellCast.Target.Position + Offset);
            image.enabled = false;
        }
    }

    private void Destroy()
    {
        SpellCast.CastCancelled -= _ => Destroy();
        SpellCast.CastComplete -= _ => Destroy();
        SpellCast.CastInterrupted -= _ => Destroy();

        Destroy(gameObject);
    }
}
