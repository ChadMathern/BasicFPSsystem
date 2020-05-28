using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMove : MonoBehaviour

{

    private bool dirRight = true;


    void Update()
    {
        if (dirRight)
            transform.Translate(Vector3.right * Random.Range(1f, 5f) * Time.deltaTime);
        else
            transform.Translate(-Vector3.right * Random.Range(1f, 5f) * Time.deltaTime);

        if (transform.position.x >= 20.0f)
        {
            dirRight = false;
        }

        if (transform.position.x <= -20)
        {
            dirRight = true;
        }



    }
}