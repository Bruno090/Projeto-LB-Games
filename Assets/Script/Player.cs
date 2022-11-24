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

    // Update is called once per frame
    void Update()
    {
        andar();
        pular();
    }

    void andar()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * Veloc;


        if(Input.GetAxis("Horizontal") > 0f)
        {
        anim.SetBool("Run",true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal")< 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        if(Input.GetAxis("Horizontal")== 0f)
        {
            anim.SetBool("Run", false);
        }

    }

    void pular()
    {
        if(Input.GetButtonDown("Jump"))
        {
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

   
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            estaPulando = true;
        }
    }
}
