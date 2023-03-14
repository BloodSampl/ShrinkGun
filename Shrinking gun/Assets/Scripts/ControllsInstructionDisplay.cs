using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllsInstructionDisplay : MonoBehaviour
{
    [SerializeField] float timeToClose = 15;

    private void Start()
    {
        Invoke("DisableGameObject", timeToClose);
    }

    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
