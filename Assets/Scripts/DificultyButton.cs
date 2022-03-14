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
        button.onClick.AddListener(SetDifficulty); //a�adimos la funci�n SetDifficulty como acci�n para cuando clicamos el boton
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    public void SetDifficulty()
    {
        gameManagerScript.StartGame(difficulty);
    }
}
