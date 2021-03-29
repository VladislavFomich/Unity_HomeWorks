using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    Light flickerLight;
    public float minValTime;
    public float maxValueTime;
    // Start is called before the first frame update
    void Start()
    {
        flickerLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minValTime, maxValueTime));
            flickerLight.enabled = !flickerLight.enabled;
        }
    }
}
