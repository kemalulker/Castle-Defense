using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinatLabeler : MonoBehaviour
{
    Vector2Int coordinates = new Vector2Int();

    TextMeshPro label;
    
    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        ProcessAndDisplayCoordinateLabels();    
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            ProcessAndDisplayCoordinateLabels();
            UpdateObjectNameByLabel();
        }
    }

    void ProcessAndDisplayCoordinateLabels()
    {
        ProcessCoordinateLabels();
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectNameByLabel()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ProcessCoordinateLabels()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
    }
}
