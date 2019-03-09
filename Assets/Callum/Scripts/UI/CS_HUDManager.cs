using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_HUDManager : MonoBehaviour {

    public Text Wave;
    public Text Health;
    public Text Score;
    public GameObject Player;

    // Update is called once per frame
    void FixedUpdate ()
    {
        Health.text = "Health: " + Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().GetHealth();
        Score.text = "" + Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().GetScore();
    }
}
