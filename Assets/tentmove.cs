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
    bool val;
    // Start is called before the first frame update
    void Start() 
    {
        wall = transform.parent.gameObject;
        

        startpos = new Vector3(1.8f , transform.localPosition.y, 0);
        endpos = new Vector3(-2, transform.localPosition.y, 0);
        

    }

    // Update is called once per frame
    void Update()
    {

        obs = transform.parent.parent.gameObject;
        if (obs.GetComponent<obsmove>().spawnagain)
        {
            Destroy(gameObject);
            //Debug.Log("Destroyed");
        }


        if (!val)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endpos, speed * Time.deltaTime);
            if (transform.localPosition == endpos)
            {
                t += Time.deltaTime;

                if (t > 0.8f)
                {
                    val = true;
                    t = 0.0f;
                }
            }

        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startpos, speed * Time.deltaTime);
            if (transform.localPosition == startpos)
            {
                t += Time.deltaTime;

                if (t > 0.8f)
                {
                    val = false;
                    t = 0.0f;
                }

            }
        }

        if (!val)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startpos, speed * Time.deltaTime);

        }
    }

    
}
