using UnityEngine;

public class BebokController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;

    private float moveX, moveY;


    void FixedUpdate()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveY = Input.GetAxisRaw("Vertical") * moveSpeed;
        Vector3 moveVector = new Vector3(moveX, moveY);

        transform.Translate(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}
