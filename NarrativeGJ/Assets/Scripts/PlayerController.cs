using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //We make an instance of this object, this is called a singleton
    //Meaning that we can use this exact same object for different tasks
    public static PlayerController _Instance { get; private set; }
    //In this case we create a singleton for our controller, so other objects have easier access to this data
    private PlayerInputs controller;

    private void Start()
    {
        //We check if we already have a GameObject with this script
        if (_Instance != null && _Instance != this)
        {
            //If we do, we destroy any clones
            Destroy(this);
        }
        else
        {
            //If we dont, then that means we only have on GameObject with this script
            _Instance = this;
        }
    }

    private void Awake()
    {
        //We create a new InputController
        controller = new PlayerInputs();
    }

    private void OnEnable()
    {
        //Enable it, right after Awake
        controller.Enable();
    }

    private void OnDisable()
    {
        //Disable it, if we stop using the input system
        controller.Disable();
    }

    public Vector2 Movement()
    {
        return controller.Move.MainMovement.ReadValue<Vector2>();
    }
}
