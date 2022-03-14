using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManagerScript;
    public int difficulty;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty); //añadimos la función SetDifficulty como acción para cuando clicamos el boton
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    public void SetDifficulty()
    {
        gameManagerScript.StartGame(difficulty);
    }
}
