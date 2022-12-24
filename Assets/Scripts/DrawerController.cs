using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : InteractableObject
{
    [SerializeField]
    private Animator drawer;
    private bool isOpen = false;
    public override void Interact(Transform player, RaycastHit hit)
    {
        if (isOpen)
        {
            drawer.Play("DrawerClose");
            isOpen = false;
        }
        else
        {
            drawer.Play("DrawerOpen");
            isOpen = true;
        }
    }
}
