using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyShipPrefab;
    public GameObject enemyShip2Prefab;

    Transform canvasTransform;
    public GameObject canvas;

    [SerializeField] public GameObject lockPickingCanvas;

    public int liveShipCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        canvasTransform = canvas.transform;
        spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void spawn()
    {
       


        if (liveShipCount < 3)
        {

            GameObject tempShip = new GameObject();
            int selectShip = Random.Range(1, 3);
            print(selectShip);

            switch (selectShip)
            {
                case 1:
                    tempShip = enemyShipPrefab;
                    break;

                case 2:
                    tempShip = enemyShip2Prefab;
                    break;
            }

            liveShipCount++;

            GameObject ship = Instantiate(tempShip, spawnPoint.position, spawnPoint.rotation);

            ship.GetComponent<EnemyHealth>().enemySpawn = this;

            ship.GetComponent<GettingBoarded>().lockPickingCanvas = lockPickingCanvas;

            ship.transform.SetParent(canvasTransform);
        }
        

        Invoke("spawn", 15);
    }
}
