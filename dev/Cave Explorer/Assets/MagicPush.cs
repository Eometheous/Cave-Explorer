using System;
using UnityEngine;

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
        if (Math.Abs(force.x) > Math.Abs(force.y)) force.y = 0;
        else force.x = 0;
        if (rb.CompareTag("Player")) {
            rb.AddForce(force * 100);
        }
        else rb.AddForce(force * 10000);
    }
}
