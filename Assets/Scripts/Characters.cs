using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public Monsters monster;
    private string ATTACK_TRIGGER = "Attack Trigger";
    public float range = 5f;
    public float maxRange;
    private Animator anim;

    private GameObject closestEnemy;
    public float shootInterval = 2f;
    public int upgradeCount = 0;

    public int damage = 2;
    private bool upgrade = false;

    public GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (closestEnemy == null)
        {
            FindClosestEnemy();
        }
        

        if (closestEnemy != null) 
        {
            anim.SetTrigger(ATTACK_TRIGGER);
            closestEnemy.GetComponent<Monsters>().takeDamage(damage);
        }

    }

    //returns the enemy which is in range and closest to the character
    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= range)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
    }

    //upgrades character's damage and range in an alternating fashion
    public void upgradeCharacter(int cost)
    {
        if (upgradeCount < 5 && gameManager.GetComponent<Game_Manager>().coinCount >= cost)
        {
            gameManager.GetComponent<Game_Manager>().coinManager(-cost);
            if (upgrade)
            {
                damage++;
                upgrade = !upgrade;
                upgradeCount++;
            }
            else
            {
                if(range + 2 < maxRange)
                {
                    range = range + 2;
                    upgrade = !upgrade;
                    upgradeCount++;
                }
                else
                {
                    range = maxRange;
                    upgrade = !upgrade;
                    upgradeCount++;
                }
                
                
            }
        }
    }


}
