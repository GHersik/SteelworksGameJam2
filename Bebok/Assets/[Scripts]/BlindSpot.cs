using UnityEngine;

public class BlindSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyChaser")
        {
            collision.GetComponent<BebokBehaviourController>().HideBebok();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyChaser")
        {
            collision.GetComponent<BebokBehaviourController>().ShowBebok();
        }
    }
}
