using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private bool onBoat = true;
    public Transform m_boat;

    private void Start()
    {
        if (onBoat)
            transform.parent = m_boat;
        else
            transform.parent = null;
    }

    private void OnEnable()
    {
        EventManager.AddListener("ChangeParentCamera", ChangeParentCamera);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener("ChangeParentCamera", ChangeParentCamera);
    }

    private void ChangeParentCamera(object curParent)
    {
        transform.parent = (Transform)curParent;

        if ((Transform)curParent == m_boat)
            onBoat = true;
        else
            onBoat = false;
    }
}
