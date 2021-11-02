using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensivity = 100f;

    [Header("Miten paljon pelaaja voi katsoa ylös ja alas")]
    public float minXAngle = -70f;
    public float maxXAngle = 90f;
    
    public Transform playerBody;

    public float mouseX;
    public float mouseY;

    private float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        // up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXAngle, maxXAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // left and right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
