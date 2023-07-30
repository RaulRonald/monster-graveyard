using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rose :  MonoBehaviour
{
    public GameObject bullet;
    private bool atacando;
    Animator anime;
    // Update is called once per frame
    private void Start()
    {
        anime = GetComponent<Animator>();
    }
    void Update()
    {
        if (atacando == false)
        {
            StartCoroutine(Ataque());
            
        }
        }
    IEnumerator Ataque()
    {
        atacando = true;
        GetComponent<DefaltEnemy>().terrestre = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        anime.SetTrigger("RoseAtk");
        GameObject Rbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        GameObject Lbullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        Rbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        Lbullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        Lbullet.GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
        Destroy(Rbullet, 2);
        Destroy(Lbullet, 2);
        yield return new WaitForSeconds(1.5f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<DefaltEnemy>().SpiritDefaltSpeed, 0);
        GetComponent<DefaltEnemy>().terrestre = true;
        yield return new WaitForSeconds(8);
        atacando = false;
    }
}
