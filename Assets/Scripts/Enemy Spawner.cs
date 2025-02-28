using UnityEngine;
using System;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    
    private float[] arrPosX = {-2f, 0f, 2f};

    [SerializeField]
    private float spawnInterval = 1.5f;
    void Start()
    {
        StartEnemyRoutine();
    }
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");

    }
    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        int enemyIndex = 0;
        int spawnCount = 0;
        while (true)
        {
          //int index = UnityEngine.Random.Range(0, enemies.Length);
            System.Random random = new System.Random();
            int randomIndex = random.Next(arrPosX.Length);
            float randomValue = arrPosX[randomIndex];
            SpawnEnemy(randomValue, enemyIndex);

            spawnCount++;
            if (spawnCount % 10 == 0) 
            {
                enemyIndex++;
            }
            
           


            yield return new WaitForSeconds(spawnInterval);
        }

    }

    void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if (index >= enemies.Length) 
        {
            index = enemies.Length - 1;
        }
        
        Instantiate(enemies[index], spawnPos, Quaternion.identity);



    }
    
}
