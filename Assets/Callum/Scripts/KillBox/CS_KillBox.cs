using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_KillBox : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("Hit Player");
            col.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().KillPlayer();
        } else if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<CS_Enemy>().Kill();
        }
    }
}
