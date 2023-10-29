using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraddleController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Becik")
        {
            collision.gameObject.GetComponent<BecikController>().PlaceBecikInCraddle(this.transform);
        }
    }
}
