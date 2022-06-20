using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingBoarded : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject lockPickingCanvas;
    private EnemyHealth enemyHealth;
   
    // Start is called before the first frame update
    void Start()
    {
        
        startCanvas = GameObject.Find("Canvas");
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D player)
    {
        if (enemyHealth.enemyHealth == 0)
        {
            if (player.gameObject.tag == "Player")
            {
                startCanvas.SetActive(false);
                lockPickingCanvas.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
}
