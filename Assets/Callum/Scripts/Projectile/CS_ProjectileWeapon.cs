using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_ProjectileWeapon : MonoBehaviour {

    public GameObject PrefabProjectile; // Asset to be duplicated
    public float fVelocity = 20; // Force given when spawned

    // Update is called once per frame
    void Update ()
    {
        GameObject Projectile = Instantiate(PrefabProjectile); // Instanciates the prefab
        Projectile.transform.rotation = Quaternion.Euler(UnityEngine.Random.Range(0.0f, 360.0f), UnityEngine.Random.Range(0.0f, 360.0f), UnityEngine.Random.Range(0.0f, 360.0f)); // Randomises Rotation
        Projectile.transform.position = transform.position + Camera.main.transform.forward * 2; // Moves prefab infront of Main camera
        Rigidbody Body = Projectile.GetComponent<Rigidbody>(); // Accesses prefab Rididbody
        Body.velocity = Camera.main.transform.forward * fVelocity; // Gives prefab velocity using main camera direction and value

	}
}
