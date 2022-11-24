using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float Veloc;
   

    public Transform direitaCol;

    public Transform esquerdaCol;

    public Transform PontoCabeca;

    public LayerMask layer;
    private bool colidindo;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Fazer o inimigo se movimentar por uma area determinada
        rig.velocity = new Vector2(Veloc, rig.velocity.y);

        colidindo = Physics2D.Linecast(direitaCol.position,esquerdaCol.position, layer);

        if(colidindo)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            Veloc *= -1f;
        }
    }

    bool playerDestroyed = false;
    // Fazer o personagem morrer ao enconstar no personagem 
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Player")
        {
            //Se o personagem enconstar na cabeça do inimigo, ele morrerá 
            float height = col.contacts[0].point.y - PontoCabeca.position.y;

            if(height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                
                 Destroy(gameObject, 0f);
            }
            else
            {
                //Caso o inimigo enconste nele sem ser na cabeça, o persoangem morrerá 
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
    }
}
