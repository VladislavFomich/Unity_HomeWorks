using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ShellsPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // GameObject shoot = Instantiate(ShellsPrefab, transform.position, transform.rotation) as GameObject;         
          //  BulletManager.Instantiate(transform.position, Quaternion.Euler(0f,0f,0f));
        }
    }
}
