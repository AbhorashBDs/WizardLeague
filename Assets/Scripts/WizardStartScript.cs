using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStartScript : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Animator animator;
    public Transform wizardPos;

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
        Instantiate(fireballPrefab);
    }

    public void WizardFlee()
    {
        transform.position = wizardPos.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Debug.Log("NextLevel");
        }
    }
}
