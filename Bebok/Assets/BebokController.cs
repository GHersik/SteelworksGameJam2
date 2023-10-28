using UnityEngine;

public class BebokController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    CircleCollider2D circleTrigerCollider;

    private float moveX, moveY;


    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveY = Input.GetAxisRaw("Vertical") * moveSpeed;
        Vector3 moveVector = new Vector3(moveX, moveY);

        transform.Translate(moveVector * Time.deltaTime);
        
        //if input
    }

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    void CheckSurroundings()
    {
        circleTrigerCollider.enabled = true;
    }
}
