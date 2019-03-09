using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Ranger : MonoBehaviour
{
    private Animator anim;
    public int iHealth = 100;
    GameObject Player;
    CS_GameManager GameManager;
    Vector3 direction;

    [SerializeField]
    private Transform target; // Stores target transform
    bool bIsActive;

    public int iMoveSpeed = 3; // Movement Speed
    public int iRotSpeed = 3; // Rotation Speed
    public float fProxSense = 10; // Radial meters to detect player

    Transform currentTransform; // Current transform data of this enemy

    public GameObject PrefabProjectile; // Asset to be duplicated
    public float fVelocity = 20; // Force given when spawned

    void Awake()
    {
        currentTransform = transform; // Cache transform data for easy access/performance
    }

    void FireWeapon()
    {
        GameObject Projectile = Instantiate(PrefabProjectile); // Instanciates the prefab
        Projectile.transform.rotation = Quaternion.Euler(UnityEngine.Random.Range(0.0f, 360.0f), UnityEngine.Random.Range(0.0f, 360.0f), UnityEngine.Random.Range(0.0f, 360.0f)); // Randomises Rotation
        Projectile.transform.position = transform.position + Camera.main.transform.forward * 2; // Moves prefab infront of Main camera
        Rigidbody Body = Projectile.GetComponent<Rigidbody>(); // Accesses prefab Rididbody
        Body.velocity = Camera.main.transform.forward * fVelocity; // Gives prefab velocity using main camera direction and value
    }


    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CS_GameManager>();
        target = GameObject.FindWithTag("Player").transform; // Target the player
        anim = GetComponent<Animator>();
    }

    public int GetHealth()
    {
        return iHealth;
    }

    public bool IsAlive()
    {
        return bIsActive;
    }


    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) < fProxSense) // If the player is within range
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);

            // Rotate to look at player
            Vector3 TargetPosition = new Vector3(target.transform.position.x, gameObject.transform.position.y, target.transform.position.z);

            gameObject.transform.LookAt(TargetPosition);

            // Move Forward
            currentTransform.position += new Vector3(currentTransform.forward.x * iMoveSpeed * Time.deltaTime, 0, currentTransform.forward.z * iMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 3)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", true);
                anim.SetBool("isIdle", false);
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Gizmos for visualisation
        Gizmos.DrawWireSphere(transform.position, fProxSense);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().DamagePlayer();
        }

    }
}