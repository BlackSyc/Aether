using Aether.TargetSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    private ITarget self;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<ITarget>();

        if (self.Has(out IHealth health))
            health.OnHealthChanged += KnockBack;
    }

    private void KnockBack(float healthDelta)
    {
        if (healthDelta >= 0)
            return;

        float force = -10f * healthDelta;
        GetComponent<Rigidbody>().AddForce(Random.Range(-force, force), force, Random.Range(-force, force));
        //StartCoroutine(Pulsate(-healthDelta));
    }

    private IEnumerator Pulsate(float strength)
    {
        Vector3 oldScale = transform.localScale;

        float amount = strength * 0.001f;
        transform.localScale += new Vector3(amount, amount, amount);

        yield return new WaitForSeconds(0.05f);

        transform.localScale = oldScale;
    }

    private void OnDestroy()
    {
        if(self.Has(out IHealth health))
            health.OnHealthChanged -= KnockBack;
    }
}
