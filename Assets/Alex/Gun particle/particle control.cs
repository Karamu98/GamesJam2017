using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlecontrol : MonoBehaviour
{

    public ParticleSystem firstSystem;
    public ParticleSystem secondSystem;

    void ActivateFirst()
    {
        firstSystem.Play();
    }

    void ActivateSecond()
    {
        secondSystem.Play();
    }

    void DeactivateBoth()
    {
        firstSystem.Stop();
        secondSystem.Stop();
    }
}