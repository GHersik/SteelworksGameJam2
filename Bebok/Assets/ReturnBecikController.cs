using UnityEngine;

public class ReturnBecikController : MonoBehaviour
{
    [SerializeField]
    Transform craddleLocalization;

    [SerializeField]
    BecikController becikController;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            becikController.BecikPickedByFamily(collision.transform);
            collision.gameObject.GetComponent<NPC>().SetPathToCraddle(craddleLocalization);
        }
    }
}
