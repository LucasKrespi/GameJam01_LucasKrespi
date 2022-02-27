using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{

    public TextMeshProUGUI message;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        message.text = PlayerPrefs.GetString("Message");

        score.text = "Score: " + PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
