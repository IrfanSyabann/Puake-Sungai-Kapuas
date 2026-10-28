using PathCreation.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;
    [Header("Script")]
    [SerializeField] public PathFollower pathFollower;
    CameraControll cameraControll;
    TimeScreen timeScreen;
    TextAnimation textAnimation;
    [Header("References")]
    [SerializeField] Camera playerCamera;
    [Header("Configuration")]
    public bool isPlayerPlay;
    public float speedSmoothTime;
    public float rotationSpeed;
    public float moveSpeed;
    public float jumpPower;
    private Rigidbody rb;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cameraControll = CameraControll.instance;
        timeScreen = TimeScreen.instance;
        textAnimation = TextAnimation.instance;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
            {
                float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

                transform.Rotate(0, mouseX, 0, Space.Self);
            }

            MovementControll();
        }
    }

    void MovementControll()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude > 0.1f)
        {
            Vector3 cameraForward = playerCamera.transform.forward;
            Vector3 cameraRight = playerCamera.transform.right;

            cameraForward.y = 0f;
            cameraRight.y = 0f;

            Vector3 targetDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;
            targetDirection *= moveSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                targetDirection *= 2;
            }

            rb.linearVelocity = targetDirection;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScriptTrigger"))
        {
            Debug.Log("Script Trigger");

            Dialog.activeDialog = true;

            StartCoroutine(textAnimation.AnimationTextDelay(textAnimation.delay, true));
        }
    }
}
