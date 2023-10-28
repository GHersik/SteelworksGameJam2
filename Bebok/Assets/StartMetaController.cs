using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMetaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Becik")
            Debug.Log("GG easy");
    }
}
