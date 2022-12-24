using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    readonly string correctPassword = "1234";
    string currentPassword = "";

    public bool IsOpen = false;
    public void PressKey(int keyIndex)
    {
        currentPassword += keyIndex.ToString();
        if (currentPassword.Length == correctPassword.Length)
        {
            if (currentPassword == correctPassword)
                IsOpen = true;
            else
                currentPassword = "";

            Debug.Log(IsOpen);
        }
    }
}
