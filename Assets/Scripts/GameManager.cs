using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public GameObject enemyPrefab;
    private int enemyCount;
    private int spawnAmount = 2;
    private GameObject player;
    public Button resetButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverPage;
    private int score = 0;
    private bool endPageEnabled = false; 

    // Start is called before the first frame update
    void Start()
    {
        gameOverPage.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("SpawnEnemies");
        resetButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (player.GetComponent<PlayerMovement>().isDead && !endPageEnabled)
        {
            gameOverPage.gameObject.SetActive(true);
            endPageEnabled = true;
        }
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

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = $"Score: {score}";
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
