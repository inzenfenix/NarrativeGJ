using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] private Transform nextWaypoint; // Referencia al waypoint de la siguiente isla
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Como aun no se como determinaremos cuando una isla esta terminada o no, esta funcion debiera llamarse cuando se complete la isla
    void FinishedIsland()
    {
        if(nextWaypoint != null)
            EventManager.TriggerEvent("PushFog", nextWaypoint);
    }
}
