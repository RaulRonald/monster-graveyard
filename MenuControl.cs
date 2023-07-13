using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public string nextphase;
    public void NextSceneLoad()
    {
        SceneManager.LoadScene(nextphase);
    }
}
