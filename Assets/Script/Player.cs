using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Veloc;
    public float forcaPulo;
    private Rigidbody2D rig;

    private Animator anim;

    public bool estaPulando;
    public bool puloDublo;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // ficar chamando os metodos todos os segundos 
    void Update()
    {
        andar();
        pular();
    }

    void andar()
    {
        /*antiga funções para fazer o personagem andar ao se apertar o botão para movimento
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);

        Move o personagem em um posição
        transform.position += movement * Time.deltaTime * Veloc;*/

        // Nova funções para fazer o personagem andar ao se apertar o botão para movimento
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Veloc, rig.velocity.y);

        //Animação da ação correndo 
        if(movement > 0f)
        {
        anim.SetBool("Run",true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        //Animação correndo, mas para o outro lado 
        if(movement < 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        //parar a animação quando o personagem parar de andar/correr
        if(movement == 0f)
        {
            anim.SetBool("Run", false);
        }

    }

    void pular()
    {
        //Fazer o personagem pular quando o botão 'pular' for pressionado 
        if(Input.GetButtonDown("Jump"))
        {
            //codigo de ação para fazer o personagem pular duas vezes
            if(!estaPulando)
            {
            rig.AddForce(new Vector2(0f,forcaPulo), ForceMode2D.Impulse);
                puloDublo = true;
            }
            else
            {
                if(puloDublo)
                {
                     rig.AddForce(new Vector2(0f,forcaPulo), ForceMode2D.Impulse);
                puloDublo = false;
                }
            }
        }
    }

//Mostar tela de fim de jogo caso jogador enconste no obstaculo lança
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            estaPulando = false;
        }

        if(collision.gameObject.tag == "Spike")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

   
    //Desativar o pulo duplo caso personagem enconste no chão 
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            estaPulando = true;
        }
    }
}
