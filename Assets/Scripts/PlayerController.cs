using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("Requirement")]
    [SerializeField] TouchInput input;
    [SerializeField] CharacterController characterController;

    [Header("Core Movement")]
    [SerializeField] float xAxisSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] float gravity;

    [Header("Jump")]
    [SerializeField] float jumpHeight;
    [SerializeField] LayerMask groundLayerMask;

    [Header("Events")]
    [SerializeField] UnityEvent voltCollected;
    [SerializeField] UnityEvent NegativeVoltCollected;
    [SerializeField] UnityEvent wireCollected;
    [SerializeField] UnityEvent scissorHit;
    [SerializeField] UnityEvent BottleHit;

    Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.25f, groundLayerMask);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        if (input.SwipeUp() && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -gravity);
        }

        velocity.y += -gravity * Time.deltaTime;

        Vector3 move = new Vector3(input.GetAxis() * xAxisSpeed, velocity.y, forwardSpeed);
        characterController.Move(move * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Volt"))
        {
            other.gameObject.SetActive(false);
            voltCollected.Invoke();
        }
        if (other.gameObject.CompareTag("NegativeVolt"))
        {
            other.gameObject.SetActive(false);
            NegativeVoltCollected.Invoke();
        }
        if (other.gameObject.CompareTag("Wire"))
        {
            other.gameObject.SetActive(false);
            wireCollected.Invoke();
        }
        if (other.gameObject.CompareTag("Bottle")) BottleHit.Invoke();
        if (other.gameObject.CompareTag("Scissor")) scissorHit.Invoke();
    }
}