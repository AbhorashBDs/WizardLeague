using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WizardStartScript : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Animator animator;

    public PlayerMovement player;
    public float offsetBall;

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
        fireballPrefab.transform.position = new Vector2(transform.position.x, transform.position.y+offsetBall);
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
            if ((SceneManager.GetActiveScene().buildIndex + 1) <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else SceneManager.LoadScene(0);
        }
    }
}
