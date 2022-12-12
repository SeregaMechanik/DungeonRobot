using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class ScoreLoad : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            int scoreRecord = PlayerPrefs.GetInt("score");
            scoreText.text = "Max score: " + scoreRecord;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
