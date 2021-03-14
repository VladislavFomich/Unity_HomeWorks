using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Colore_Change : MonoBehaviour
{
    public GameObject[] ships;

    public Material newMaterial; 

    public Button yourButton;


    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i].activeSelf)
            {
                ships[i].GetComponent<MeshRenderer>().material = newMaterial;
            }
        }
    }
}
