using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower tower;

    [SerializeField] bool isPlaceable = false;
    public bool IsPlaceable { get => isPlaceable; }

    void OnMouseDown() 
    {
        if (isPlaceable)
        {
            Vector3 instPos = transform.position;
            bool isPlaced = tower.PlaceTower(tower, instPos);
            isPlaceable = !isPlaced;
        }    
    }
}
