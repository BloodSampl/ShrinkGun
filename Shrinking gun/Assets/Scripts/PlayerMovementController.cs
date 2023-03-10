using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] Transform pivotPoint;
    [SerializeField] float mouseSensetivity = 1f;
    float verticalRotStore;
    Vector2 mouseInput;
    private void Update()
    {
        GetVerticalRotation();
        GetHorizontlRotation();
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
}
