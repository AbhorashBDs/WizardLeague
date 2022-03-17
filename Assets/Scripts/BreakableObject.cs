using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    public float hitNeeded;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (hitNeeded == 0) 
            {
                Debug.Log("LaunchAnimation");
                Destroy(gameObject);
            }
        }
    }

}
