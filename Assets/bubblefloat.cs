using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblefloat : MonoBehaviour
{
    //[SerializeField] float speed;
    //float t = 0.0f;
    public float horizontalspeed=0.2f;
    public float verticalSpeed = 1.0f; // Speed at which the bubble moves upward
    public float horizontalSwayRange = 0.5f; // Range of horizontal sway
    public float swaySpeed = 2.0f; // Speed of horizontal sway
    public float lifetime = 5.0f; // Lifetime of the bubble before it is destroyed
    private Vector3 initialPosition;
    private float horizontalSwayOffset;
    Rigidbody2D rb;
    GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        wall = transform.parent.parent.gameObject;
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Save the initial position of the bubble
        initialPosition = transform.position;

        // Randomize the horizontal sway offset to create unique movement for each bubble
        horizontalSwayOffset = Random.Range(0f, 2f * Mathf.PI);

        // Destroy the bubble after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //t += Time.deltaTime;
        //transform.position = new Vector3(Mathf.Sin(t * speed),t*speed, 0);
        // Move the bubble upward
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;

        if (wall.name == "wall")
        {
           
            initialPosition += Vector3.right * horizontalspeed * Time.deltaTime;
        }
        else if (wall.name == "wall2")
        {
          
            initialPosition += Vector3.left * horizontalspeed * Time.deltaTime;
        }
        
        // Add horizontal swaying motion
        float horizontalSway = Mathf.Sin(Time.time * swaySpeed + horizontalSwayOffset) * horizontalSwayRange;
        transform.position = new Vector3(initialPosition.x + horizontalSway, transform.position.y, transform.position.z);

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.name=="wall2"|| collision.gameObject.name == "wall2")
    //    {
    //        Debug.Log(collision.gameObject.name);
    //        rb.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
    //    }
    //}
}
