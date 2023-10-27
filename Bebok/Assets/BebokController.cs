using UnityEngine;

public class BebokController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 10f;

    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * moveSpeed;

        RaycastHit hit;

        Vector3 p1 = transform.position + this.transform.position;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(p1, 0, transform.forward, out hit, 10))
        {
            Debug.Log(distanceToObstacle = hit.distance);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}
