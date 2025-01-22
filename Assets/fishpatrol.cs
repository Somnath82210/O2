using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fishpatrol : MonoBehaviour
{
    [SerializeField]float maxdist;
    //Ray r;
    Vector3 direction;
    [SerializeField] float speed;
    //[SerializeField]int l;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, 3);

        if(i==1)
         direction = Vector3.left+Vector3.up;
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
        //r = new Ray(transform.position, -transform.right);

        //RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right,maxdist,1<<l);

        //Debug.Log(hit.collider.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "tri"|| collision.gameObject.name == "tri2")
        {
            direction = -direction;
            transform.localScale= new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
        }
    }
}
