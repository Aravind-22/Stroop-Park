using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] vehiclePrefabs;
    private float[] spawnPosX = {-6.50f, 6.50f,-1.50f, 1.50f};
    private float spawnPosY = -40;
    int vehicleIndex,level,spawnX;
    int fourVehicle, sixVehicle;
    int twoLane, threeLane;
    // Start is called before the first frame update
    void Start()
    {
        fourVehicle = vehiclePrefabs.Length - 4;
        sixVehicle = vehiclePrefabs.Length - 2;
        twoLane = spawnPosX.Length - 2;
        threeLane = spawnPosX.Length - 1;
        level = LevelProgression.Instance.level;
        SpawnRandomVehicle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Spawn Random Vehicle
    public void SpawnRandomVehicle()
    {

        if (level <= 5)
        {
            vehicleIndex = Random.Range(0, fourVehicle);
            spawnX = Random.Range(0, twoLane);
        }
        else if(level>=6 && level <= 10)
        {
            vehicleIndex = Random.Range(0, sixVehicle);
            spawnX = Random.Range(0, threeLane);
        }
        else if (level>10)
        {
            vehicleIndex = Random.Range(0, vehiclePrefabs.Length);
            spawnX = Random.Range(0, spawnPosX.Length);
        }
        Vector2 spawnPos = new Vector2(spawnPosX[spawnX],spawnPosY);
        GameObject temp = Instantiate(vehiclePrefabs[vehicleIndex], spawnPos, vehiclePrefabs[vehicleIndex].transform.rotation);
        Debug.Log(vehiclePrefabs[vehicleIndex].name);
        spawnedVehicle = temp;

    }
    public GameObject spawnedVehicle;

}
