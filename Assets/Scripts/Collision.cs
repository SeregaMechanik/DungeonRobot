using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        int invul = GameObject.Find("GemController").GetComponent<GemController>().invul;
        if (invul == 0)
        {
            if (PlayerPrefs.HasKey("score"))
            {
                int scoreRecord = PlayerPrefs.GetInt("score");
                int score = GameObject.Find("ScoreController").GetComponent<ScoreController>().Score;
                if (scoreRecord < score)
                {
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.Save();
                }
            }
            else 
            {
                int score = GameObject.Find("ScoreController").GetComponent<ScoreController>().Score;
                PlayerPrefs.SetInt("score", score);
                PlayerPrefs.Save();
            }
            Time.timeScale = 0;
            SceneManager.LoadScene("Menu");
        }
        else
        {
            GameObject.Find("GemController").GetComponent<GemController>().invul = invul - 1;
        }
    }

}
