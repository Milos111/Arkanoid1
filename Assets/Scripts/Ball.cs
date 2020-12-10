using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //  public Vector2 startPosition = new Vector2(0,0);
    public float vx = 4;
    public float vy = 4;

    // Start is called before the first frame update

    void Start()
    {
        //  transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        

        //  v = s/t => s = v*t,   v-velocity ili brzina, s-> put t-time  ili vreme
          
        float newX = transform.position.x + vx * Time.deltaTime;
        float newY = transform.position.y + vy * Time.deltaTime;
        
        transform.position = new Vector3(newX, newY, 0);
    }


    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.gameObject.tag)
        {
            case "WallRight":
                vx = -1 * vx;
                break;

            case "WallLeft":
                vx = -1 * vx;
                break;

            case "WallUp":
                vy = -1 * vy;
                break;

            case "Bottom":
                Time.timeScale = 0f;
                Debug.Log("GAME OVER");
                break;
            case "Player":
                vy = -1 * vy;
                //ovde u buducnosti promeniti brzinu
                Player Player= col.GetComponent<Player>();
                if (Player.speed < 0) vx = vx - Mathf.Abs(vx) * 0.3f;
                else if (Player.speed > 0) vx = vx + Mathf.Abs(vx) * 0.3f;
                break;
            case "brickUp":
                vy = -1 * vy;
                Destroy(col.transform.parent.gameObject);
                break;
            case "brickDown":
                vy = -1 * vy;
                Destroy(col.transform.parent.gameObject);
                break;
            case "brickRight":
                vx = -1 * vx;
                Destroy(col.transform.parent.gameObject);
                break;
            case "brickLeft":
                vx = -1 * vx;
                Destroy(col.transform.parent.gameObject);
                break;
        }
    }
}
