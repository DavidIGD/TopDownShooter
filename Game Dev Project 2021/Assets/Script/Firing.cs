using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//calls the shoot method when the "fire1" button is pressed which is assigned to mouse1 in the unity settings
        {
            Shoot();
        }
    }
    void Shoot()
    {
        FindObjectOfType<AudioManager>().PlaySound("fireBullet"); //plays firing sound
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//sets the rotation of the bullet to match the player
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //applies a force to the bullet which gives it velocity
    }
}
