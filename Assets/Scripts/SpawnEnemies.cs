using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject fireBall; 
    
    private float timeBtwSpawn = 2f;
    public float startTimeBtwSpawn;
    private float delayDecrease = 0.01f;
    private float speedMultiplier = 0.01f;

    public static float speedIncrease = 0f;

    private void Update()
    {     
        if(timeBtwSpawn <= 0f)
        {
            Vector2 pos = new Vector2(Random.Range(-8, 9), 7f);
            Instantiate(fireBall, pos, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            
            if(startTimeBtwSpawn > 0.5f)
            {
                startTimeBtwSpawn -= delayDecrease;
            }

            if(speedIncrease < 1.5f)
            {
                speedIncrease += speedMultiplier;
            }
                    
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
