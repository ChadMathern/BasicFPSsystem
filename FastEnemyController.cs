using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : MonoBehaviour {

    private int Enemy_health;


    void Start()
    {
        Enemy_health = 1;
    }

    public void Hurt(int damage)
    {
        Enemy_health -= damage;
        if (Enemy_health <= 0)
            gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        Enemy_health = 1;
    }
}
