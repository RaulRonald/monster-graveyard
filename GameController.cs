using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    static int souls,Life;
    public Text Soulstext,LifeText;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        souls = 0;
        Life = 5;
    }
    public void PerderVida(int Dano)
    {
        Life -= Dano;
    }
    public void GanharAlmas(int almas)
    {
        souls += almas;
    }
    // Update is called once per frame
    void Update()
    {
        Soulstext.text = "SOULS: " + souls.ToString();
        LifeText.text = "LIFES: " + Life.ToString();
        if(Life <= 0)
        {
            Player.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(Player, 0.5f);
        }
    }
}
