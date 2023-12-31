using UnityEngine;

public class SoundMakerController : MonoBehaviour
{
    CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<NPC>().SetPathToBebok(this.transform);
        }
    }
}
