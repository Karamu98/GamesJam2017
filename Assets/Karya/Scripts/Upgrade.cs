using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {
    int iGold;
    public Text GoldNum;
    public Text ThreeHundred;
    public Text EightHundred;
    public Text OneThousand;
    public AudioClip myclip;
    public CanvasGroup mainCanvas;
    public CanvasGroup UICanvas;
    GameObject player;

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = myclip;
        mainCanvas.alpha = 0;
        UICanvas.alpha = 1;
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainCanvas.alpha = mainCanvas.alpha == 0 ? 1 : 0;
            UICanvas.alpha = mainCanvas.alpha == 0 ? 1 : 0;
        }
        iGold = int.Parse(GoldNum.text);

        if(mainCanvas.alpha == 1)
        {
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            //player.GetComponent<CS_Player>().enabled = false;
        }
        else
        {
         
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            //player.GetComponent<CS_Player>().enabled = true;
        }
	}

    public void Gun1Press()
    {
        if (ThreeHundred.text != "Equip")
        {
            if (iGold >= 300)
            {
                iGold -= 300;
                GoldNum.text = iGold.ToString();
                ThreeHundred.text = "Equip";
                GetComponent<AudioSource>().Play();
                //HideCurrent Weapon, set active of new weapon
                //PlaySound CaChing
            }
            else
            {
                //PlaySound Error
            }
        }
    }

    public void GunPress()
    {
        if(EightHundred.text != "purchase stuff")
        {
            if (iGold >= 800)
            {
                iGold -= 800;
                GoldNum.text = iGold.ToString();
                EightHundred.text = "Equip";
                GetComponent<AudioSource>().Play();
                //PlaySound CaChing
            }
            else
            {
                //PlaySound Error
            }
        }
      
    }

    public void SwordPress()
    {
        if (OneThousand.text != "Equip")
        {
            if (iGold >= 1500)
            {
                iGold -= 1500;
                GoldNum.text = iGold.ToString();
                OneThousand.text = "Equip";
                GetComponent<AudioSource>().Play();
                //PlaySound CaChing
            }
            else
            {
                //PlaySound Error
            }
        }
    }
}
