using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    [SerializeField] Transform pickUpPoint;
    [SerializeField] Transform player;


    float pickUpDistance;
    bool isPicked;

    Rigidbody rb;
    BoxCollider boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        pickUpDistance = Vector3.Distance(player.position, transform.position);
        if (!isPicked)
        {
            ItemPickUP();
        }
        else
        {
            ItemDrop();
        }
    }

    void ItemPickUP()
    {
        if (pickUpDistance < 4)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isPicked && pickUpPoint.childCount < 1)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                boxCollider.enabled = false;
                transform.position = pickUpPoint.position;
                transform.parent = pickUpPoint;
                isPicked = true;
            }
        }
    }
    void ItemDrop()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPicked)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;
            boxCollider.enabled = true;
            isPicked = false;
        }
    }
}
