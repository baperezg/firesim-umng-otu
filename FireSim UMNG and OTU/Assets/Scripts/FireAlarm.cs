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
        Debug.Log(this.transform.rotation.x);
        if (this.transform.rotation.x > 0.0)
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
