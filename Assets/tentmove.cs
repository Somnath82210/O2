using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentmove : MonoBehaviour
{
    GameObject wall;
    GameObject obs;
    [SerializeField] float speed;
    [SerializeField] playerinfo p;
    Vector3 startpos;
    Vector3 endpos;
    float t = 0.0f;
    //float t2 = 0.0f;
    bool val=true;
    bool val2;
    // Start is called before the first frame update
    void Start()
    {
        wall = transform.parent.parent.gameObject;


        startpos = new Vector3(1.8f, transform.localPosition.y, 0);
        endpos = new Vector3(-2, transform.localPosition.y, 0);


    }

    // Update is called once per frame
    void Update()
    {

        obs = transform.parent.parent.parent.gameObject;
        if (obs.GetComponent<obsmove>().spawnagain)
        {
            Destroy(gameObject);
            //Debug.Log("Destroyed");
        }


        


        t += Time.deltaTime;




        if (!p.stop)
        {
            transform.localPosition = new Vector3(2.5f * Mathf.Sin(t * speed), transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            if (wall.name == "wall")
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (wall.name == "wall2")
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

        }
        }
            
            
            
        
        
    }



