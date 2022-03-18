using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    public CircleCollider2D col;

    private void Start()
    {
        speed += SpawnEnemies.speedIncrease;
    }
    void Update()
    {
        transform.Translate(new Vector2(0, -speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Floor"))
        {  
            UIManager.instance.TakeLife(); 
            Destroy(gameObject);
            
        }      
    }
}
