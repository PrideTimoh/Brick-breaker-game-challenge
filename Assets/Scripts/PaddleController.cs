using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float speed;

    public float direction;
    public float adjustSpeed;
    public Transform rightLimit;
    public Transform leftLimit;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    
       if(Input.GetKey(KeyCode.D))
       {
           transform.position = new Vector2(transform.position.x  + (speed * Time.deltaTime), transform.position.y);
           direction = 1;
       }
       else if(Input.GetKey(KeyCode.A))
       {
           transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y );
           direction = -1;
       }
       else{
           direction = 0;
       }

       if(transform.position.x <= leftLimit.position.x)
       {
           transform.position = new Vector3(leftLimit.position.x, transform.position.y);
       }
       else if(transform.position.x >= rightLimit.position.x)
       {
           transform.position = new Vector2(rightLimit.position.x, transform.position.y);
       }
         

}

        
      

    void OnCollisionExit2D(Collision2D other)
    {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x + (direction * adjustSpeed), other.rigidbody.velocity.y * 1.1f);
        Debug.Log(other.rigidbody.velocity);
    }
}
