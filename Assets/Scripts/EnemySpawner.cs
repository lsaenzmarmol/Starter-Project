using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    int numberOfEnemies = 10;
    Vector2 bottomLeft;
    Vector2 topRight;
    float randX;
    float randY;
    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        for(int i = 0;i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {   
        randX = Random.Range(bottomLeft.x, topRight.x);
        randY = Random.Range(bottomLeft.y, topRight.y);
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector2(randX, randY);
    }
}
