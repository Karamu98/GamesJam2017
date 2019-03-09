 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_HoldCharacter : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        print("TRIGGER"); // Debug
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") // On enter, check if the gameobject has tag "Player"
        {
            other.transform.parent = gameObject.GetComponent<Transform>(); // Parent that gameobject to this script
        }
    }

    void OnTriggerExit(Collider other)
    {
        print("Exit"); // Debug
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") // On exit, check if gameobject has tag "Player" 
        {
            other.transform.parent = null; // Remove parenting
        }
    }
}
