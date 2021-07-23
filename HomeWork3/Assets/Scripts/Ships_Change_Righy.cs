using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ships_Change_Righy : MonoBehaviour
{
    public Button yourButton;

    public GameObject[] ships;

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
                ships[i].SetActive(false);
                if (ships[i] == ships[ships.Length - 1])
                {
                    ships[0].SetActive(true);
                    break;
                }
                if (ships[i] != ships[ships.Length - 1])
                {
                    ships[i + 1].SetActive(true);
                    break;
                }
            }
        }
    }
}
