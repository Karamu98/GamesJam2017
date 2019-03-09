using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CS_Enemy : MonoBehaviour {

    private Animator anim;
    public int iHealth = 10;
    GameObject Player;
    CS_GameManager GameManager;
    Vector3 direction;
    //NavMeshAgent Agent;
    private Transform target; // Stores target transform

    bool bIsActive;
    bool bIsDead;
    float fTimer = 5;
    public int iMoveSpeed = 3; // Movement Speed
    public int iRotSpeed = 3; // Rotation Speed
    public float fProxSense = 10; // Radial meters to detect player

    Transform currentTransform; // Current transform data of this enemy
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CS_GameManager>();
        Player = GameObject.FindWithTag("Player");
        target = Player.transform; // Target the player

        anim = GetComponent<Animator>();
        bIsDead = false;
    }
    void Update()
    {
        if (bIsDead)
        {
            fTimer -= Time.deltaTime;
            if(fTimer <= 0)
            {
               
                Destroy(this);
                bIsDead = false;
                anim.SetBool("isDead", false);
                fTimer = 5;
            }
        }
    }

    public void Kill()
    {
        GameManager.ListenMeleeDeath(this.gameObject);
        bIsDead = true;
        Destroy(this.gameObject);
    }

    public void DamageEnemy(int a_MinDamage, int a_MaxDamage)
    {

        //AudioSource.PlayClipAtPoint(HitWarning, transform.position); // Plays audio
        iHealth = iHealth - UnityEngine.Random.Range(a_MinDamage, a_MaxDamage);
        if (iHealth <= 0)
        {
            anim.SetBool("isAttacking", false);
            Kill();
        }
    }


    void Awake()
        {
            currentTransform = transform; // Cache transform data for easy access/performance
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

            //Agent.destination = Player.transform.position;


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
                Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().DamagePlayer();
            } 
            else
            {
                anim.SetBool("isAttacking", false);
            }
            if(iHealth <= 0)
            {
                anim.SetBool("isDead", true);
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
}
