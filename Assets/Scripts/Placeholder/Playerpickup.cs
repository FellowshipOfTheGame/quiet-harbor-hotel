using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerpickup : MonoBehaviour
{

    public bool containsItem;
    public GameObject botoes;
    public GameObject text;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<Boltcutter>().isPickup)
        {
            containsItem = true;
            Destroy(collision.gameObject);
        }
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire3"))
        {
            botoes.SetActive(true);
            text.SetActive(false);
        }
        else
        {
            botoes.SetActive(false);
            text.SetActive(true);
        }
    }
}
