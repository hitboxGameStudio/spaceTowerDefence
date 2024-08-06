using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            float currentSpeed = moveDirection.magnitude;
            animator.SetFloat("Speed", currentSpeed);
            animator.SetFloat("Direction", moveHorizontal);

            // Boole parametresini ayarla
            animator.SetBool("isIdle", currentSpeed < 0.01f);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Yer çekimi
        moveDirection.y -= gravity * Time.deltaTime;

        // Hareketi uygula
        controller.Move(moveDirection * Time.deltaTime);
    }
}
