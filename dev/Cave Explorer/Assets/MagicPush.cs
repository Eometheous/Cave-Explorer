using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class Drag : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 clickedPosition;
    
    Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp() 
    {
        force = Camera.main.ScreenToWorldPoint(Input.mousePosition) - clickedPosition;
        rb.AddForce(force * 10000);
    }
}
