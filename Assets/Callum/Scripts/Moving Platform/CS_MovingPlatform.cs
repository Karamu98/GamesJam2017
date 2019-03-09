using UnityEngine;
using System.Collections;

public class CS_MovingPlatform : MonoBehaviour
{

    // Platform
    public GameObject Platform; // Holds prefab data
    public Transform[] PointArray; // Holds positional data
    int iArrayPosition = 0; // Holds array position to handle destinations
    public bool StartAt1 = true; // Option

    // Speed
    public float fSpeed = 5f; // Maximum clamped speed
    float fCurrentSpeed; // Manipulated speed for smoothing

    // Waiting times
    public float fWaitTime = 3f;  // How long the platform waits
    float fWaitTimer; // To be manipulated
    //float fStartTime; // Holds start time
    bool bTimerStarted = false; // State of timer



    // Initial
    void Start()
    {
        fWaitTimer = fWaitTime; // Initialises the timer for platform waiting

        if(StartAt1) // Checks if enabled
        {
            Platform.transform.position = PointArray[0].position; // Moves platform asset to position 1
        }


    }



    void Update()
    {
        // Movement ==================================================
        if(fWaitTimer <= 0) // Checks wait timer
        {

            // Makes sure timer starts on platform move
            if( !bTimerStarted )
            {
                //fStartTime = Time.time; // Gets start time
                bTimerStarted = true; // Makes this run once
            }

            Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, PointArray[iArrayPosition].position, Time.deltaTime * fSpeed); // Move towards point
        }


        // Distance Checking =========================================
        float fDistance = Vector3.Distance(PointArray[iArrayPosition].position, Platform.transform.position); // Updates distance

        if (fDistance <= 0.1f) // When the platform reaches target
        {
            fWaitTimer = fWaitTime; // Reset the wait timer

            //fStartTime = Time.time; // Reset the start timer
            bTimerStarted = true; // 

            iArrayPosition++; // Advances to next position in array


            // Array position check =====================================
            if (iArrayPosition > PointArray.Length - 1) // If the number is bigger than the array size
            {
                iArrayPosition = 0; // Set to 0
            }
        }

        fWaitTimer -= Time.deltaTime; // Reduce Timer
    }
        

    void OnDrawGizmos()
    {
        // Gizmos for visulisation
        Gizmos.color = Color.green;
        if (PointArray.Length > 0)
        {
            for (int i = 0; i < PointArray.Length; i++)
            {
                if (PointArray[i] != null)
                {
                    Gizmos.DrawWireCube(PointArray[i].position, Platform.gameObject.GetComponent<BoxCollider>().transform.localScale);
                }
            }
        }
    }
}