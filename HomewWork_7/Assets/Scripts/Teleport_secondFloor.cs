using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_secondFloor : MonoBehaviour
{
    public GameObject floor1;
    public GameObject player;

    public GameObject lightSecond;
    public GameObject lightThird;

    public AudioClip clip;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        lightSecond.SetActive(false);
        lightThird.SetActive(true);
        source.PlayOneShot(clip);
        if (other.gameObject.name == player.name)
        {
            Debug.Log("Телепортация первого этажа!");
            floor1.transform.position = new Vector3(floor1.transform.position.x, floor1.transform.localPosition.y + 29.4f, floor1.transform.position.z);
        }
    }
}
