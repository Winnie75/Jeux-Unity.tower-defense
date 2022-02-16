using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public static WaypointsManager instance;

    public List<Transform> waypoints;


    private void Awake()
    {
        instance = this;
    }


}
