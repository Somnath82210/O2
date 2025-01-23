using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float force;
    [SerializeField] playerinfo p;
    float t = 0.0f;
    Rigidbody2D rb;
    SpriteRenderer s;
    Animator a;
    bool val;
    // Start is called before the first frame update
    void Start()
    {
        p.oxlevel = 100f;
        p.stop = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        s = gameObject.GetComponent<SpriteRenderer>();
        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if walls keep moving
        if (!p.stop)
        {
            //player movement
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            //when player collides with fish/wall
            if (val)
            {

                playerhit();

            }

            //depleting o2 level
            oxygendegen();


            //checking if o2 runs out
            if (p.oxlevel < 0)
            {
                p.stop = true;
                death();
            }
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.layer == 8)
        {
            //if (p.oxlevel < 100)
            //{
            //    if (p.oxlevel >= 95)
            //    {
            //        p.oxlevel += 100 - p.oxlevel;
            //    }
            //    else
            //    {
            //        p.oxlevel += 5f;
            //    }
                
            //}

           

            Destroy(collision.gameObject);
        }
        else
        {
            val = true;


             p.oxlevel -= 5f;
       
        }
        
        if (collision.gameObject.name == "wall")
        {
            rb.AddForce(Vector2.right*force,ForceMode2D.Impulse);
            Debug.Log("hit");
        }
        else if (collision.gameObject.name == "wall2")
        {
            Debug.Log("hit");
            rb.AddForce(Vector2.left * force, ForceMode2D.Impulse);
        }
    }

    void playerhit()
    {
        s.enabled = false;
        t += Time.deltaTime;
        if (t > 0.3f)
        {
            s.enabled = true;
            val = false;
            t = 0.0f;
        }
    }

    void oxygendegen()
    {
        p.oxlevel = p.oxlevel - p.deplespeed * Time.deltaTime;
        Debug.Log(p.oxlevel);
    }

    void death()
    {

        if (!s.enabled)
        {
            s.enabled = true;
        }

        a.SetBool("isdead", true);
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        rb.constraints &= ~RigidbodyConstraints2D.FreezeRotation;
        s.sortingOrder = 2;

        //turn player layer to fishes
        gameObject.layer = 6;
    }

}
