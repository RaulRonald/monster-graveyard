using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Coveira;
    void Start()
    {
        Coveira = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Coveira.transform.position.x, Coveira.transform.position.y + 1, transform.position.z);
    }
}
