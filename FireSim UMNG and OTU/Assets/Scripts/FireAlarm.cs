using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class FireAlarm : MonoBehaviour
{
    [Header("Activation Objects")]
    [SerializeField] private GameObject[] warningSignals;

    [Header("Task Ui")]
    public TextMeshProUGUI taskDone;

    private void Update()
    {
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
        taskDone.fontStyle = FontStyles.Strikethrough;
        Destroy(GetComponent<XRGrabInteractable>());
    }
}
