using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float rangeRandom = 100f;
    public int quantityOfEnemies = 3;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyGenerator();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createEnemy()
    {
        float posX = Random.Range(-rangeRandom, rangeRandom);
        float posy = Random.Range(-rangeRandom, rangeRandom);
        float posz = Random.Range(-rangeRandom, rangeRandom);
        Vector3 meteorPosition = new Vector3(posX, posy, posz);
        Instantiate(enemy, meteorPosition, enemy.transform.rotation);

    }

    public void enemyGenerator()
    {
        for (int i = 0; i < quantityOfEnemies; i++)
        {
            createEnemy();
        }
    }
}
