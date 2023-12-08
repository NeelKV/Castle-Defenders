using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private GameObject[] bossReference;
    private GameObject spawnedBoss;

    public GameObject spawnedMonster;
    private GameObject[] spawnedEnemy;

    [SerializeField]
    private Transform spawn;

    private int[] enemyWaves;
    private bool gameMode;
    private bool gameOver = false;

    [SerializeField]
    private Transform iceFairySpawn;
    [SerializeField] private GameObject iceFairy;
    [SerializeField]
    private Transform fireFairySpawn;
    [SerializeField] private GameObject fireFairy;
    [SerializeField]
    private Transform windFairySpawn;
    [SerializeField] private GameObject windFairy;

    private GameObject spawnedCharacter;

    private int randomIndex;
    public int waveCount = 0;
    public bool waveCountInit = false;
    public int monsterCount;
    public int monsterHealth = 10;
    public int bossHealth = 100;
    public bool waveOver = true;
    public bool lastWaveOver = false;

    private string GAME_OVER = "Game Over";
    

    // Start is called before the first frame update
    void Start()
    {
        waveOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        //checks if all the waves have been instantiated and all the spawned enemies are dead
        spawnedEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (gameOver && spawnedEnemy.Length == 0)
        {
            SceneManager.LoadScene(GAME_OVER);

        }
    }

    //setup fucntion to set the enemy wave numbers and game mode i.e. easy or hard
    public void spawnWave(int[] waves, bool mode)
    {
        enemyWaves = waves;
        gameMode = mode;
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        for(int i = 0; i < enemyWaves.Length; i++)
        {
            monsterCount = enemyWaves[i];
            while (monsterCount > 0)
            {
                //spawning the enemy character

                yield return new WaitForSeconds(Random.Range(1, 5));

                randomIndex = Random.Range(0, monsterReference.Length);

                spawnedMonster = Instantiate(monsterReference[randomIndex]);

                spawnedMonster.transform.position = spawn.position;

                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(3, 6);
                spawnedMonster.GetComponent<Monsters>().maxHealth = monsterHealth;

                monsterCount--;
            }

            //increasing enemy health after every wave
            monsterHealth = monsterHealth + 8;


            //spawning boss after every wave if playing in hard mode
            if (gameMode)
            {
                spawnBoss();
            }

            
        }

        //spawning boss after all the waves are over
        spawnedBoss = spawnBoss();
        gameOver = true;

        
        
    }

    //instantiate's Fire Fairy character
    public GameObject spawnFireFairy()
    {
        spawnedCharacter = Instantiate(fireFairy);
        spawnedCharacter.transform.position = fireFairySpawn.transform.position;
        spawnedCharacter.GetComponent<Characters>().damage = 3;
        spawnedCharacter.GetComponent<Characters>().shootInterval = 2;
        return spawnedCharacter;
    }

    //instantiate's Ice Fairy character
    public GameObject spawnIceFairy()
    {
        spawnedCharacter = Instantiate(iceFairy);
        spawnedCharacter.transform.position = iceFairySpawn.transform.position;
        spawnedCharacter.GetComponent<Characters>().damage = 2;
        spawnedCharacter.GetComponent<Characters>().shootInterval = 1;
        return spawnedCharacter;
    }

    
    //Spawns the boss character
    public GameObject spawnBoss()
    {
        randomIndex = Random.Range(0, bossReference.Length);

        spawnedMonster = Instantiate(bossReference[randomIndex]);

        spawnedMonster.transform.position = spawn.position;

        spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(1, 3);
        spawnedMonster.GetComponent<Monsters>().maxHealth = bossHealth;
        bossHealth = bossHealth + 30;

        return spawnedMonster;
    }
}
