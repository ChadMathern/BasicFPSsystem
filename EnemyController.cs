using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public int Enemy_health;


    void Start()
    {

        Enemy_health = 2;
    }

    public void Hurt(int damage)
    {
        Enemy_health -= damage;
        if (Enemy_health <= 0)
            gameObject.SetActive(false);
            
        
    }

    private void OnEnable()
    {
        Enemy_health = 2;
    }
}
