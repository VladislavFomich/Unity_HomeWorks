using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownScript : MonoBehaviour
{
    public Dropdown drop;
    public GameObject[] texts;
    // Start is called before the first frame update
    void Start()
    {
        drop.onValueChanged.AddListener(delegate
        {
            dropValueChange(drop);
        });
    }

    public void dropValueChange(Dropdown sender)
    {
        if (sender.value == 0)
        {
            texts[0].SetActive(true);
            texts[1].SetActive(false);
            texts[2].SetActive(false);
        }
        if (sender.value == 1)
        {
            texts[0].SetActive(false);
            texts[1].SetActive(true);
            texts[2].SetActive(false);
        }
        if (sender.value == 2)
        {
            texts[0].SetActive(false);
            texts[1].SetActive(false);
            texts[2].SetActive(true);
        }
        // Debug.Log(sender.value);
    }
    // Update is called once per frame
  //  void Update()
  //  {
        
  //  }
}
