using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     int BlocksRemaining;
    public int blocksremaining
    {
        get { return BlocksRemaining; }
    }
    public int TimeRemaining;
    public int LivesRemaining;

    float elapsedTime;


    public TMPro.TMP_Text txtTime;
    public TMPro.TMP_Text txtLives;

    private void Start()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        BlocksRemaining = blocks.Length;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= 1.0f)
        {
            TimeRemaining--;
            elapsedTime = 0.0f;
            txtTime.text = TimeRemaining.ToString();
            CheckIfGameIsOver();
        }
    }


    private void CheckIfGameIsOver()
    {
        if(BlocksRemaining <= 0 )
        {
            SceneManager.LoadScene("gamewon");
        }
        else if( TimeRemaining <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
        else if (LivesRemaining <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
    }

    public void OnBlockDestroyed()
    {
        BlocksRemaining--;
        CheckIfGameIsOver();
        
    }

    public void OnLifeLost()
    {
        LivesRemaining--;
        txtLives.text = LivesRemaining.ToString();
        CheckIfGameIsOver();
    }

}
