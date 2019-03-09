using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_LevelLoad : MonoBehaviour
{
    [SerializeField]
    string LevelName;


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);
        }
    }
}
