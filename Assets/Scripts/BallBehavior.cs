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
        rb.AddForce(Vector2.down * force);
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
        currentSpeed = ballVelocity.magnitude;
        currentDirection = Vector3.Reflect(ballVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = currentDirection * Mathf.Clamp(currentSpeed,speedMin, speedMax);
        oldVelocity = rb.velocity;
        isLaunched = true;
    }


}
