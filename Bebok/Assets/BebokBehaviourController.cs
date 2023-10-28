using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebokBehaviourController : MonoBehaviour
{
    [SerializeField]
    CircleCollider2D circleCollider2d;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.layer == 6)//6layer to enenmy
        { 
            Destroy(this.gameObject);
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
}
