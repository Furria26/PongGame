using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBonce : MonoBehaviour
{
    public BallMovement ballMovement; // used for "InscreaseHitCounter" function in ballMouvement
    public ScoreManager scoreManager;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position; // to get the position of the ball 
        Vector3 racketPosition = collision.transform.position; // to getting the position of the object our ball had collision with 
        float racketHeight = collision.collider.bounds.size.y; // For know which part of the racket did the ball hit 

        float positionX = 1;
        if (collision.gameObject.name == "Player1")
        {
            positionX = 1; // Player 1
        }else{
            positionX = -1; // Player 2
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight; // For have the position Y

        ballMovement.InscreaseHitCounter(); // we call IInscreaseHitCounter
        ballMovement.MoveBall(new Vector2(positionX, positionY)); // we send to MoveBall (positionX, positionY) 
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "RightBorder")
        {
            scoreManager.Player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if(collision.gameObject.name == "LeftBorder")
        {
            scoreManager.Player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }

    }
}
