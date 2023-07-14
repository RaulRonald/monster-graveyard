using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaltEnemy : MonoBehaviour
{
    Rigidbody2D RigSpirtDefalt;
    public GameObject RayMoveSpiritDefalt;
    public bool terrestre,saltitante,Direita;
    SpriteRenderer SpriteSpiritDefalt;
    public float SpiritDefaltSpeed,RangePlayer;
    private GameObject Player,GameController;
    // Start is called before the first frame update
    void Start()
    {
        RigSpirtDefalt = GetComponent<Rigidbody2D>();
        SpriteSpiritDefalt = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(terrestre)
        SpiritDefaltMove();
        else
        {
            SpiritDefaltFly();
        }
        if (saltitante)
            SpiritDefaltJumper();

    }
    void SpiritDefaltJumper()
    {
        if (transform.rotation.y != 0)
        {
            Direita = false;
        }
        else
            Direita = true;
        RaycastHit2D hitPlayer;
        if (Direita == true)
            hitPlayer = Physics2D.Raycast(RayMoveSpiritDefalt.transform.position, Vector2.right);
        else
            hitPlayer = Physics2D.Raycast(RayMoveSpiritDefalt.transform.position, Vector2.left);
        if (hitPlayer.collider.tag == "Player" && RigSpirtDefalt.velocity.y == 0 && hitPlayer.distance < 5f)
        {
            if (Direita == true)
                RigSpirtDefalt.AddForce(new Vector2(1f, 5f), (ForceMode2D.Impulse));
            else
                RigSpirtDefalt.AddForce(new Vector2(-1f, 5f), (ForceMode2D.Impulse));

        }

    }
    void SpiritDefaltFly()
    {
        if(Player.transform.position.x > transform.position.x - RangePlayer && Player.transform.position.x < transform.position.x + RangePlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, SpiritDefaltSpeed * Time.deltaTime);
        }
        
    }
    void SpiritDefaltMove()
    {
        RigSpirtDefalt.velocity = new Vector2(SpiritDefaltSpeed, RigSpirtDefalt.velocity.y);
        RaycastHit2D hitGround = Physics2D.Raycast(RayMoveSpiritDefalt.transform.position, -Vector2.up);
        RaycastHit2D hitWall;
        if (Direita == false)
        hitWall = Physics2D.Raycast(RayMoveSpiritDefalt.transform.position, Vector2.right);
        else
        hitWall = Physics2D.Raycast(RayMoveSpiritDefalt.transform.position, Vector2.left);
        Debug.DrawRay(RayMoveSpiritDefalt.transform.position, Vector2.right * hitWall.distance);
        if ((hitWall.distance <= 0.5 || hitGround.distance > 1) && hitWall.collider.tag != "Player") {
            SpiritDefaltSpeed = SpiritDefaltSpeed * -1;
            if (transform.rotation.y != 0) {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                Direita = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
                Direita = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ataque")
        {
            GameController.GetComponent<GameController>().GanharAlmas(1);
            SpriteSpiritDefalt.color = Color.red;
            Destroy(gameObject,0.25f);
        }
    }
}
