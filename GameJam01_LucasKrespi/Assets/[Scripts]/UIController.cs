using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIController : MonoBehaviour
{
    public PlayerMovementController playerController;

    public TextMeshProUGUI Scores;
    public TextMeshProUGUI Lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scores.text = "Score: " + playerController.Score;
        Lives.text = "Lives: " + playerController.life;
     }
}
