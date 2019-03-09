using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Weapon : MonoBehaviour
{

    public string Name; // The name of the weapon
    public int MaximumDamage; // The maximum damage to inflict on successful hit
    public int MinimumDamage; // The minimum damage to inflict on successful hit
    public int MagazineSize; // How many bullets the weapon can fire before needing to reload
    public int ConsumedPerShot; // How many bullets are consumed per shot
    public float TimeBetweenShots; // Determines how often the weapon can fire
    public AudioClip WeaponSound; // The sound the weapon will make upon firing
    ParticleSystem MuzzleEffect; // The particle effect played upon firing
    Animation WeaponAnimation; // The animation the weapon will use

    public Vector3 Transform;
    public Vector3 Rotation;
    public Vector3 Scale;

    private void Start()
    {
        WeaponAnimation = GetComponentInChildren<Animation>();
        MuzzleEffect = GetComponentInChildren<ParticleSystem>();
    }

    public Vector3 TransformOffSet()
    {
        return Transform;
    }
    public Vector3 RotationOffSet()
    {
        return Rotation;
    }
    public Vector3 ScaleOffSet()
    {
        return Scale;
    }

    public void PlayAnimation()
    {
        WeaponAnimation.Play();
    }

    public string GetName()
    {
        return Name;
    }

    public void SetName(string a_NewName)
    {
        Name = a_NewName;
    }

    public int GetMaxDamage()
    {
        return MaximumDamage;
    }

    public void SetMaxDamage(int a_NewDamage)
    {
        MaximumDamage = a_NewDamage;
    }

    public int GetMinDamage()
    {
        return MinimumDamage;
    }

    public void SetMinDamage(int a_NewDamage)
    {
        MinimumDamage = a_NewDamage;
    }

    public int GetMagSize()
    {
        return MagazineSize;
    }

    public void SetMagSize(int a_NewMagSize)
    {
        MagazineSize = a_NewMagSize;
    }

    public float GetFireRate()
    {
        return TimeBetweenShots;
    }

    public void SetFireRate(float a_NewFireRate)
    {
        TimeBetweenShots = a_NewFireRate;
    }

    public AudioClip GetWeaponSound()
    {
        return WeaponSound;
    }

    public ParticleSystem GetMuzzleEffect()
    {
        return MuzzleEffect;
    }

    public Animation GetAnimation()
    {
        return WeaponAnimation;
    }

}
