using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checando se o iniciar foi cliclad
    }

    //Mudar da tela de inicio do jogo, para a tela do jogo
    public void IniciaJogo()
    {
        //Ir para a cena do jogo
        SceneManager.LoadScene("SampleScene");
    }
}
