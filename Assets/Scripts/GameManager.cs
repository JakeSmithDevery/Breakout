using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int BlocksRemaining;
    public int TimeRemaining;
    public int LivesRemaining;


    public TMPro.TMP_Text txtTime;
    public TMPro.TMP_Text txtLives;

    private void Start()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        BlocksRemaining = blocks.Length;
    }


    private void CheckIfGameIsOver()
    {
        if(BlocksRemaining <= 0 )
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        else if( TimeRemaining <= 0 || LivesRemaining <=0)
        {
            //restart game
        }
    }

    public void OnBlockDestroyed()
    {
        BlocksRemaining--;
        CheckIfGameIsOver();
        
    }

    public void OnLiveLost()
    {
        LivesRemaining--;
        CheckIfGameIsOver();
    }

}
