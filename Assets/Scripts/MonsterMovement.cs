using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public float killDistance = 10f;

    void Update()
    {
        agent.SetDestination(player.position);
        agent.updateRotation = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverScreen");
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
