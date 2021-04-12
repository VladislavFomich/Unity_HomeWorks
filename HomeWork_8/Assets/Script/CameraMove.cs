using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject character;
   
    void FixedUpdate()
    {
        var playerPos = character.transform.position.x;
        transform.position =  new Vector3 (playerPos, transform.position.y, transform.position.z);
    }
}
