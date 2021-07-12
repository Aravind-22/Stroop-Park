using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelProgression : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI carsParked;
    [SerializeField] TextMeshProUGUI carsRemaining;
    public GameManager NextLevel;
    public GameObject GameComplete;
    public GameObject[] roadBlock1, roadBlock2;
    public GameObject[] sixColor,eightColor;
    public AudioSource levelComplete;
    public static LevelProgression Instance { get; private set; }
    public int level = 1,carParked = 0,carRemaining = 4;
    void Awake()
    {
        Instance = this;
        levelText.text = level.ToString();
    }
    void Start()
    {
        sixColor = GameObject.FindGameObjectsWithTag("SixColor");
        eightColor = GameObject.FindGameObjectsWithTag("EightColor");
        roadBlock1 = GameObject.FindGameObjectsWithTag("RoadBlock1");
        roadBlock2 = GameObject.FindGameObjectsWithTag("RoadBlock2");
        if (level <= 5)
        {
            foreach (GameObject go in sixColor)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in eightColor)
            {
                go.SetActive(false);
            }
        }
        if (level >= 6 && level<= 10)
        {
            foreach (GameObject go in eightColor)
            {
                go.SetActive(false);
            }
            foreach (GameObject item in roadBlock1)
            {
                item.SetActive(false);
            }
            
        }
        if(level>10 && level <= 15)
        {
            foreach (GameObject item in roadBlock1)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in roadBlock2)
            {
                item.SetActive(false);
            }
        }

    }

     void Update()
    {
        carsParked.text = carParked.ToString();
        carsRemaining.text = carRemaining.ToString();
        if (carRemaining == 0)
            updateLevel();
    }

    void updateLevel()
    {
        if (level == 15)
        {
            Debug.Log("Congratulations! You have completed the game.");
            StartCoroutine(gameComplete());
        }
        else
        {
            levelComplete.PlayDelayed(0.5f);
            StartCoroutine(callNextLevel());
            level += 1;
            levelText.text = level.ToString();
            carRemaining = carParked + 2;
            carParked = 0;
        }
    }
    IEnumerator callNextLevel()
    {
        yield return new WaitForSeconds(1.0f);
        NextLevel.nextLevel.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator gameComplete()
    {
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0;
        GameComplete.SetActive(true);
        levelComplete.PlayDelayed(0.75f);
    }
}

