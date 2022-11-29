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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScreen");
        }
    }
}
