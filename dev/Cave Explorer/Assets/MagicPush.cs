using System;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 clickedPosition;
    Vector3 offset;
    bool clicked;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (clicked) {
            rb.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

    void OnMouseDown()
    {
        clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = rb.transform.position - clickedPosition;
        clicked = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void OnMouseUp() 
    {
        clicked = false;
        SnapToGrid();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (clicked) {
            clicked = false;
            SnapToGrid();
        }
    }

    void SnapToGrid() {
        Vector2 positionInteger = new(Mathf.RoundToInt(rb.transform.position.x), Mathf.RoundToInt(rb.transform.position.y));
        rb.transform.position = positionInteger;
    }
}
