using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coveira : MonoBehaviour
{
    public float velocidade, forcapulo;
    Rigidbody2D RigCoveira;
    private bool pulando,atacando;
    public GameObject RayGroundCoveira, CorrentePrefab,GameController;
    Animator anime;
    void Start()
    {
        atacando = false;
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
        if(!atacando)
        AtkCoveira();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spirit")
        {
            GameController.GetComponent<GameController>().PerderVida(1);
        }
    }
    void AtkCoveira()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            anime.SetTrigger("Atacando");
            if (transform.eulerAngles.y == 0)
            {
                GameObject correntada = Instantiate(CorrentePrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
                atacando=true;
                correntada.transform.parent = transform;
                StartCoroutine(DestroyCorrentada(correntada, 0.25f));
            }
            else
            {
                GameObject correntada = Instantiate(CorrentePrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
                atacando = true;
                correntada.transform.parent = transform;
                StartCoroutine(DestroyCorrentada(correntada, 0.25f));
            }
        }
    }
    IEnumerator DestroyCorrentada(GameObject correntada, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(correntada);
        atacando = false;
    }
    void MoveCoveira()
    {

        RigCoveira.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, RigCoveira.velocity.y);
    }
    void JumpCoveira()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(RayGroundCoveira.transform.position, -Vector2.up);
        if (Input.GetKeyDown(KeyCode.Space) && pulando == false)
        {
            RigCoveira.AddForce(new Vector2(0, forcapulo), (ForceMode2D.Impulse));
        }
        if(hitGround.distance <= 0.5)
            pulando = false;
            else
        if (hitGround.distance > 0.5)
            pulando = true;
        
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
}
