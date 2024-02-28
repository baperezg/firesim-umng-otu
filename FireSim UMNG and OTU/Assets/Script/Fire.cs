using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1.0f;
    private float[] startIntensities = new float[0];

    [SerializeField] private ParticleSystem [] fireParticles = new ParticleSystem[0];

    private void Start()
    {
        startIntensities = new float[fireParticles.Length];

        for (int i = 0; i < fireParticles.Length; i++)
        {
            startIntensities[i] = fireParticles[i].emission.rateOverTime.constant;
        }
    }

    private void Update()
    {
        ChangeIntensity();
    }
    private void ChangeIntensity()
    {
        for (int i = 0; i < fireParticles.Length; i++)
        {
            var emission = fireParticles[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
