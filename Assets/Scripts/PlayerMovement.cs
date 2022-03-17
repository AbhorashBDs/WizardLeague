using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer sprRender;
    private Animator playerAnimator;

    private Vector2 moveDirection = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRender = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //if (moveX > 0)
        //{
        //    sprRender.flipX = true;
        //}
        //else if (moveX < 0)
        //{
        //    sprRender.flipX = false;
        //}

        float shieldMoveX = Input.GetAxisRaw("Horizontal2");
        float shieldMoveY = Input.GetAxisRaw("Vertical2");

        if (shieldMoveX > 0)
        {
            sprRender.flipX = true;
        }
        else if (shieldMoveX < 0)
        {
            sprRender.flipX = false;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveX != 0)
        {
            playerAnimator.SetFloat("Movement_Speed", Mathf.Abs(moveX));
        }
        else playerAnimator.SetFloat("Movement_Speed", Mathf.Abs(moveY));

        animator.SetFloat("Horizontal", shieldMoveX);
        animator.SetFloat("Vertical", shieldMoveY);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }
}
