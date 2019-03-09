using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class CS_GameManager : MonoBehaviour {


    int iWaveNum = 1; // Stores what wave the player is on
    bool bNextWave = false; // Do once for next wave function
    int iMultiplierM = 4; // Melee multiplier based on wave
    int iMultiplierR = 1; // Ranged multiplier based on wave
    int iNumOfBoats; // Stores max boats that round
    int iNumOfMelee; // Stores max melee that round
    int iNumOfRange; // Stores max ranged that round
    bool bTimerDef = false; // Timer Defined, DO ONCE
    float RoundBuffer = 10f; // Max time between rounds
    float BufferTimer; // Times
    int iBoatLeftToSpawn; // Stores ho many boats left to spawn
    int iBoatsAtOneTime = 2;
    int iStart = 0; //Reset to zero at the end of each wave
    int Fin = 15; //reset to 15 at the end of each range


    public int RangeCounter = 0;
    public int MeleeCounter = 0;
    int counter = 0;

    [SerializeField]
    GameObject Melee; // Prefab to instanciate

    [SerializeField]
    GameObject Range; // Prefab to instanciate

    [SerializeField]
    GameObject BoatOne; 

    [SerializeField]
    GameObject BoatTwo; 

    [SerializeField]
    GameObject StaticBoatOne;

    [SerializeField]
    GameObject StaticBoatTwo;

    [SerializeField]
    GameObject Player;

    List<GameObject> MeleeArray = new List<GameObject>(); // Prefab to instanciate
    List<GameObject> RangeArray  = new List<GameObject>(); // Prefab to instanciate

    public void ListenMeleeDeath(GameObject a_Enemy)
    {
        MeleeCounter--;
        MeleeArray.Remove(a_Enemy);
    }

    public void ListenRangeDeath(GameObject a_Enemy)
    {
        RangeCounter--;
        MeleeArray.Remove(a_Enemy);
    }

    // Use this for initialization
    void Start ()
    {
        StartNewWave(4); // Starts first round
    }

    // Update is called once per frame
    void Update()
    {
        BoatSwap();
        if (!EnemiesIsAlive()) // If all enemies are dead
        {
            bTimerDef = true; // DO ONCE for timer
            EndRound();
            if(BufferTimer <= 0)
            {
                iWaveNum++;
                StartNewWave(iWaveNum);
            }
        }
    }

    void EndRound()
    {
        if(bTimerDef)
        {
            BufferTimer = RoundBuffer;
            bTimerDef = false;
        }
        BufferTimer -= Time.deltaTime;
    }

    void StartNewWave(int iWave) // Calculates and spawns enemies and ships
    {
        iWaveNum++; // Increment wave

        iNumOfMelee = iWave * iMultiplierM; // Figures Melee enemies
        iNumOfRange = iWave * iMultiplierR; // Figures Range enemies

        // Add GameObjects to list
        for(int i = 0; i < iNumOfMelee; i++)
        {
            MeleeArray.Add(Instantiate(Melee)); // Instanciates
        }

        for (int i = 0; i < iNumOfRange; i++)
        {
            RangeArray.Add(Instantiate(Range)); // Instanciates
        }
        BoatOne.GetComponent<CS_Ship>().StartPosition();
        BoatTwo.GetComponent<CS_Ship>().StartPosition();
        HandleEnemies(); // Check if we need to spawn more boats with enemies and spawn if nessicary

    }

    void BoatSwap()
    {
        if(BoatOne.GetComponent<CS_Ship>().TestforSwap())
        {
            var enemies = BoatOne.GetComponentsInChildren<CS_Enemy>();

            foreach (CS_Enemy e in enemies) e.gameObject.transform.SetParent(null);
            BoatOne.SetActive(false);

            StaticBoatOne.SetActive(true);

        }
        else if (BoatTwo.GetComponent<CS_Ship>().TestforSwap())
        {
           var enemies =  BoatOne.GetComponentsInChildren<CS_Enemy>();

            foreach (CS_Enemy e in enemies) e.gameObject.transform.SetParent(null);


            BoatTwo.SetActive(false);
            StaticBoatTwo.SetActive(true);
        }
    }


    void HandleEnemies()
    {

        for(int i = 0; i < 12; i++)
        {
            if (i % 4 == 0)
            {
                RangeArray[i/4].transform.position = BoatOne.GetComponent<CS_Ship>().GetSpawnPosition(counter).position;
                RangeCounter++;
                counter++; //sets the range enemies to the boat one spawn points
            }

            MeleeArray[i].transform.position = BoatOne.GetComponent<CS_Ship>().GetSpawnPosition(counter).position;
            MeleeCounter++;
            counter++;
            //sets the melee enemies to the boat one spawn points
        }
        counter = 0;
        if ((iNumOfMelee + iNumOfRange) > 15)
        {
            for (int i = 12; i < (iNumOfMelee + iNumOfRange); i++)
            {
                if(i <= 23)
                {
                    if (i % 4 == 0)
                    {
                        RangeArray[(i / 4)].transform.position = BoatTwo.GetComponent<CS_Ship>().GetSpawnPosition(counter).position;
                        RangeCounter++;
                        counter++; //sets the range enemies to the boat one spawn points
                    }
                    MeleeArray[i].transform.position = BoatTwo.GetComponent<CS_Ship>().GetSpawnPosition(counter).position;
                    MeleeCounter++;
                    counter++;
                }
                
                //sets the melee enemies to the boat one spawn points
            }
        }


    }
    // Spawn two boats with 15 enemies each or remainder enemies
 

    bool EnemiesIsAlive() // Tests if any enemies are still alive
    {
        for( int i = 0; i < iNumOfMelee; i++)
        {
            if (MeleeArray[i] != null)
            {
                CS_Enemy cs = MeleeArray[i].GetComponent<CS_Enemy>();

                if (cs != null)
                {
                    if (cs.IsAlive()) return true;
                }
            }

        }
        for (int i = 0; i < iNumOfRange; i++)
        {
            CS_Enemy cs = RangeArray[i].GetComponent<CS_Enemy>();

            if (cs != null)
            {
                if (cs.IsAlive()) return true;
            }
        }
        return false;
    }
}
