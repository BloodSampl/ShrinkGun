using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPoint : MonoBehaviour
{
    [SerializeField] string objectTag;
    [SerializeField] Transform holdPoint;
    [SerializeField] GameObject path;
    [SerializeField] AudioSource pathSound;


    private void Update()
    {
        if(holdPoint.childCount < 1)
        {
            path.SetActive(false);
        }
        else
        {
            path.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(objectTag))
        {
            GameObject obj = collision.gameObject;
            obj.transform.position = holdPoint.position;
            obj.transform.parent = holdPoint;
            path.SetActive(true);
            pathSound.Play();
        }
    }
}
