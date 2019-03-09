using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DebrisSpawner : MonoBehaviour {
    [SerializeField]
    GameObject[] DebrisArray;

    [SerializeField]
    GameObject StartRow;

    [SerializeField]
    GameObject EndRow;

    List<GameObject> Debris = new List<GameObject>(); // Prefab to instanciate
    public bool[] isActive;
    System.Random rnd = new System.Random();
    public int iTotal;
    int Num;
    public float timer;
    int iMoveSpeed = 3;
    int iDebrisSpawned;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= 2 * Time.deltaTime;
        if(timer <= 0)
        {
            Num = rnd.Next(1, iTotal);
            Debris.Add(Instantiate(DebrisArray[Num]));
            Debris[Num].transform.position = new Vector3(0, 0, 16);
            timer = 10f;
        }
        
        for(int i = 0; i < iTotal; i++)
        {
            if (isActive[i])
            {
                DebrisArray[i].transform.position += DebrisArray[i].transform.forward * iMoveSpeed * Time.deltaTime;
            }
        }
	}
}
