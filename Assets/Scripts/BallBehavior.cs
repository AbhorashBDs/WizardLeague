using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    private Vector3 ballVelocity;

    public float force;
    public float speedMin;
    public float speedMax;

    private float currentSpeed;
    private Vector3 currentDirection;
    private Vector3 oldVelocity;

    private bool isLaunched = false;


    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Force");
        rb.AddForce(Vector2.down * force);
        Debug.Log(rb.velocity);
    }
    // Update is called once per frame
    void Update()
    {
        

        ballVelocity = rb.velocity;
        //if (ballVelocity.magnitude < speedMin && isLaunched == true)
        //{
        //    Debug.Log("speedIsNotGood" + ballVelocity.magnitude);
        //    rb.velocity = currentDirection * Mathf.Clamp(currentSpeed, speedMin, speedMax);
        //}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Calculate the reflection of the ball
        currentSpeed = ballVelocity.magnitude;
        currentDirection = Vector3.Reflect(ballVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = currentDirection * Mathf.Clamp(currentSpeed,speedMin, speedMax);

        //Tentative de calcul d'un angle mais Atan2 ne semble pas fonctionner
        //Debug.Log("current direction" + currentDirection);
        //Debug.Log("ball velocity" + ballVelocity);

        //float angle2 = Vector2.SignedAngle(ballVelocity, currentDirection);
        //Debug.Log("signedangle"+angle2);
        ////Get the fireball to face the right direction
        ////Vector3 targ = currentDirection;
        ////targ.z = 0f;
        ////Vector3 objectPos = transform.position;
        ////targ.x = targ.x - objectPos.x;
        ////targ.y = targ.y - objectPos.y;
        //float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg;
        //Debug.Log("angle" + angle);
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        //oldVelocity = rb.velocity;
        isLaunched = true;
    }


}
