using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float minX = 0.99f;
    public float maxX = 8.97f;
 
    public float vx = 0;

    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newX = transform.position.x + vx * Time.deltaTime;

        if (newX < minX)
        {
            newX = minX;
        }
        else if (newX > maxX)
        {
            newX = maxX;
        }

        transform.position = new Vector3(newX, transform.position.y, 0);

    }

    public void FixedUpdate()
    {
        // https://docs.unity3d.com/ScriptReference/Input.GetKey.html
        if (Input.GetKey("left") && Input.GetKey("right"))
        {
            vx = 0;
        }
        else
        {
            if (Input.GetKey("left"))
            {
                vx = -1 * speed;
            }
            else if (Input.GetKey("right"))
            {
                vx = speed;
            }
            else
            {
                vx = 0;
            }
        }

    }

}