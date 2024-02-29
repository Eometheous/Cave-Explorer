using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging) {
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = clickedPosition + offset;
        }
       
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    void OnMouseUp() 
    {
        dragging = false;
    }
}
