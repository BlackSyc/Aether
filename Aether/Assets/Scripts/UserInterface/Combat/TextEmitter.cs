using Aether.Core.Combat;
using Aether.UserInterface.Combat;
using UnityEngine;

public class TextEmitter : MonoBehaviour
{

    [SerializeField]
    private EmittedText emittedTextPrefab;

    private IHealth linkedHealth;

    public void SetHealth(IHealth health)
    {
        linkedHealth = health;
        linkedHealth.OnHealthChanged += EmitText;
    }

    private void EmitText(float healthDelta)
    {
        EmittedText emittedText = Instantiate(emittedTextPrefab, transform.position, Quaternion.identity).GetComponent<EmittedText>();
        emittedText.Text.text = healthDelta.ToString();
        emittedText.RigidBodyComponent.AddForce(new Vector3(Random.Range(-200f, 200f), Random.Range(100f, 200f), 0));
    }

    private void OnDestroy()
    {
        if (linkedHealth != null)
            linkedHealth.OnHealthChanged -= EmitText;
    }
}
