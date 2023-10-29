using UnityEngine;

public class BebokBehaviourController : MonoBehaviour
{
    [SerializeField]
    CircleCollider2D circleCollider2d;
    [SerializeField]
    GameObject becik;

    bool becikCanBePickedUp = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && becikCanBePickedUp)
        {
            var becikController = becik.GetComponent<BecikController>();
            //becikController.TransportChild(this.transform,beb);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == 6)//6layer to enenmy
        {
            Destroy(this.gameObject);
        }

        if (collision.transform.gameObject.name == "Becik")
        {
            becikCanBePickedUp = true;
            becik = collision.transform.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Becik")
        {

            becikCanBePickedUp = false;
            becik = null;
        }
    }

    public void HideBebok()
    {
        circleCollider2d.enabled = false;
    }

    public void ShowBebok()
    {
        circleCollider2d.enabled = true;
    }



    void PickupBecik()
    {

    }
}