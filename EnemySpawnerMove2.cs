using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMove2 : MonoBehaviour
{

    private bool dirLeft = true;


    void Update()
    {
        if (dirLeft)
            transform.Translate(Vector3.left * Random.Range(1f, 5f) * Time.deltaTime);
        else
            transform.Translate(-Vector3.left * Random.Range(1f, 5f) * Time.deltaTime);

        if (transform.position.z >= 20.0f)
        {
            dirLeft = false;
        }

        if (transform.position.z <= -20)
        {
            dirLeft = true;
        }



    }
}