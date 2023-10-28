using System.Collections;
using UnityEngine;

public class SoundMakerController : MonoBehaviour
{
    [SerializeField]
    float colliderRadius = 1f;
    [SerializeField]
    float lastingTime = .5f;

    CircleCollider2D circleCollider;

    void Start()
    {
        circleCollider = this.GetComponent<CircleCollider2D>();
        circleCollider.radius = colliderRadius;
        circleCollider.enabled = true;
        StartCoroutine(Holder(lastingTime));
        circleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<NPC>().SetPathToBebok(this.transform);
        }
    }

    public void SetRadius(float setting)
    {
        colliderRadius = setting;
    }

    public void SetLastingTime(float newLastingTime)
    {
        lastingTime = newLastingTime;
    }

    IEnumerator Holder(float lastingTime)
    {
        yield return new WaitForSeconds(lastingTime);
    }
}
