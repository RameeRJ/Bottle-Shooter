using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = 9.18f * 2;
    public float jumpHeight = 10f;
    private CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = -0.6f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f , 0f , 0f);
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        //ground check
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump triggered"); // Debug the jump trigger
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
        }

        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
