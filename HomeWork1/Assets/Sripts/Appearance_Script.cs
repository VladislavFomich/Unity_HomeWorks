using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance_Script : MonoBehaviour
{
    public GameObject[] gameObjects;
    private GameObject instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            int rand = Random.Range(0, gameObjects.Length);
            instance = Instantiate(gameObjects[rand], gameObjects[rand].transform.position, Quaternion.identity);   
        }

    }
}
