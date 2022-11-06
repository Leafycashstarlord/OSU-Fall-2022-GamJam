using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower laserTowerPrefab;

    [SerializeField] bool isPlaceable;

    public bool IsPlaceable{
        get{
            return isPlaceable;
        }
    }

    void OnMouseDown() {
        if(isPlaceable){
            bool isPlaced = laserTowerPrefab.createTower(laserTowerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
