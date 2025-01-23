using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallspawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] obs = new GameObject[2];
    List<GameObject> children = new List<GameObject>();
    public bool val = true;
    GameObject o;
    void Start()
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //if (spriteRenderer != null)
        //{
        //    // Get the size of the sprite in pixels
        //    Vector2 spritePixelSize = spriteRenderer.sprite.rect.size;

        //    // Get Pixels Per Unit (PPU)
        //    float pixelsPerUnit = spriteRenderer.sprite.pixelsPerUnit;

        //    // Calculate the size in world units (ignoring scale for now)
        //    Vector2 spriteWorldSize = spritePixelSize / pixelsPerUnit;

        //    // Account for local scale to get final size
        //    Vector3 globalScale = GetWorldScale(transform);
        //    Vector2 finalWorldSize = new Vector2(
        //        spriteWorldSize.x * globalScale.x,
        //        spriteWorldSize.y * globalScale.y
        //    );

        //    Debug.Log($"Sprite Size in World Units: {finalWorldSize}");
        //}
        //else
        //{
        //    Debug.LogError("No SpriteRenderer found on this GameObject!");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (val)
        {
            if (children.Count > 0)
            {
                children.Clear();
                //Debug.Log("cleared");

            }
            int size = transform.childCount;
            for (int i = 0; i < size; i++)
            {
                children.Add(transform.GetChild(i).gameObject);
            }
            foreach (GameObject g in children)
            {
                int i = Random.Range(1, 4);

                if (i == 2)
                {
                    o = Instantiate(obs[0], g.transform.position, Quaternion.identity,g.transform);
                    if (gameObject.name == "wall")
                    {
                        o.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else if (gameObject.name == "wall2")
                    {
                        o.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
                else
                {
                    o = Instantiate(obs[1], g.transform.position, Quaternion.identity,g.transform);
                    if (gameObject.name == "wall")
                    {
                        o.transform.localScale = o.transform.localScale;
                        o.transform.position +=new Vector3(2,0,0);
                    }
                    else if (gameObject.name == "wall2")
                    {
                        o.transform.localScale = new Vector3(-o.transform.localScale.x, o.transform.localScale.y, o.transform.localScale.z);
                        o.transform.position -= new Vector3(2, 0, 0);
                    }
                }

                


                //o.transform.SetParent(transform);
            }
            val = false;
        }
    }

    Vector3 GetWorldScale(Transform obj)
    {
        Vector3 worldScale = obj.localScale;
        Transform parent = obj.parent;

        while (parent != null)
        {
            worldScale = Vector3.Scale(worldScale, parent.localScale);
            parent = parent.parent;
        }

        return worldScale;
    }

}