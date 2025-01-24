using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fishpatrol : MonoBehaviour
{
    [SerializeField] float maxdist;
    Vector3 direction;
    [SerializeField] float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 3);
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (i == 1)
            direction = Vector3.left + Vector3.up;
        else
        {
            direction = Vector3.right + Vector3.up;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "tri" || collision.gameObject.name == "tri2")
        {
            //Debug.Log("hit");
            direction = -direction;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            direction = -direction;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);


        }
    }
}