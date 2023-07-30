using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextPhase : MonoBehaviour
{
    public GameObject PressX;
    public string Next;
    bool nestpossible;
    private GameObject coveira;
    void Start()
    {
        nestpossible = false;
        coveira = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) ||  coveira.GetComponent<MobileControls>().jump == true) && nestpossible == true)
            SceneManager.LoadScene(Next);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PressX.SetActive(true);
            nestpossible = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PressX.SetActive(false);
            nestpossible = false;
        }
    }
}
