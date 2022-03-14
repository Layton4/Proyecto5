using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public bool isGameover;
    public List<Vector3> targetPositions;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;
    public int score;

    
    public float spawnRate = 1.8f;
    private Vector3 randomPos;

    public TextMeshProUGUI pointsText;
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;

    void Start()
    {
        mainMenuPanel.SetActive(true);

    }
    private Vector3 RandomSpawnPosition()
    {
        int jumpx = Random.Range(0, 4);
        int jumpy = Random.Range(0, 4);

        float spawnX = minX + jumpx * distanceBetweenSquares;
        float spawnY = minY + jumpy * distanceBetweenSquares;
        return new Vector3(spawnX, spawnY, 0);
    }


    private IEnumerator SpawnRandomTarget()
    {
        while(!isGameover)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();

            while(targetPositions.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }
            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(randomPos);
        }
    }

    public void  RestartGame()
    {
      SceneManager.LoadScene(0);
    }
    public void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        pointsText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        isGameover = true;
        gameOverPanel.SetActive(true);
    }

    public void StartGame(int dificulty)
    {

        mainMenuPanel.SetActive(false);
        isGameover = false;
        score = 0;
        UpdateScore(0);

        spawnRate /= dificulty;

        StartCoroutine(SpawnRandomTarget());
        gameOverPanel.SetActive(false);
    }

}
