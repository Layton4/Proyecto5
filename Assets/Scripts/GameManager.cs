using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public bool isGameover;
    public List<Vector3> targetPositions;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;
    public int score;

    
    private float spawnRate = 0.5f;
    private Vector3 randomPos;

   

    void Start()
    {
        score = 0;
        StartCoroutine(SpawnRandomTarget());

    }
    void Update()
    {
        
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
    /*private void SpawnTarget()
    {
        int target = Random.Range(0, targetPrefabs.Length);
        Vector3 position = RandomSpawnPosition();

        Instantiate(targetPrefabs[target], position, targetPrefabs[target].transform.rotation);
    }*/

}
