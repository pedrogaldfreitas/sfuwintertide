using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    float mouseX;
    float mouseY;
    [SerializeField]
    float mouseSensitivity;
    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up*mouseX);
    }

}
