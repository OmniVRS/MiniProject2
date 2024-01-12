using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public GameObject enemyPrefab;
    private int enemyCount;
    private int spawnAmount = 2;
    private GameObject player;
    //private 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("SpawnEnemies");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    IEnumerator SpawnEnemies()
    {
        while (!player.GetComponent<PlayerMovement>().isDead)
        {
            if (enemyCount == 0)
            {
                spawnAmount += 1;

                for (int i = 0; i < spawnAmount; i++)
                {
                    int spawnPoint = Random.Range(0, spawnPoints.Count);
                    Instantiate(enemyPrefab, spawnPoints[spawnPoint].transform.position, enemyPrefab.transform.rotation);
                }
            }
            yield return new WaitForFixedUpdate();
        }

    }
}
