using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_firtsFloor : MonoBehaviour
{
   public GameObject floor3;
    public GameObject player;

    public GameObject lightFirst;
    public GameObject lightSecond;

    public AudioClip clip;
    public AudioSource source;

    Vector3 firstPosition = new Vector3(5.611999988555908f, 12.079400062561036f, -2.8499999046325685f); //не самое изящное решение:)
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.name == player.name)
        {
            lightFirst.SetActive(false);
            lightSecond.SetActive(true);
            source.PlayOneShot(clip);
            if (gameObject.transform.position != firstPosition)
            {
                Debug.Log("Телепортация третьего этажа!");
                floor3.transform.position = new Vector3(floor3.transform.position.x, floor3.transform.localPosition.y + 29.4f, floor3.transform.position.z);
            }
        }
    }
}
