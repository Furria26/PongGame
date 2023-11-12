using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed; // Speed of start
    public float extraSpeed; // percentage to multiply to hitCounter
    public float maxExtraSpeed; // Limite percentage 

    public bool player1Start = true;

    private int hitCounter = 0; // Number of hit a player 

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch()); // At the start Launch is read
    }

    public void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1); // Wait 1 second 

        if(player1Start == true)
        {
            MoveBall(new Vector2(-1, 0)); // Direction for the start x = -1 (left)
        }
        else
        {
            MoveBall(new Vector2(1, 0)); // Direction for the start x = 1 (right)
        }
    }

    public void MoveBall(Vector2 direction)
    {
        // The normalized property returns a new vector with the same direction as the original vector, but with a length of 1.
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed; 

        rb.velocity = direction * ballSpeed;
    }

    public void InscreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

}
