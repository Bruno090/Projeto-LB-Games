using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //varial para chamar a tela de gameover/fim de jogo
    public GameObject gameOver;

    //criar uma variavel  estatica do GameController
    public static GameController instance;

    void Start()
    {
        // instanciar ao iniciar o jogo 
        instance = this;
    }

    //Chmar a tela de gameover quando a variavel "GameOver" for chamada
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    //Botão pra reiniciar o Nivel caso o personagem morra 
  public void RestartGame(string lvlName)
  {
        SceneManager.LoadScene(lvlName);
  }
}
