using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScallingObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 0.15f, 5f),
                                           Mathf.Clamp(transform.localScale.y, 0.15f, 5f),
                                           Mathf.Clamp(transform.localScale.z, 0.15f, 5f));
        if (collision.gameObject.CompareTag("Big"))
        {
            transform.localScale += Vector3.one;
        }
        else if (collision.gameObject.CompareTag("Small") && transform.localScale.x > 0.15f)
        {
            transform.localScale -= Vector3.one;
        }
    }
}
