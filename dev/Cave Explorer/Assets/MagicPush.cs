using System;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 clickedPosition;
    Vector2 force;
    bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked) {
            force = Camera.main.ScreenToWorldPoint(Input.mousePosition) - clickedPosition;
            if (Math.Abs(force.x) > Math.Abs(force.y)) force.y = 0;
            else force.x = 0;
            if (rb.CompareTag("Player")) {
                rb.AddForce(force * 100);
            }
            else rb.AddForce(force * 10000);
            clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clicked = true;
    }

    void OnMouseUp() 
    {
        clicked = false;
    }
}
