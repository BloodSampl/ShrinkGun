using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    [SerializeField] GameObject bigBullet;
    [SerializeField] GameObject smallBullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] AudioSource shotSound;
    void Update()
    {
        ShootBig();
        ShootSmall();
    }
    void ShootBig()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject bult = Instantiate(bigBullet, transform.position, Quaternion.identity);
            bult.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
            shotSound.Play();
        }
    }
    void ShootSmall()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bult = Instantiate(smallBullet, transform.position, Quaternion.identity);
            bult.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
            shotSound.Play();
        }
    }
}
