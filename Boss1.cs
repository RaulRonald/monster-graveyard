using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public int lifes;
    public Sprite chorando, normal;
    bool spawned;
    public GameObject sangue,raizprefab,spiritfly,raleumofi;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        lifes = 3;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject raizes = GameObject.FindGameObjectWithTag("raiz");
        if (raizes == null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = chorando;
            sangue.GetComponent<Transform>().position = new Vector3(sangue.GetComponent<Transform>().position.x, sangue.GetComponent<Transform>().position.y + 0.5f * Time.deltaTime, sangue.GetComponent<Transform>().position.z);
            if(sangue.GetComponent<Transform>().position.y >= 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = normal;
                sangue.GetComponent<Transform>().position = new Vector3(sangue.GetComponent<Transform>().position.x,0, sangue.GetComponent<Transform>().position.z);
                lifes--;
                if (lifes <= 0)
                {
                    raleumofi.SetActive(true);
                    Destroy(gameObject);

                }
                else
                {
                    Instantiate(raizprefab, new Vector3(6.6f,0.35f,0f), transform.rotation);
                    Instantiate(raizprefab, new Vector3(-6.6f, 0.35f, 0f), transform.rotation);
                    Instantiate(raizprefab, new Vector3(10f, 1.3f, 0f), transform.rotation);
                    Instantiate(raizprefab, new Vector3(-10f, 1.3f, 0f), transform.rotation);
                }
            }
        }
        if (spawned == false)
        {
            spawned = true;
            StartCoroutine(spawnghosts()); 
        }
    }
    IEnumerator spawnghosts()
    {
        yield return new WaitForSeconds(3f);
        Vector3 position = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 0), UnityEngine.Random.Range(0, 0));
        Instantiate(spiritfly, position, Quaternion.identity);
        spawned = false;
    }
}
