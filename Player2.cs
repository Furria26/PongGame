using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementY = Input.GetAxisRaw("Vertical2");

        racketDirection = new Vector2(0, movementY).normalized;
    }

    private void FixedUpdate() {
        rb.velocity = racketDirection * racketSpeed;
    }
}
