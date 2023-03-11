using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float bulletLife = 8f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletLife);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
