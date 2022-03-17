using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    public float hitNeeded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            hitNeeded -= 1;
            if (hitNeeded <= 0) 
            {
                animator.SetTrigger("Destroy");
            }
        }
    }

    public void DestroyFences()
    {
        //Destroy(gameObject);


        GetComponent<Collider2D>().enabled = false;
    }

}
