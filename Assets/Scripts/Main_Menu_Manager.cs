using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Manager : MonoBehaviour
{

    private string HOW_TO_PLAY = "How To Play";
    private string EASY_MODE = "Gameplay";
    private string HARD_MODE = "Gameplay_Hard";

    //Loads the game in easy mode. Loading Gameplay scene
    public void playEasyMode()
    {
        SceneManager.LoadScene(EASY_MODE);
    }

    //Loads the game in hard mode. Loading Gameplay_Hard scene
    public void playHardMode()
    {
        SceneManager.LoadScene(HARD_MODE);
    }

    //Loads How To Play scene
    public void How_To_Play()
    {
        SceneManager.LoadScene(HOW_TO_PLAY);
    }
}
