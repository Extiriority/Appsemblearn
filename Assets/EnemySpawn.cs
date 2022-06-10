using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyShipPrefab;
    public Transform Canvas;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void spawn()
    {
        GameObject ship = Instantiate(enemyShipPrefab, spawnPoint.position, spawnPoint.rotation);

        ship.transform.SetParent(Canvas);

        Invoke("spawn", 10);
    }
}
