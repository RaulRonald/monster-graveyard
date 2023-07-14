using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextPhase : MonoBehaviour
{
    public GameObject PressX;
    public string Next;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
            SceneManager.LoadScene(Next);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PressX.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PressX.SetActive(false);
    }
}
