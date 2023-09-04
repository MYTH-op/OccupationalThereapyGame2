using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolition : MonoBehaviour
{
    // Start is called before the first frame update
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag=="Tumbler")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
