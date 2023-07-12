using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coveira : MonoBehaviour
{
    public float velocidade;
    public float forcapulo;
    Rigidbody2D RigCoveira;
    private bool pulando;
    Animator anime;
    void Start()
    {
        pulando = false;
        RigCoveira = GetComponent<Rigidbody2D>();
        anime = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCoveira();
        JumpCoveira();
        AnimacaoCoveira();
    }
    void MoveCoveira()
    {
        RigCoveira.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, RigCoveira.velocity.y);
    }
    void JumpCoveira()
    {
        if(!pulando && Input.GetKeyDown(KeyCode.Space))
        {
            RigCoveira.AddForce(new Vector2(0,forcapulo),(ForceMode2D.Impulse));
            pulando = true;
        }
    }
    void AnimacaoCoveira()
    {
        if (pulando)
        {
            anime.SetBool("Pulando", true);
        }
        else
            anime.SetBool("Pulando", false);
        if(Input.GetAxis("Horizontal") != 0)
        {
            anime.SetBool("Andando", true);
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }
            else
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
        }
        else
        {
            anime.SetBool("Andando", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            pulando = false;
    }
}
