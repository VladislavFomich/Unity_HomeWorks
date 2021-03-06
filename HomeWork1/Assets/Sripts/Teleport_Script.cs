using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Teleport_Script : MonoBehaviour
{
    public GameObject prefab;
    private float timer = 0.0f;
    public float waitTIme = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTIme)
        {
                var position = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f) * Time.deltaTime);
            transform.position = position;
                timer = timer - waitTIme;
        }
    }
}
