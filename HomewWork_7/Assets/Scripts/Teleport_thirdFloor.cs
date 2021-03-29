using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_thirdFloor : MonoBehaviour
{
    public GameObject floor2;
    public GameObject player;

    public GameObject lightThird;
    public GameObject lightFirst;

    public AudioClip clip;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            source.PlayOneShot(clip);
            lightThird.SetActive(false);
            lightFirst.SetActive(true);
            Debug.Log("Телепортация второго этажа!");
            floor2.transform.position = new Vector3(floor2.transform.position.x, floor2.transform.localPosition.y + 29.4f, floor2.transform.position.z);
        }
    }
}
