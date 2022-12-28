using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : InteractableObject
{
    public override void Interact(Transform player)
    {
        Debug.Log("Collected");
        GameObject.Destroy(gameObject);
    }
}
