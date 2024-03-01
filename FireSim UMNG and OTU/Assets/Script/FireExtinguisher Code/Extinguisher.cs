using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Extinguisher : MonoBehaviour
{
    public ParticleSystem foamParticle;
    public bool canFoam = false;
    [SerializeField] private float amountExtinguishedPerSecond = 1.0f;
    [SerializeField] private bool isSpraying = false;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Foam);

        grabbable.deactivated.AddListener(StopFoam);
    }
    private void Update()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out RaycastHit hit, 100f)
            && hit.collider.TryGetComponent(out Fire fire) && isSpraying)
        {
            fire.TryExtinguish(amountExtinguishedPerSecond * Time.deltaTime);
        }
    }
    public void Foam(ActivateEventArgs arg)
    {
        if (canFoam)
        {
            isSpraying = true;
            foamParticle.Play();
        }
    }

    public void StopFoam(DeactivateEventArgs arg)
    {
        if (canFoam)
        {
            isSpraying = false;
            foamParticle.Stop();
        }
    }
}
