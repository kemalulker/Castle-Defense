using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable = false;
    [SerializeField] GameObject ballista;


    void OnMouseDown() 
    {
        if (isPlaceable)
        {
            Vector3 instPos = transform.position;
            Instantiate(ballista, instPos, Quaternion.identity);
            isPlaceable = false;
        }    
    }
}
