using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public Transform EnemySpawn;
    public float SpawnTime;
    private float SpawnDelay;
    public int EnemyPicker;
    public ObjectPooler[] ObjectPools;
    

    // Use this for initialization
    void Start () {
        SpawnDelay = Random.Range(5,10);

        InvokeRepeating("SpawnObject", SpawnTime, SpawnDelay);
	}
	
	// Update is called once per frame
	void Update () {
        EnemyPicker = Random.Range(0, ObjectPools.Length);
        
        
    }

    public void SpawnObject()
    {
        GameObject NewEnemy = ObjectPools[EnemyPicker].GetPooledObject();
        NewEnemy.transform.position = transform.position;
        NewEnemy.SetActive(true);
        
    }
}
