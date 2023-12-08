using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    [SerializeField] private GameObject spawnerObject;
    public Game_Manager gameManager;
    public GameObject castle;
    public GameObject archer;
    public GameObject fireFairy;
    public GameObject iceFairy;
    public GameObject windFairy;
    public Spawner spawner;


    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI fireCost;
    public TextMeshProUGUI iceCost;
    public TextMeshProUGUI windCost;
    public TextMeshProUGUI archerCost;
    public TextMeshProUGUI healthCost;
    public TextMeshProUGUI castleHealth;

    public int fire_cost = 3;
    public int ice_cost = 5;
    public int wind_cost = 7;
    public int archer_cost = 2;
    public int health_cost = 10;


    public Button unlockFire;
    public Button upgradeFire;
    public Button unlockIce;
    public Button upgradeIce;
    public Button unlockWind;
    public Button upgradeWind;
    public Button upgradeArcher;
    public Button getHealth;

    // Start is called before the first frame update
    void Start()
    {
        //Initializing gameobject instances and instances of some classes
        gameManager = GM.GetComponent<Game_Manager>();
        castle = GameObject.FindGameObjectWithTag("Castle");
        spawner = spawnerObject.GetComponent<Spawner>();

        upgradeFire.gameObject.SetActive(false);
        upgradeIce.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        upgradeText();
    }

    //Updates the text showing the cost of upgrades and unlocks
    public void upgradeText()
    {
        coinCount.text = "X: " + gameManager.coinCount;
        castleHealth.text = (castle.GetComponent<Castle>().health).ToString();
        fireCost.text = "Cost: " + fire_cost;
        iceCost.text = "Cost: " + ice_cost;
        //windCost.text = "Cost: " + wind_cost;
        archerCost.text = "Cost: " + archer_cost;
        healthCost.text = "Cost: " + health_cost;
    }


    //Unlock Fire Fairy character and deactivates and activates respective buttons
    public void unlockFireFairy()
    {
        if(fire_cost <= gameManager.coinCount)
        {
            fireFairy = spawner.spawnFireFairy();
            unlockFire.gameObject.SetActive(false);
            upgradeFire.gameObject.SetActive(true);
            fire_cost = fire_cost + 3;
        }
        

    }

    //Unlock Ice Fairy character and deactivates and activates respective buttons
    public void unlockIceFairy()
    {
        if(ice_cost <= gameManager.coinCount)
        {
            iceFairy = spawner.spawnIceFairy();
            unlockIce.gameObject.SetActive(false);
            upgradeIce.gameObject.SetActive(true);
            ice_cost = ice_cost + 3;
        }
        
    }

    //Upgrade Fire Fairy character and calls required functions to do the upgrade
    public void upgradeFireFairy()
    {
        if(fire_cost <= gameManager.coinCount)
        {
            fireFairy.GetComponent<Characters>().upgradeCharacter(fire_cost);
            fire_cost = fire_cost + 3;
            if (fireFairy.GetComponent<Characters>().upgradeCount >= 5)
            {
                upgradeFire.interactable = false;
            }
        }
        
    }

    //Upgrade Ice Fairy character and calls required functions to do the upgrade
    public void upgradeIceFairy()
    {
        if(ice_cost <= gameManager.coinCount)
        {
            iceFairy.GetComponent<Characters>().upgradeCharacter(ice_cost);
            ice_cost = ice_cost + 3;
            if (iceFairy.GetComponent<Characters>().upgradeCount >= 5)
            {
                upgradeIce.interactable = false;
            }
        }
        
    }

    //Upgrade Arches character and calls required functions to do the upgrade
    public void upgrade_Archer()
    {
        if(archer_cost <= gameManager.coinCount)
        {
            archer.GetComponent<Characters>().upgradeCharacter(archer_cost);
            archer_cost = archer_cost + 2;
            if (archer.GetComponent<Characters>().upgradeCount >= 5)
            {
                upgradeArcher.interactable = false;
            }
        }
        
    }

    //Increases castle health and calls required functions to do the upgrade
    public void getCastleHealth()
    {
        if (gameManager.coinCount >= health_cost)
        {
            gameManager.coinManager(-health_cost);
            castle.GetComponent<Castle>().getHealth();
            health_cost = health_cost + 5;
        }
    }
}
