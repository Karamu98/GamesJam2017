using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CS_Ship : MonoBehaviour {

    [SerializeField] GameObject[] SpawnPoints;
    [SerializeField] GameObject Ship;
    [SerializeField] GameObject StartPos;
    [SerializeField] GameObject MidPos;
    [SerializeField] GameObject EndPos;

    bool bActive;
    bool bAlive;
    public float angle = 1;
    Vector3 LO;

	// Update is called once per frame
	void Update ()
    {

        Ship.transform.position = Vector3.MoveTowards(Ship.transform.position, MidPos.transform.position, 30 * Time.deltaTime);
        //Ship.transform.DOMove(MidPos.transform.position, 1, true);

        if (bAlive && bActive)
        {
            transform.Rotate(angle, 0, 0);
            angle = angle + (Time.deltaTime / 10);
            if (angle >= 0.15 || angle <= -0.15)
            {
                angle *= -1;
            }
            if (angle == 0)
            {
                angle = 1;
            }



        
        }
    }

    public void StartPosition()
    {
        Ship.transform.position = StartPos.transform.position;
    }

    public bool TestforSwap()
    {
        if(Ship.transform.position == MidPos.transform.position)
        {
            return true;
        }
        return false;
    }

    public Transform GetSpawnPosition(int i)
    {
        return SpawnPoints[i].transform;
    }

    public Transform GetShipPos()
    {
        return Ship.transform;
    }
    public bool IsActive() // Currently being used on scene
    {
        return bActive;
    }

    public bool IsAlive() // Currently alive
    {
        return bAlive;
    }

    public void Initialise() // Spawn
    {
        bActive = false;
        bAlive = true;
    }

    public void Spawn()
    {
        if(bAlive)
        {
            bActive = true;
        }
    }

    public void Die()
    {
        bActive = false;
        bAlive = false;
    }
}
