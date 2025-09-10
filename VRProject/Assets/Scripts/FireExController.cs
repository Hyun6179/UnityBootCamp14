using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;
public class FireExController : MonoBehaviour
{
    public ParticleSystem fireEx;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartSpread());
        grabInteractable.deactivated.AddListener(x => StopSpread());
    }
    private void StartSpread()
    {
        fireEx.Play();
    }

    private void StopSpread()
    {
        fireEx.Stop();
    }

}
