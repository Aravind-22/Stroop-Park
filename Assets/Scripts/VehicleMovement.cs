using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    float moveSpeed = 6.5f;
    float xRange = 12.5f;
    float topBound = 22f;
    int destroyDelay = 1;
    public Color colorCode;
    GameManager gameOver;
    bool isGameOver=false;
    // Start is called before the first frame update
    private void OnEnable()
    {
       
        gameOver = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //Move vehicle forward
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //If vehicle goes out of Bounds
        if(transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }
        if(transform.position.y > topBound)
        {
            Destroy(gameObject,destroyDelay);
            //Call GameOver function
            if (!isGameOver)
            {
                gameOver.Gameover();
                isGameOver = true;
            }
        }
    }
}
