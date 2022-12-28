using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject CameraManager;
    public GameObject InventoryObject;
    public GameObject InventoryManager;

    private bool MenuAvailible = true;

    void Update()
    {

        MenuCheck();

        if (Input.GetButtonDown("Inventory") && MenuAvailible)
        {
            OpenInventory();
        }
    }

    public void MenuCheck()
    {
        if (CameraManager.GetComponent<PhotoCapture>().isMaximized)
        {
            MenuAvailible = false;
        } else
        {
            MenuAvailible = true;
        }
    }

    public void OpenInventory()
    {
        if (InventoryObject.activeSelf == true)
        {
            InventoryObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else
        {
            InventoryObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            InventoryManager.GetComponent<InventoryManager>().ListItems();
        }  
    }
}
