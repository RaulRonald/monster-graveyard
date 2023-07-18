using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    static int souls,Life;
    public Text Soulstext,LifeText;
    private GameObject Player;
    public GameObject GameOver;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            Life = 5;
            souls = 0;
        }
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
        if(souls == 15)
        {
            Life++;
            souls = 0;
        }
        Soulstext.text = "SOULS: " + souls.ToString();
        LifeText.text = "LIFES: " + Life.ToString();
        if(Life <= 0)
        {
            Player.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(Player, 0.5f);
            GameOver.SetActive(true);
        }
    }
}
