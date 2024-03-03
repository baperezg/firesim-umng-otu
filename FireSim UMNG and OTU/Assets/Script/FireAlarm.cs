using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireAlarm : MonoBehaviour
{
    [Header("Activation Objects")]
    [SerializeField] private GameObject[] warningSignals;

    private void Update()
    {
        if (this.transform.rotation.x > 0.7)
        {
            AlarmPulled();
        }
    }
    private void AlarmPulled()
    {
        foreach(var signal in warningSignals)
        {
            signal.SetActive(true);
        }

        Destroy(GetComponent<XRGrabInteractable>());
    }
}
