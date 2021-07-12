using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VehicleSteer : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    float rotateSpeed = 100.0f;
    public int direction = 1;
    public SpawnManager sm;
    float minRotation = 30;
    float maxRotation = 150;
    public GameObject spawnedVehicle;

    bool buttonPressed = false;

    void Update()
    {
        spawnedVehicle = sm.spawnedVehicle;

        if (buttonPressed)
            Steer(direction);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
    //Steer vehicle left and right
    public void Steer(int direction)
    {
        if(spawnedVehicle!=null)
        {
            spawnedVehicle.transform.Rotate(Vector3.forward * rotateSpeed * direction * Time.deltaTime);

            Vector3 currentRotation = spawnedVehicle.transform.localRotation.eulerAngles;
            currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
            spawnedVehicle.transform.localRotation = Quaternion.Euler(currentRotation);
        }
    }



}

