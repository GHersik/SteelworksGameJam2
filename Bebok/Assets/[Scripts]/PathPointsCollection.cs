using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointsCollection : MonoBehaviour
{
   [SerializeField]
   List<Transform> points = new List<Transform>();

    public List<Transform> ListPoints()
    { 
        return points; 
    }
}
