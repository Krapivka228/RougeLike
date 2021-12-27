using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed;

    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite Heart;
    public Sprite EmptyHeart;

    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (health > numOfHearts) 
        {
            health = numOfHearts;
        }
        for(int i = 0; i < hearts.Length; i ++)
        {   
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = Heart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (health < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }   
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler; 
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}   
