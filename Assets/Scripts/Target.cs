using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifetime = 2f;
    private GameManager GameManagerScript;
    void Start()
    {
        Destroy(gameObject, lifetime);
        GameManagerScript = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Bad"))
        {
            GameManagerScript.isGameover = true;
            Debug.Log($"Score: {GameManagerScript.score}");
        }
        else
        {
            GameManagerScript.score++;
        }
    }

    private void OnDestroy()
    {
        GameManagerScript.targetPositions.Remove(transform.position);
    }
}
