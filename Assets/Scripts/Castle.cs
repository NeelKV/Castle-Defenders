using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    
    public int health = 100;

    private string HALF_HEALTH = "Health below 50";

    private string GAME_OVER_LOSE = "Game Over_Lose";

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Reduces the castle health by the passed amount and checks to see if castle animation needs to be changed and if the game is over
    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            SceneManager.LoadScene(GAME_OVER_LOSE);
        }

        if(health/2 <= 0.5)
        {
            anim.SetBool(HALF_HEALTH, true);
        }
    }

    //increases castle health by 20, upto max health which is 100
    public void getHealth()
    {
        if(health + 20 <= 100) { health += 20; }
        else { health = 100; }
    }
  
}
