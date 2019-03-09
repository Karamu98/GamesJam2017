using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    [SerializeField]
    string LevelName;
    public GameObject[] Buttons;

    bool TimerSet;

    // Use this for initialization
    void Start () {
        TimerSet = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.transform.position = new Vector3(0, 1, -10);
            gameObject.transform.Rotate(0, 130, 0);
            for (int i = 0; i < 3; i++)
            {
                Buttons[i].SetActive(true);
            }
        }
    }

    public void PlayPress()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void InstructionsPress()
    {
        for(int i =0; i < 3; i++)
        {
            Buttons[i].SetActive(false);
        }
        TimerSet = true;
        gameObject.GetComponent<Animation>().Play();
    }

    public void BackPress()
    {
        TimerSet = false;
    }
    
    public void ExitPress()
    {
        Application.Quit();
    }

}
