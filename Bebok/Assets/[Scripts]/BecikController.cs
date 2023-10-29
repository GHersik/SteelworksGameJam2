using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecikController : MonoBehaviour
{
    public void TransportChild(Transform carrier)
    { 
        this.transform.position = carrier.position;
    }
}
