using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ProjectileDamage : MonoBehaviour
{
    public float fActiveTime = 5; // Seconds
    bool bActive = true;


    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player")) // Test gameobjects tag
        {
            col.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().iHealth -= 10; // Accesses script and removes "10" health DEBUG

            if (col.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().iHealth <= 0) // Checks for 'Death'
            {
                col.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().KillPlayer();
                // Call "Die" in player
            }

            Destroy(gameObject); // Destroys this
        }   
    }

    void Update()
    {
        if(bActive == false) // Checks for active
        {
            Destroy(gameObject); // Destroys this
        }

        fActiveTime -= Time.deltaTime; // Reduces timer with deltatime

        if(fActiveTime < 0) // Tests for 0
        {
            bActive = false; // Deactivates
        }
    }
}
