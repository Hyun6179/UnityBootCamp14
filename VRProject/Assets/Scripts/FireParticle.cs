using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    public int count;
    public GameObject smoke;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("FireEx"))
        {
            smoke.SetActive(true);
        }
    }
}
