using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonUI : MonoBehaviour
{
    public void ButtonPress()
    {
        Debug.Log("button press");
    }

    public void Update() {
        if (Input.GetKeyUp(KeyCode.W))
        {
            ButtonPress();
        }
    }
}
