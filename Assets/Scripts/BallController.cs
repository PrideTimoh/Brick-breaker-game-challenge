using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
      public float maxHorizontalSpeed;
      public float vertSpeed;
      public bool ballActive;
      public Transform startPoint;
      private Rigidbody2D theRB;
      private GameMan theGM;

      private BrickController brickC;
    // Start is called before the first frame update
    void Start()
    {

        theRB = GetComponent<Rigidbody2D>();
        theGM = FindObjectOfType<GameMan>();
     //   theRB.velocity = new Vector2(vertSpeed, vertSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if(!ballActive)
        {
            theRB.velocity = Vector2.zero;
            transform.position = startPoint.position;
        }
        if(theRB.velocity.x > maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(maxHorizontalSpeed, theRB.velocity.y);
        }
        else if(theRB.velocity.x < -maxHorizontalSpeed)
        {
            theRB.velocity = new Vector2(-maxHorizontalSpeed, theRB.velocity.y);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Brick"))
       {
          // Destroy(other.gameObject);
          brickC = other.gameObject.GetComponent<BrickController>();
          brickC.DestroyBrick();
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Respawn"))
       {
           ballActive = false;
           theGM.RespawnBall();
       }
    }
    public void ActivateBall()
    {
        ballActive = true;
        theRB.velocity = new Vector2(vertSpeed, vertSpeed);
    }
}
