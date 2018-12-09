using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    private Vector3 gridPos;
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update () {
        SnapToGrid();
        UpdateLabel();
    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize);
    }

    void UpdateLabel()
    {
        TextMesh textMesh = gameObject.GetComponentInChildren<TextMesh>();

        int gridSize = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;

        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
