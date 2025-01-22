using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsmove : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject shark;
    // Start is called before the first frame update
    void Start()
    {
        shark = transform.GetChild(2).gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y < -10)
        {

            transform.position = new Vector3(0, 10, 0);
            shark.transform.localPosition = new Vector3(0,Random.Range(-2.5f,2.5f),0);
            //Destroy(gameObject);
        }
    }
}
