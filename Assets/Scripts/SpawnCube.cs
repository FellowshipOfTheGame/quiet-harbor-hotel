using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public Rigidbody cube;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 randomPos = new Vector3(Random.Range(40f, -40f), 5, Random.Range(40f, -40f));
            Instantiate(cube, randomPos, Quaternion.identity);

            for (int i = 0; i < 2; i++)
            {
                Vector3 newRandomPos = new Vector3(randomPos.x, randomPos.y + (3 * (i + 1)),randomPos.z);
                Instantiate(cube, newRandomPos, Quaternion.identity);
            }
            
        }        
    }
}
