using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CS_Cannon : MonoBehaviour {

    private bool bIsHover; // Tests for UI
    private GameObject Player; // Cache Player
    private Camera m_CannonCamera; // Set camera
    private float fProxSense = 10;
    private bool bIsMounted = false;

    private float rotX;
    private float rotY;

    private float sensitivity = 2f;
    // Use this for initialization
    void Start ()
    {
        m_CannonCamera = GetComponentInChildren<Camera>();
        bIsHover = false;
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(bIsMounted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().SetCamera(true);
                bIsMounted = false;
                Debug.Log("UnMount");
                m_CannonCamera.enabled = false;
            }

            
            rotY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotX -= Input.GetAxis("Mouse X") * sensitivity;

            rotY = Mathf.Clamp(rotY, -60f, 60f);
            rotX = Mathf.Clamp(rotX, -60f, 60f);

            transform.localRotation = Quaternion.Euler(0, -rotX, 0);
            GetComponentInChildren<Camera>().transform.localRotation = Quaternion.Euler(rotY, 0, 0);
            Debug.Log(rotX);
            
        }
		if(Input.GetKeyDown(KeyCode.E) && bIsHover == true)
        {
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().SetCamera(false);
            bIsMounted = true;
            Debug.Log("Mount");
            m_CannonCamera.enabled = true;
        }
	}

    void OnMouseOver()
    {
        bIsHover = true;
    }

    void OnMouseExit()
    {
        bIsHover = false;
    }

    void OnGUI()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < fProxSense)
        {
            if (bIsHover)
            {
                GUI.Box(
                    new Rect(
                        Screen.width / 2 - 100,
                        Screen.height / 2,
                        200,
                        50),
                    "Press E to Use");
            }
        }
      
    }
}
