using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblespawn : MonoBehaviour
{
    [SerializeField]GameObject bubble;
    GameObject obs;
    [SerializeField] float timelimit;
    [SerializeField] float timeinterval;
    int bubblecount;
    int c = 0;
    float t = 0.0f;
    float t2 = 0.0f;
    bool val = true;
    // Start is called before the first frame update
    void Start()
    {
        bubblecount = Random.Range(1, 4);
        GameObject wall = transform.parent.gameObject;
        

        if (wall.name == "wall")
        {
            transform.localPosition = new Vector3(0.7f, transform.localPosition.y, 0);
        }
        else if(wall.name == "wall2")
        {
            transform.localPosition = new Vector3(-0.7f, transform.localPosition.y, 0);
        }
      
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

        if (val)
        {
            t += Time.deltaTime;

            if (t > timelimit && c <= bubblecount)
            {
                c++;
                GameObject b = Instantiate(bubble, transform.TransformPoint(new Vector3(Random.Range(-1.5f, 1.5f), 0, 0)), Quaternion.identity, transform);
                float s = Random.Range(2, 5.5f);
                b.transform.localScale = new Vector3(s, s, 0);
                t = 0;
            }
            if (c >= bubblecount)
            {
                c = 0;
                val = false;
            }
        }
        else
        {
            t2 += Time.deltaTime;
            if (t2 > timeinterval)
            {
                t2 = 0;
                val = true;
             
            }
        }
        
    }
}
