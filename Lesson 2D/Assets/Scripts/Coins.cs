using NUnit.Framework.Internal.Commands;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Coins : MonoBehaviour
{
    
    
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
         

        }
    }
    public void OnCollisionEnter2D (Collision2D Collision)
    {
        if (Collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
           
            
        }
    }

}
