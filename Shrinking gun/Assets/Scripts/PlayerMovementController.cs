using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] Transform pivotPoint;
    [SerializeField] float mouseSensetivity = 1f;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    Rigidbody rb;
    Vector2 mouseInput;
    Vector3 moveInput;
    Vector3 moveDir;

    float verticalRotStore;
    bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        GetVerticalRotation();
        GetHorizontlRotation();
        PlayerMove();
        PlayerJump();
    }
    void GetHorizontlRotation()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensetivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                             transform.rotation.eulerAngles.y + mouseInput.x, 
                             transform.rotation.eulerAngles.z);
    }
    void GetVerticalRotation()
    {
        verticalRotStore += mouseInput.y;
        verticalRotStore = Mathf.Clamp(verticalRotStore, -60, 60);

        pivotPoint.rotation = Quaternion.Euler(- verticalRotStore, 
                              pivotPoint.rotation.eulerAngles.y, 
                              pivotPoint.rotation.eulerAngles.z);
    }
    void PlayerMove()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), rb.velocity.y, Input.GetAxis("Vertical")) * moveSpeed;
        moveDir = (transform.forward * moveInput.z) + (transform.up * rb.velocity.y) + (transform.right * moveInput.x);
        rb.velocity = moveDir;
    }
    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpForce, rb.velocity.z);
        }
    }
}
