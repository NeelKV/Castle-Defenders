using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over_Manager : MonoBehaviour
{

    private string MAIN_MENU_SCENE = "Main Menu";

    //load Main Menu scene
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }

}
