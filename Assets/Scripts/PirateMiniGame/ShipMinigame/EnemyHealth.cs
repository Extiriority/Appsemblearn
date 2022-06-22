using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] public float enemyHealth = 1;
    [SerializeField] public GameObject enemyShip;
    [SerializeField] public GameObject playerBullet;
    [SerializeField] float vulnerability;
    //EnemyShipMovement enemyShipMovement;  
    Shooting shooting;
    public GameObject target;
    public EnemySpawn enemySpawn;
    // Start is called before the first frame update
    void Start()
    {
        //enemyShipMovement = GetComponent<EnemyShipMovement>();
        //GameObject target = enemyShipMovement.target;
        //shooting = target.GetComponent<Shooting>();
        //Debug.Log(shooting.bulletType);
        target = GameObject.Find("Player");
        shooting = target.GetComponent<Shooting>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
        
    }

    void OnTriggerEnter2D(Collider2D playerBullet)
    {
        
        if (shooting.currentBulletType == vulnerability)
        {
            if (playerBullet.tag == "PlayerBullet")
            {
                enemyHealth -= 1;

                if (enemyHealth == 0)
                {
                    enemySpawn.liveShipCount--;
                }
            }
        }
        
            
    }
}
