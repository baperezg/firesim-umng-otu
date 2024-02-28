using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Extinguish : MonoBehaviour
{

    public ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Foam);

        grabbable.selectExited.AddListener(StopFoam);
    }

    public void Foam(ActivateEventArgs arg)
    {
        smoke.Play();
    }

    public void StopFoam(SelectExitEventArgs arg)
    {
        smoke.Stop();
    }
}
