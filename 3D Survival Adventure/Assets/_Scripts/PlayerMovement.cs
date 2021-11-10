using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviourPun
{

    [SerializeField] private float movementSpeed = 0f;

    [SerializeField] private float jumpSpeed = 5f;
    private float ySpeed;
    private float originalStepOffset;

    private CharacterController controller = null;
    private Transform mainCameraTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCameraTransform = Camera.main.transform;
        originalStepOffset = controller.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
    }

    private void TakeInput()
    {
        Vector3 movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 calculatedMovement = (forward * movement.z + right * movement.x).normalized;


        if (calculatedMovement.magnitude > 0.01f) 
        { 
            transform.rotation = Quaternion.LookRotation(calculatedMovement); 
        }



        ySpeed += Physics.gravity.y * Time.deltaTime;


        if (controller.isGrounded)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            controller.stepOffset = 0f;
        }

        Vector3 velocity = calculatedMovement * movementSpeed;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);

    }

}
