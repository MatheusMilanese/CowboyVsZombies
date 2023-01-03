using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    private Vector3 mousePos, mouseWorldPos;
    private Vector2 direction;

    void Update()
    {
        OnRotate();
    }

    void OnRotate(){
        mousePos = Input.mousePosition;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(mouseWorldPos + " " + mousePos);
    }
}
