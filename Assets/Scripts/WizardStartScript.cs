using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStartScript : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Animator animator;

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
        Destroy(gameObject);
    }
}
