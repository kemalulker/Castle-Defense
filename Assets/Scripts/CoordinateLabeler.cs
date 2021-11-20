using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    Vector2Int coordinates = new Vector2Int();

    TextMeshPro label;
    Waypoint waypoint;
    
    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        ProcessAndDisplayCoordinateLabels(); 
    }

    void Update()
    {
        if(!Application.isPlaying)
        {
            ProcessAndDisplayCoordinateLabels();
            UpdateObjectNameByLabel();
        }
        ColorCoordinatesByPlaceable();
        ToggleLabels();
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

    void ColorCoordinatesByPlaceable()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            label.enabled = !label.IsActive();
        }
    }

    void ProcessCoordinateLabels()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
    }
}
