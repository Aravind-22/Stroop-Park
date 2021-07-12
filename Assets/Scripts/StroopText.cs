using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StroopText : MonoBehaviour
{
    TextMeshPro text;
    private string[] textValue = {"White","Black","Yellow","Green","Orange","Blue","Red","Purple"};
    private float spawnDelay = 5;
    private float spawnInterval = 5;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        InvokeRepeating("RandomText", spawnDelay, spawnInterval);
    }
    //Generate random text
    void RandomText()
    {
        int textIndex = Random.Range(0, textValue.Length);
        text.text = textValue[textIndex];
    }
}
