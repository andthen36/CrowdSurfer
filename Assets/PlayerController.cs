using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject camHolder;
    public float speed, sensitivity, maxForce, jumpForce;
    private Vector2 move, look;
    private float lookRotation;
    public bool grounded;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("crowd"))
    {
        Vector3 direction = collision.transform.position - transform.position;
        direction.y = 0; // Ensure the force is applied horizontally
        direction.Normalize();
        Rigidbody crowdMemberRb = collision.collider.GetComponent<Rigidbody>();
        if (crowdMemberRb != null)
        {
            crowdMemberRb.AddForce(direction * maxForce, ForceMode.Impulse);
        }
    }
}
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y) * speed;
        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - rb.velocity;
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        // Limit force
        rb.AddForce(Vector3.ClampMagnitude(velocityChange, maxForce), ForceMode.VelocityChange);
    }

    void Look()
    {
        transform.Rotate(Vector3.up * look.x * sensitivity);

        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
    }

    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        Look();
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }
}
