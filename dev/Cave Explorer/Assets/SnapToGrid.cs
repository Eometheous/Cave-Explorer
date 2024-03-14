using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < .5) {
            Vector2 positionInteger = new(Mathf.RoundToInt(rb.transform.position.x), Mathf.RoundToInt(rb.transform.position.y));
            rb.transform.position = positionInteger;
        }
    }
}
