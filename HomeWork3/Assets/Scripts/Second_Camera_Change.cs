using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Second_Camera_Change : MonoBehaviour
{
    public Button yourButton;
    public GameObject cam;
    public Vector3 position;
    public Vector3 rotation;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        cam.transform.position = position;
        cam.transform.eulerAngles = rotation;
    }

}
