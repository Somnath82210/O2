using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class obsmove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject[] fish= new GameObject[4];
    [SerializeField] List<GameObject> fspawn = new List<GameObject>();
    [SerializeField] playerinfo p;
    [SerializeField] SpriteRenderer s;
    [SerializeField] GameObject[] stars;

    public bool spawnagain;
    //GameObject shark;


    private Camera mainCamera;
    public float objectHeight = 1f; // Manually define the height of the object
    // Start is called before the first frame update
    void Start()
    {

        //shark = transform.GetChild(2).gameObject;

        //Debug.Log("Combined Height in World Space: " + height);

        foreach (GameObject g in fspawn)
        {
            Instantiate(fish[Random.Range(0,4)], g.transform.position, Quaternion.identity, transform);
        }
        mainCamera = Camera.main;
        //objectHeight = FindChildByName(transform, "wall").transform.localScale.y;
        objectHeight=s.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (!p.stop)
        {
            spawnagain = false;
            transform.Translate(Vector3.down * speed * Time.deltaTime);


            // Calculate the bottom of the camera in world space
            //float bottomBound = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

            // Check if the object has exited the bottom of the camera view
            //if (transform.position.y + objectHeight / 2 < bottomBound)
            //{
            //    // Calculate the top of the camera in world space
            //    float topBound = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

            //    // Move the object to the top of the camera view
            //    transform.position = new Vector3(
            //        transform.position.x,
            //        topBound + 129.9f,
            //        transform.position.z
            //   );

            //if (transform.position.y < -52)
            //{
            //    transform.position = new Vector3(transform.position.x, 138.7f, transform.position.z);
            //    spawnagain = true;
            //}
            //    Debug.Log("hello");

            //    wallspawn w = FindChildByName(transform, "wall").gameObject.GetComponent<wallspawn>();
            //    wallspawn w2 = FindChildByName(transform, "wall2").gameObject.GetComponent<wallspawn>();


            //    //walls should spawn again
            //    w.val = true;
            //    w2.val = true;


            //}

            if (transform.position.y < -52)
            {

                transform.position = new Vector3(transform.position.x, 138.7f, transform.position.z);
                spawnagain = true;
                foreach(GameObject g in stars)
                {
                    g.SetActive(true);
                }
                wallspawn w = FindChildByName(transform, "wall").gameObject.GetComponent<wallspawn>();
                wallspawn w2 = FindChildByName(transform, "wall2").gameObject.GetComponent<wallspawn>();


                //walls should spawn again
                w.val = true;
                w2.val = true;



            }

        }



    }

    Transform FindChildByName(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;

            Transform result = FindChildByName(child, name);
            if (result != null)
                return result;
        }
        return null;
    }



}