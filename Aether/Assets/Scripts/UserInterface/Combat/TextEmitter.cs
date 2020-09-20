using Aether.UserInterface.Combat;
using Syc.Combat.HealthSystem;
using UnityEngine;

public class TextEmitter : MonoBehaviour
{
    [SerializeField]
    private Color healColour;

    [SerializeField]
    private Color damageColour;

    [SerializeField]
    private EmittedText emittedTextPrefab;

    private HealthSystem _linkedHealth;

    public void SetHealth(HealthSystem health)
    {
        _linkedHealth = health;
        _linkedHealth.OnHealthChanged += EmitText;
    }

    private void EmitText(float healthDelta)
    {
        EmittedText emittedText = Instantiate(emittedTextPrefab, transform.position, Quaternion.identity).GetComponent<EmittedText>();
        emittedText.Text.text = Mathf.Abs(healthDelta).ToString();

        if (healthDelta <= 0)
            emittedText.Text.color = damageColour;
        else
            emittedText.Text.color = healColour;

        emittedText.RigidBodyComponent.AddForce(new Vector3(Random.Range(-200f, 200f), Random.Range(100f, 200f), 0));
    }

    private void OnDestroy()
    {
        if (_linkedHealth != null)
            _linkedHealth.OnHealthChanged -= EmitText;
    }
}
