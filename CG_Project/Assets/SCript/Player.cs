using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed = 50f, maxspeed = 3, maxjump = 4, jumpPow = 220f;
    public bool grounded = true, faceright = true, doublejump = false;

    public Rigidbody2D r2;
    public Animator anim;

    // ThanhND : Create HP
    public int ourHealth;
    public int maxHealth = 5;

    public GameObject bullet;
    public float bulletspeed = 5;
    public float bullettimer = 0;
    public float shootinterval = 0.5f;

	// Use this for initialization
	void Start () {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        ourHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Shoot();
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x, maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2(r2.velocity.x, -maxjump);

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }

        // ThanhND : check HP
        if (ourHealth <= 0)
        {
            Death();
        }

    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    // ThanhND : when player died (hp < 2) return Game
    public void Death()
    {
        Debug.Log("Player Death ");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Damage(int damage)
    {
        Debug.Log("manh.lv Player Damage " + damage);
        ourHealth -= damage;
        // gameObject.GetComponent<Animation>().Play("redFlash");
    }

    public void Knockback(float Knockpow, Vector2 Knockdir)
    {
        Debug.Log("manh.lv Player Knockback ");
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdir.x * -30, Knockdir.y * Knockpow));
    }

    public void Shoot()
    {
        Debug.Log("Player Shoot");
        bullettimer += Time.deltaTime;

        if (bullettimer >= shootinterval)
        {
            Vector3 position = transform.position;
            if (faceright)
            {
                GameObject bulletclone;
                position.x += 1;
                Vector2 direction = position - transform.position;
                direction.Normalize();
                bulletclone = Instantiate(bullet, position, transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }

            if (!faceright)
            {
                GameObject bulletclone;
                position.x -= 1;
                Vector2 direction = position - transform.position;
                direction.Normalize();
                bulletclone = Instantiate(bullet, position, transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;

                bullettimer = 0;
            }
        }
        
    }
}
