using UnityEngine;

public class RayCastController : MonoBehaviour
{
    float distance = 15f;
    [SerializeField]
    NPC npc;

    private void Start()
    {
        npc = this.transform.parent.GetComponent<NPC>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.layer == 3)//3 to Bebok layer
                npc.SetPathToBebok(hit.transform);
        }
        Debug.DrawLine(transform.position, transform.position + (transform.up * distance), Color.red);
    }
}
