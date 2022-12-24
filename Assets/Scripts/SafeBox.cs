using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : InteractableObject
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    Crank crank;

    
    public override void Interact(Transform player, RaycastHit hit)
    {
        if (crank.IsOpen)
            animator.Play("SafeBoxOpen");
    }
}
