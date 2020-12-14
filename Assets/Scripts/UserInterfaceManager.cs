using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    public GameObject player;
    public Text scoreText;
    public Text distanceText;

    void Start()
    {
        player = GameObject.Find("Timmy");
        scoreText.text = "";
    }

    void Update()
    {
        int distance = Mathf.RoundToInt(player.transform.position.z);
        distanceText.text = "Your distance: " + distance.ToString() + " meters";
    }

    public void updateScoreUI(int score)
    {
        scoreText.text = "Score: " + score.ToString(); 
    }
}
