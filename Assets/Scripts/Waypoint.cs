using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    Vector2Int gridPos;
    const int gridSize = 10;

    public bool isExplored = false; // ok to make this public because this entire class is basically a data class

    public Waypoint exploredFrom;

    public bool isPlaceable = true;

    public int GetGridSize(){
        return gridSize;
    }

    public Vector2Int GetGridPos(){
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)) //left click
        {
            if (isPlaceable){
                FindObjectOfType<TowerFactory>().AddTower(this);
            }else{
                print("Can't place here");
            }
        }
    }
}
