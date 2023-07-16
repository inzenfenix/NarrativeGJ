using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandUnlock : MonoBehaviour
{
    [SerializeField] private BoxCollider fog;
    private Transform barrier;

    void OnEnable() {
        EventManager.AddListener("PushFog", PushFog);
    }

    void PushFog(object _waypoint)
    {
        Transform waypoint = (Transform)_waypoint; // Busca dentro de la isla un hijo llamado "Waypoint", que es hasta donde se movera la niebla
        if(waypoint != null){
            fog.center = waypoint.position; // Si la isla tiene un waypoint, mueve el collider de la niebla hasta ese Waypoint
        }
    }
}
