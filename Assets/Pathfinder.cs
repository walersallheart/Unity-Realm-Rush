using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool isRunning = true;

    Vector2Int[] directions = {
        Vector2Int.right,
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left
    };

	// Use this for initialization
	void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        //ExploreNeighbours();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while(queue.Count > 0)
        {
            Waypoint searchCenter = queue.Dequeue();
            print(searchCenter);

            HaltIfEndFound(searchCenter);
        }

        Print("Finish pathfinding?");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stopping");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            print("Exploring " + explorationCoordinates);
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            } catch {
                //nada
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            } else {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
