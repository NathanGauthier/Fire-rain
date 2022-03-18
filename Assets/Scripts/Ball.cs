using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public bool isLaunched = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isLaunched)
        {
            UIManager.instance.AddScore();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
