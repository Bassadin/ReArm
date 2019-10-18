using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnFrequency = 2.0f;    
    public EnemyController enemyToSpawn;
    private float timer = 0;

    void Update()
    {
        //Timer stuff
        timer += Time.deltaTime;
        if (timer >= spawnFrequency) {
            spawnEnemy();
            timer = 0;
        }
    }

    void spawnEnemy() {
        EnemyController newEnemy = Instantiate(
            enemyToSpawn,
            new Vector3(
                this.transform.position.x,
                UnityEngine.Random.Range(-6.5f, 6.5f),
                0),
            Quaternion.identity);
        newEnemy.GetComponent<Rigidbody>().AddForce(new Vector3(-newEnemy.getSpeed(), 0, 0));
    }
}
