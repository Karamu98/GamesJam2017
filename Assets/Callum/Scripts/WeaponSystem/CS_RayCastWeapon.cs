using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_RayCastWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject FirstWeapon;

    [SerializeField]
    GameObject SecondaryWeapon;

    [SerializeField]
    AudioClip HitMark; // The sound on impact

    GameObject CurrentWeapon;
    bool bActive = true; // Is the weapon active
    float fTimer; // Times weapon fire rate
    RaycastHit RayCastInformation; // Stores the information of hit results





    void Start()
    {
        // Find a way to use cameras forward to adjust rotation

        CurrentWeapon = Instantiate(FirstWeapon);
        CurrentWeapon.transform.parent = transform;
        CurrentWeapon.transform.localPosition = CurrentWeapon.GetComponent<CS_Weapon>().TransformOffSet();
        CurrentWeapon.transform.eulerAngles = CurrentWeapon.GetComponent<CS_Weapon>().RotationOffSet();
        CurrentWeapon.transform.localScale = CurrentWeapon.GetComponent<CS_Weapon>().ScaleOffSet();

    }

    public void SwitchToPrimary()
    {
        // Find a way to use cameras forward to adjust rotation

        if (CurrentWeapon != FirstWeapon)
        {
            Destroy(CurrentWeapon);
            CurrentWeapon = Instantiate(FirstWeapon);
            CurrentWeapon.transform.parent = transform;
            CurrentWeapon.transform.localPosition = CurrentWeapon.GetComponent<CS_Weapon>().TransformOffSet();
            CurrentWeapon.transform.eulerAngles = CurrentWeapon.GetComponent<CS_Weapon>().RotationOffSet();
            CurrentWeapon.transform.localScale = CurrentWeapon.GetComponent<CS_Weapon>().ScaleOffSet();
        }
    }

    public void SwitchToSecondary()
    {
        // Find a way to use cameras forward to adjust rotation

        if (CurrentWeapon != SecondaryWeapon)
        {
            Destroy(CurrentWeapon);
            CurrentWeapon = Instantiate(SecondaryWeapon);
            CurrentWeapon.transform.parent = transform;
            CurrentWeapon.transform.localPosition = CurrentWeapon.GetComponent<CS_Weapon>().TransformOffSet();
            CurrentWeapon.transform.eulerAngles = CurrentWeapon.GetComponent<CS_Weapon>().RotationOffSet();
            CurrentWeapon.transform.localScale = CurrentWeapon.GetComponent<CS_Weapon>().ScaleOffSet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This handles timings and restrictions
        if(fTimer < CurrentWeapon.GetComponentInChildren<CS_Weapon>().GetFireRate())
        {
            fTimer =  fTimer + Time.deltaTime;
        }
        else
        {
            bActive = true;
        }

        // Fire handling
        if (Input.GetMouseButton(0)) // Takes LMB
        {
            // Check what weapon is in use


            if (bActive == true) // Checks if can fire
            {
                // Play animation
                CurrentWeapon.GetComponentInChildren<CS_Weapon>().PlayAnimation();

                // Play Weapon sound
                AudioSource.PlayClipAtPoint(CurrentWeapon.GetComponentInChildren<CS_Weapon>().GetWeaponSound(), transform.position); // Plays audio

                // Play particle effect
                CurrentWeapon.GetComponentInChildren<CS_Weapon>().GetMuzzleEffect().Play();

                // Raycasting
                if (Physics.Raycast(transform.position, GetComponentInParent<Camera>().transform.forward, out RayCastInformation, 5000) && RayCastInformation.transform.tag == ("Enemy")) // Ray casts forward for 4000 units if it hits something AND the tag is "Enemy"...
                {
                    // Play Hit sound
                    AudioSource.PlayClipAtPoint(HitMark, transform.position); // Play audio

                    // Damage enemy
                    RayCastInformation.transform.GetComponent<CS_Enemy>().DamageEnemy(CurrentWeapon.GetComponent<CS_Weapon>().GetMinDamage(), CurrentWeapon.GetComponent<CS_Weapon>().GetMaxDamage());
                }

                // Reset timer and state
                bActive = false; 
                fTimer = 0;
            }
        }
    }

}