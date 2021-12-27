using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
    private Player player;
    public float TimebtwHit;
    public float hittime;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();   
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (TimebtwHit < 0) 
            {
                player.TakeDamage(1);
                TimebtwHit = hittime;
            }
            else if (TimebtwHit > 0)
            {
                TimebtwHit -= Time.deltaTime;
            }    
            
        }
    }

}
