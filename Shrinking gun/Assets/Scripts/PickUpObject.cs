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
    SphereCollider sphereCollider;
    CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
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
        if (pickUpDistance < 3)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isPicked && pickUpPoint.childCount < 1 &&
                transform.localScale.x < 1.1 && sphereCollider == null && capsuleCollider == null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                boxCollider.enabled = false;
                transform.position = pickUpPoint.position;
                transform.parent = pickUpPoint;
                isPicked = true;
            }
            if (Input.GetKeyDown(KeyCode.F) && !isPicked && pickUpPoint.childCount < 1 &&
                transform.localScale.x < 1.1 && boxCollider == null && capsuleCollider == null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                sphereCollider.enabled = false;
                transform.position = pickUpPoint.position;
                transform.parent = pickUpPoint;
                isPicked = true;
            }
            if (Input.GetKeyDown(KeyCode.F) && !isPicked && pickUpPoint.childCount < 1 &&
                transform.localScale.x < 1.1 && boxCollider == null && sphereCollider == null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
                capsuleCollider.enabled = false;
                transform.position = pickUpPoint.position;
                transform.parent = pickUpPoint;
                isPicked = true;
            }
        }
    }
    void ItemDrop()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPicked && sphereCollider == null && capsuleCollider == null)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;
            boxCollider.enabled = true;
            isPicked = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && isPicked && boxCollider == null && capsuleCollider == null)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;
            sphereCollider.enabled = true;
            isPicked = false;
        }
        if (Input.GetKeyDown(KeyCode.F) && isPicked && boxCollider == null && sphereCollider == null)
        {
            transform.parent = null;
            rb.isKinematic = false;
            rb.useGravity = true;
            capsuleCollider.enabled = true;
            isPicked = false;
        }
    }
}
