using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : InteractableObject
{
    [SerializeField]
    private Animator door;
    private bool isOpen = false;
    public override void Interact(Transform player)
    {
        if (isOpen)
        {
            door.Play("doorClose");
            isOpen = false;
        }
        else
        {
            door.Play("doorOpen");
            isOpen = true;
        }
    }
}
