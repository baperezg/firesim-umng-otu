using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Fire : MonoBehaviour
{
    [Header("Fire Stats")]
    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1.0f;
    private bool isLit = true;
    private float[] startIntensities = new float[0];

    [Header("Components")]
    [SerializeField] private ParticleSystem [] fireParticles = new ParticleSystem[0];
     private AudioSource fireSound;

    [Header("Fire Regen")]
    [SerializeField] private float regenDelay = 2.5f;
    [SerializeField] private float regenRate = 0.1f;
    private float timeLastExtinguished = 0;

    [Header("Task Ui")]
    public TextMeshProUGUI taskDone;

    private void Start()
    {
        fireSound = GetComponent<AudioSource>();
        startIntensities = new float[fireParticles.Length];

        for (int i = 0; i < fireParticles.Length; i++)
        {
            startIntensities[i] = fireParticles[i].emission.rateOverTime.constant;
        }
    }

    private void Update()
    {
        if(isLit && currentIntensity < 1.0f && Time.time - timeLastExtinguished >= regenDelay)
        {
            currentIntensity += regenRate * Time.deltaTime;
            ChangeIntensity();
        }
    }

    public bool TryExtinguish(float amount)
    {
        timeLastExtinguished = Time.time;

        currentIntensity -= amount;

        ChangeIntensity();

        if(currentIntensity <=0)
        {
            isLit = false;
            taskDone.fontStyle = FontStyles.Strikethrough;
            return true;
        }

        return false;   
    }
    private void ChangeIntensity()
    {
        for (int i = 0; i < fireParticles.Length; i++)
        {
            var emission = fireParticles[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
        fireSound.volume = currentIntensity;
    }
}
