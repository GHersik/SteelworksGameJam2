using UnityEngine;

public class BebokController : MonoBehaviour {
    [Header("Move Settings")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float sprintMoveSpeed = 20f;
    [SerializeField] float acceleration = 5f;
    [Header("Energy Settings")]
    [SerializeField] float energyLossPerSecond = 1f;
    [SerializeField] float energyRegenerationPerSecond = .2f;
    [SerializeField] float maxEnergy = 20f;
    public float MaxEnergy {
        get { return maxEnergy; }
        set { maxEnergy = value; }
    }

    [Header("Animation Settings")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private float currentEnergy;
    public float CurrentEnergy {
        get { return currentEnergy; }
        set { currentEnergy = value; }
    }

    private bool isInputActive;
    private float moveX, moveY;
    private float currentMoveSpeed;
    private float desiredMoveSpeed;

    private void Start() {
        currentMoveSpeed = moveSpeed;
        desiredMoveSpeed = moveSpeed;
        currentEnergy = maxEnergy;

        isInputActive = true;
    }

    public void SetInput(bool state) {
        isInputActive = state;
      //  Debug.Log(isInputActive);
    }

    private void Update() {
        GatherInputs();
        UpdateEnergy();
        Move();
        FlipDirection();
        SprintAnimation();
    }

    private void GatherInputs() {
        if (!isInputActive) {
            moveX = 0;
            moveY = 0;
            //Debug.Log("Cannot interact!");
            return;
        }

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            desiredMoveSpeed = sprintMoveSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            desiredMoveSpeed = moveSpeed;
        }
    }

    private void Move() {
        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, desiredMoveSpeed, acceleration * Time.deltaTime);
        Vector3 movementDirection = new Vector3(moveX, moveY);
        transform.Translate(movementDirection * currentMoveSpeed * Time.deltaTime);

        if (movementDirection.x != 0 || movementDirection.y != 0) {
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }
    }

    private void FlipDirection() {
        if (moveX > 0)
            spriteRenderer.flipX = true;
        else if (moveX < 0)
            spriteRenderer.flipX = false;
    }

    private void UpdateEnergy() {
        if (desiredMoveSpeed == sprintMoveSpeed)
            currentEnergy -= energyLossPerSecond * Time.deltaTime;
        else
            currentEnergy += energyRegenerationPerSecond * Time.deltaTime;

        if (currentEnergy <= 0)
            desiredMoveSpeed = moveSpeed;
        if (currentEnergy > 20)
            currentEnergy = maxEnergy;
    }

    private void SprintAnimation() {
        if (desiredMoveSpeed == sprintMoveSpeed)
            animator.SetBool("isSprinting", true);
        else
            animator.SetBool("isSprinting", false);
    }
}
