using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CS_Pickup : MonoBehaviour {

    public float fDistance = 0.2f;
    public float fSpeed = 3f;
    public float fRotSpeed = 3f;
    GameObject Player;
    Vector3 pos;
    Vector3 pos1;
    Vector3 pos2;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindWithTag("Player");
        pos = transform.position; // Stores position
        pos1 = new Vector3(pos.x, (pos.y + fDistance), pos.z); // Stores position above current
        pos2 = new Vector3(pos.x, (pos.y - fDistance), pos.z); // Stores position below current

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(fSpeed * Time.time) + 1.0f) / 2.0f); // Lerp Up and Down
        transform.Rotate(0, fRotSpeed, 0, Space.World); // Rotate
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Player") // If collider hits "Player"
        {
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().iScore += 100; // Increase score
            Destroy(gameObject); // Destroy Pickup
        }
    }
}
