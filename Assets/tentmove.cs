using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentmove : MonoBehaviour
{
    GameObject wall;
    GameObject obs;
    [SerializeField] float speed;
    Vector3 startpos;
    Vector3 endpos;
    float t = 0.0f;
    float t2 = 0.0f;
    bool val=true;
    bool val2;
    // Start is called before the first frame update
    void Start()
    {
        wall = transform.parent.parent.parent.gameObject;


        startpos = new Vector3(1.8f, transform.localPosition.y, 0);
        endpos = new Vector3(-2, transform.localPosition.y, 0);


    }

    // Update is called once per frame
    void Update()
    {

        //obs = transform.parent.parent.gameObject;
        //if (obs.GetComponent<obsmove>().spawnagain)
        //{
        //    Destroy(gameObject);
        //    //Debug.Log("Destroyed");
        //}


        //if (!val)
        //{
        //    transform.localPosition = Vector3.MoveTowards(transform.localPosition, endpos, speed * Time.deltaTime);
        //    if (transform.localPosition == endpos)
        //    {
        //        t += Time.deltaTime;

        //        if (t > 0.8f)
        //        {
        //            val = true;
        //            t = 0.0f;
        //        }
        //    }

        //}
        //else
        //{
        //    transform.localPosition = Vector3.MoveTowards(transform.localPosition, startpos, speed * Time.deltaTime);
        //    if (transform.localPosition == startpos)
        //    {
        //        t += Time.deltaTime;

        //        if (t > 0.8f)
        //        {
        //            val = false;
        //            t = 0.0f;
        //        }

        //    }
        //}

        //if (!val)
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        //}
        //else
        //{
        //    transform.localPosition = Vector3.MoveTowards(transform.localPosition, startpos, speed * Time.deltaTime);

        //}


        t += Time.deltaTime;

        //if (wall.name == "wall")
        //{


        if (val)
        {
            transform.localPosition = new Vector3(3.5f * Mathf.Sin(t * speed), transform.localPosition.y, transform.localPosition.z);
            if (Vector3.Distance(transform.localPosition,new Vector3(3.5f,0,0)) < 0.1f)
            {
                val = false;
                val2 = true;
                t = 0;
            }
            else if (Vector3.Distance(transform.localPosition, new Vector3(-3.5f, 0, 0)) < 0.1f)
            {
                val = false;
                val2 = true;
                t = 0;
            }
        }
        if (val2)
        {
            t2 += Time.deltaTime;
            if (t2 > 0.4f)
            {
                val2 = false;
                val = true;
                t2 = 0.0f;
            }
        }
            
        //}
        //else if(wall.name == "wall2")
        //{
        //    transform.localPosition = new Vector3(3 * -Mathf.Sin(t * speed), transform.localPosition.y, transform.localPosition.z);
        //}
        
    }


}