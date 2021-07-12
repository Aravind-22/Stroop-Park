using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StroopColor : MonoBehaviour
{
    public Color[] colorsFour = { Color.white, Color.red, Color.green, Color.blue };
    public Color[] colorsSix = { Color.white, Color.red, Color.green, Color.blue, Color.yellow, Color.black};
    public Color[] colorsEight = { Color.white, Color.red, Color.green, Color.blue, Color.yellow, Color.black, new Color32(254, 161, 0, 1), new Color32(143, 0, 254, 1)};
    Color[] colors;
    TextMeshPro text;
    private float spawnDelay = 10;
    private float spawnInterval = 10;
    int i = 0,level;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        InvokeRepeating("ColorChange",spawnDelay,spawnInterval);
        level = LevelProgression.Instance.level;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //To change colors
    void ColorChange()
    {        
        if (level <= 5)
        {
            colors = colorsFour;
        }
        else if(level > 5 && level <= 10)
        {
            colors = colorsSix;
        }
        else if (level > 10 && level <= 15)
        {
            colors = colorsEight;
        }
        if (i >= colors.Length)
            i = 0;
        text.color = colors[i++];
    }
}
