//using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class playerdmg : MonoBehaviour
{
    public float health = 100f;
    public float armor = 100f;

    public GameObject enemy1;
    public float enemyType1Dmg = 10f;

    public GameObject enemy2;
    public float enemyType2Dmg = 10f;

    public GameObject enemy3;
    public float enemyType3Dmg = 10f;

    public Transform spawnPad;

    public GameObject thisPlayer;
    
    public Text textbox;
 

    Rigidbody2D rb;

    void Update()
    {
        textbox.text = health + " HP";
        {
            if (health <= 0)
            {
                Destroy(thisPlayer);
                GameObject player = Instantiate(thisPlayer, spawnPad.transform.position, spawnPad.transform.rotation);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyType1")
        {
            health = health - enemyType1Dmg;
            Debug.Log(enemy1 + " Dealt " + enemyType1Dmg + " damage to " + thisPlayer);
        }

        if (collision.gameObject.tag == "EnemyType2")
        {
            health = health - enemyType2Dmg;
            Debug.Log(enemy2 + " Dealt " + enemyType2Dmg + " damage to " + thisPlayer);
        }

        if (collision.gameObject.tag == "EnemyType3")
        {
            health = health - enemyType3Dmg;
            Debug.Log(enemy2 + " Dealt " + enemyType3Dmg + " damage to " + thisPlayer);
        }
    }

}
