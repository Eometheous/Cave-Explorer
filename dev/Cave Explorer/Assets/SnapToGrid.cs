using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool colliding;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliding = false;
    }

    void FixedUpdate()
    {
        // if ((rb.velocity.magnitude < .5 && !colliding) || rb.velocity.magnitude == 0) {
        //     Vector2 positionInteger = new(Mathf.RoundToInt(rb.transform.position.x), Mathf.RoundToInt(rb.transform.position.y));
        //     rb.transform.position = positionInteger;
        // }
    }

    void OnCollisionEnter2D(Collision2D other) {
        colliding = true;
    }

    void OnCollisionExit2D(Collision2D other) {
        colliding = false;
    }
}
