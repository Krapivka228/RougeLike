using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timeBtwAttack;
    public float starttimeBtwAttack;
    public int health;
    public float speed;
    public int damage;
    public float stopTime;
    public float startstopTime;
    public float normalspeed;
    private Player player;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalspeed = speed;
    }
    
    private void Update()
    {
        if(stopTime <= 0)
        {
            speed = normalspeed;
        }
        else
        {
            stopTime -= Time.deltaTime;
        }
        if (health == 0)
        {
            Destroy(gameObject);
        }
        if(player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        stopTime = startstopTime;
        health -= damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");         
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
      
    }
    private void FixedUpdate()
    {
        if (speed > 0)
        {
            anim.SetBool("Isrun", true);
        }
        else
        {
            anim.SetBool("Isrun", false);
        }
    }

    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtwAttack = starttimeBtwAttack;
    }
}       

