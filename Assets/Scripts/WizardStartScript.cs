using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStartScript : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Animator animator;

    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        animator.Play("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateFireball()
    {
        fireballPrefab.transform.position = transform.position;
        Instantiate(fireballPrefab);
        
    }

    public void AllowMovement()
    {
        player.constraintsMovement = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("NextLevel");
        }
    }
}
