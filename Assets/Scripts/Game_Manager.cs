using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    public GameObject spawner;
    [SerializeField]
    private int[] monsterCount;

    public int coinCount = 0;
    public bool hardMode = false;

    
    // Start is called before the first frame update
    void Start()
    {
        //passing the enemy wave details and the mode of game
        spawner.GetComponent<Spawner>().spawnWave(monsterCount, hardMode);
    }

    //Updates the coin count
    public void coinManager(int count)
    {
        coinCount = coinCount + count;
    }
}
