using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public float speed;

    private Rigidbody2D myBody;
    private Animator anim;
    private string DEAD_ANIMATION = "Dead";
    
    [SerializeField] private GameObject GM;
    private Game_Manager gameManager;

    private string CASTLE_TAG = "Castle";
    private string GAME_MANAGER_TAG = "Game Manager";

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
        GM = GameObject.FindGameObjectWithTag(GAME_MANAGER_TAG);
        
    }

    private void Start()
    {
        gameManager = GM.GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //responsible for character movement
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CASTLE_TAG))
        {
            collision.gameObject.GetComponent<Castle>().takeDamage(3);
            
            Destroy(gameObject);
        }
    }



    
    //Reduces the health of the enemy by the passed amount and checks if the enemy's health is >0, then enemy is killed
    public void takeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            anim.SetBool(DEAD_ANIMATION, true);
            gameManager.GetComponent<Game_Manager>().coinManager(Random.Range(1, 5));
            Destroy(gameObject);
        }
    }

    
}
