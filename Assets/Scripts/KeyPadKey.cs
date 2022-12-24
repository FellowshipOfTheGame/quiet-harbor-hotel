using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadKey : InteractableObject
{
    [SerializeField]
    KeyPad keyPad;

    [SerializeField]
    int keyPadIndex;
    public override void Interact(Transform player, RaycastHit hit)
    {
        keyPad.PressKey(keyPadIndex);
        // play sound
    }
}
