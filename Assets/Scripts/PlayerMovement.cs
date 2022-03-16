using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    public Animator animator;

    private Vector2 moveDirection = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        float shieldMoveX = Input.GetAxisRaw("Horizontal2");
        float shieldMoveY = Input.GetAxisRaw("Vertical2");
        Debug.Log(shieldMoveY+ shieldMoveX);

        moveDirection = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("Horizontal", shieldMoveX);
        animator.SetFloat("Vertical", shieldMoveY);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }
}
