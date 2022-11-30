using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public Sprite Perfil;
    public string[] DialogoNpc;
    public string nomeAutor;

    public LayerMask PlayerLayer;
    public float radious;

    bool jogadorperto;


    private ControleDialogo cd;

    private void Start()
    {
        cd = FindObjectOfType<ControleDialogo>();
    }

    
   private void FixedUpdate()
    {
        Interagir();
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && jogadorperto)
        {
            cd.Fala(DialogoNpc);
        }
    }
    public void Interagir()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position,radious,PlayerLayer);
        {
            if(hit != null)
            {
                jogadorperto = true;
            }
            else
            {
                jogadorperto = false;
            }

        }
    }

     private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,radious);
    }
}
