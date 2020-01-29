using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //how many blocks are left in the level
    //when this is 0, the player has won
    public int blocksRemaining;

    //when the lives are 0, game over, player has lost
    public int lives = 3;

    //custom class to store data about the player
    public PlayerData data;

    //count how many blocks are in the level when the game starts
    void CountBlocks()
    {
        //GameObject.FindObjectWithTag
        //GameObject.FindObjectWithTags
        blocksRemaining = GameObject.FindGameObjectsWithTag("Block").Length;
    }

    //update the blocks remaining every time one is destroyed
    public void OnBlockDestroyed()
    {
        //subtract 1 from blocks remaining
        blocksRemaining--;

        //update the player save data
        data.totalBlocksDestroyed++;

        if(blocksRemaining <= 0)
        {
            //game complete (win)!
            //will load the scene with the matching name
            SceneManager.LoadScene("GameWon");
        }
    }

    //update the lives when the ball hits the kill barrier
    public void OnBallHitKill()
    {
        //subtract 1 from lives
        lives--;

        //check if game over
        if(lives <= 0)
        {
            //game over (loss)!
            //will load the scene with the matching name
            SceneManager.LoadScene("GameLost");
        }
    }

    //Awake is called before the Start method
    private void Awake()
    {
        //setup Unity to tell me when the level has loaded...
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        CountBlocks();
    }
}

//lets the variables be edited in Unity
[Serializable]
public class PlayerData
{
    public int totalBlocksDestroyed;
    public string userName = "Jake";
}
