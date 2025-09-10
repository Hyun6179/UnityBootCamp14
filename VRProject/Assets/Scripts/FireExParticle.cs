using UnityEngine;

public class FireExParticle : MonoBehaviour
{
    public ParticleSystem fire, smoke;

    private void OnParticleCollision(GameObject other)
    {
        int t = other.gameObject.GetComponent<FireParticle>().count++;
        fire = other.gameObject.GetComponent<ParticleSystem>();
        smoke = other.gameObject.transform.GetChild(1).GetComponent<ParticleSystem>(); 
        var fire_em = fire.emission;
        var smoke_em = smoke.emission;
        fire_em.enabled = true;
        smoke_em.enabled = true;

        if ( t >= 100 )
        {
            fire_em.rateOverTime = Mathf.Lerp(100.0f, 0.0f, t * 5f);
            smoke_em.rateOverTime = Mathf.Lerp(5.0f, 0.0f, t * 5f);
        }
    }

}
