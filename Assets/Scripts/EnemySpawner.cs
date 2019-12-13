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
            new Vector2(
                UnityEngine.Random.Range(this.transform.position.x - 2, this.transform.position.x + 2),
                this.transform.position.y),
            Quaternion.identity);
    }
}
