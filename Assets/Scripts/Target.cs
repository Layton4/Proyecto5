using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifetime = 2f;
    private GameManager GameManagerScript;
    public int points;

    public ParticleSystem explosionParticleSystem;
    void Start()
    {
        GameManagerScript = FindObjectOfType<GameManager>();
        lifetime = GameManagerScript.spawnRate;
        Destroy(gameObject, lifetime);
    }

    private void OnMouseDown()
    {
        if(!GameManagerScript.isGameover)
        {

            GameManagerScript.UpdateScore(points);
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            Destroy(gameObject);
        if (gameObject.CompareTag("Bad"))
        {
            GameManagerScript.GameOver();
        }
          
        }
    }

    private void OnDestroy()
    {
        GameManagerScript.targetPositions.Remove(transform.position);
        
    }
}
