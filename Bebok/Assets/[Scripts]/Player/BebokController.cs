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

    private float currentEnergy;
    public float CurrentEnergy {
        get { return currentEnergy; }
        set { currentEnergy = value; }
    }

    private float moveX, moveY;
    private float currentMoveSpeed;
    private float desiredMoveSpeed;

    private void Start() {
        currentMoveSpeed = moveSpeed;
        desiredMoveSpeed = moveSpeed;
        currentEnergy = maxEnergy;
    }

    private void Update() {
        GatherInputs();
        UpdateEnergy();
        Move();
    }

    private void GatherInputs() {
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
}
