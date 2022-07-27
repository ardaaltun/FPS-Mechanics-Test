using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public CharacterController playerController;
    
    public float speed = 20f;


    //MOUSE
    public Camera cam;
    public Transform body;
    float sensitivity = 500f;
    float rotX = 0f;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        Movement();
        Mouse();
        
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right.normalized * horizontal + transform.forward.normalized * vertical;
        playerController.Move(move * speed * Time.deltaTime);

    }

    private void Mouse()
    {
        float xRot = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float yRot = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        rotX -= yRot;
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
        body.Rotate(Vector3.up * xRot);
    }
}
