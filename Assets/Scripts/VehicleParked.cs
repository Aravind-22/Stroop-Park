using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VehicleParked : MonoBehaviour
{
    TextMeshPro text;
    bool carParked = false;
    public SpawnManager spawnVehicle;
    public GameManager gameOver;
    int parked, remaining;
    public AudioSource correctSlot;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        parked = LevelProgression.Instance.carParked;
        remaining = LevelProgression.Instance.carRemaining;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        var destroyTime = 0.75f;
        if (collision != null)
        {
            //If color match
            if (text.color == collision.gameObject.GetComponent<VehicleMovement>().colorCode)
            {
                Debug.Log("car parked");
                carParked = true;
                if (carParked)
                {
                    parked++;
                    LevelProgression.Instance.carParked = parked;
                    remaining--;
                    LevelProgression.Instance.carRemaining = remaining;
                    Destroy(collision.gameObject, destroyTime);
                    correctSlot.PlayDelayed(0.5f);
                    StartCoroutine(callVehicle());
                }
            }
            //If color dont match
            if(text.color != collision.gameObject.GetComponent<VehicleMovement>().colorCode)
            {
                carParked = false;
                if (carParked == false)
                {
                    Destroy(collision.gameObject, destroyTime);
                    //Call GameOver function
                    StartCoroutine(callGameOver());
                }
            }
            }
                    

    }
    IEnumerator callVehicle()
    {
        yield return new WaitForSeconds(1.0f);
        spawnVehicle.SpawnRandomVehicle();        
    }
    IEnumerator callGameOver()
    {
        yield return new WaitForSeconds(1.0f);
        gameOver.Gameover();
    }
}
