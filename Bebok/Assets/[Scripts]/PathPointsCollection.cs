using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPointsCollection : MonoBehaviour
{
   [SerializeField]
   List<Transform> points = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            points.Add(gameObject.transform.GetChild(i));
        }
    }
    public List<Transform> ListPoints()
    { 
        return points; 
    }
}
