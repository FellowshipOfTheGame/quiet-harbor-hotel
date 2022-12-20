using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fence : MonoBehaviour
{

    public bool isHole;
    public bool isDoor;
    public bool holeOpen;
    public GameObject door;
    public GameObject hole;
    public AudioSource FenceSfx;
    public float cooldown = 5000;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Playerpickup>().containsItem && !holeOpen)
        {
            door.SetActive(false);
            FenceSfx.Play();
            hole.SetActive(true);
            holeOpen = true;
        }

        if (holeOpen && cooldown >= 0)
        {
            SceneManager.LoadScene("DemoFim");
        }
    }

    private void Update()
    {
        if (holeOpen)
        {
            cooldown--;
        }

    }
}
