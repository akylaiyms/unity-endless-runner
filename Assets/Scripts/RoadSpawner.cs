﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public List<GameObject> roads;
    private float offset = 8f;

    // Start is called before the first frame update
    void Start()
    {
        if (roads != null && roads.Count > 0) {
            roads = roads.OrderBy(road => road.transform.position.z).ToList();
        }
    }

    public void MoveRoad() 
    {
        GameObject temp = roads[0];
        roads.Remove(temp);

        float newZ = roads[roads.Count - 1].transform.position.z + offset;
        temp.transform.position = new Vector3(0, 0, newZ);
        roads.Add(temp);
    }
}
