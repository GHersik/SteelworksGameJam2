using System.Collections;
using UnityEngine;

public class SoundMakerController : MonoBehaviour
{
    [SerializeField]
    float colliderRadius = 1f;

    CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
        circleCollider.radius = colliderRadius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
         if (collision.gameObject.layer == 6)
        {

            collision.gameObject.GetComponent<NPC>().SetPathToBebok(this.transform);
        }
    }
}
