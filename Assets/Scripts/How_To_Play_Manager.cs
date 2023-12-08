using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class How_To_Play_Manager : MonoBehaviour
{

    private string MAIN_MENU_SCENE = "Main Menu";

    //Load Main Menu scene
    public void Exit()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
    
}
