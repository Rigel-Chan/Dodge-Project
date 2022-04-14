using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float horizontal;
    float vertical;
    public float health = 100;
    public float speed = 5f;
    public int points = 0;
    public bool dashed = false;
    public int dashPower = 50;
    public ParticleSystem particles;
    bool collided = false;
    public AudioClip deathSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(horizontal!=0&&vertical!=0)
        {
            rb.velocity = new Vector2(horizontal * speed/1.3f, vertical * speed/1.3f);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        Dash();
    }

    public void Update()
    {
        if (health <= 0)
        {
            health = 0;
            if (collided == false)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                collided = true;
                tag = "Untagged";
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                boom();
                Destroy(this.gameObject, particles.main.duration);
            }
        }
    }
    void boom()
    {
        particles.Play();
    }

    public void Dash()
    {
        if (Input.GetKey(KeyCode.Space) && dashed == false)
        {
            if (horizontal != 0 && vertical != 0)
            {
                rb.velocity = new Vector2(horizontal * speed * dashPower * Time.deltaTime/1.35f, vertical * speed * dashPower * Time.deltaTime/1.35f);
                
                StartCoroutine(DashTimer());    
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed * dashPower * Time.deltaTime, vertical * speed * dashPower * Time.deltaTime);
                
                StartCoroutine(DashTimer());
            }

/*            if (horizontal > 0)
            {
                Debug.Log("dssss");
                
            }
            if (horizontal < 0)
            {
                rb.velocity = new Vector2(horizontal * speed * dashPower * Time.deltaTime, vertical * speed);
            }
            if (vertical > 0)
            {
                rb.velocity = new Vector2(horizontal * speed, vertical * speed * dashPower * Time.deltaTime);
            }
            if (vertical < 0)
            {
                rb.velocity = new Vector2(horizontal * speed, vertical * speed * dashPower * Time.deltaTime);
            }*/
        }
    }

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(0.07f);
        dashed = true;
        yield return new WaitForSeconds(3);
        dashed = false;
    }
/*    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag( "Enemy"))
        {
            health -= 100*Time.deltaTime;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Laser"))
        {
            health -= 100;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            health += 20;
            if (health > 100)
            {
                health = 100;
            }
        }
        if (collision.CompareTag("Points"))
        {
            points += 100;
        }
    }*/
}
