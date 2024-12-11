using UnityEngine;
using UnityEngine.Rendering;

public class MouseMovment : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;
    [SerializeField]
    private float topclamb = -90f;
    [SerializeField]
    private float bottomclamb = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock cursor
        Vector3 initialRotation = transform.localRotation.eulerAngles;
        xRotation = initialRotation.x;
        yRotation = initialRotation.y;

    }

    // Update is called once per frame
    void Update()
    {
        //move top and bottom x
        //move left and right y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime ; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime ;

        //rotation around X axis -> look up and down 
        xRotation -= mouseY;

        //clamb rotation(90 degree nte moolikk thiriyaan pattoola
        xRotation = Mathf.Clamp(xRotation, topclamb, bottomclamb);


        //rotation around Y axis -> look right  and left 
        yRotation += mouseX;

        //apply rotation to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);


    }
}
