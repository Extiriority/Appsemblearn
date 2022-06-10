using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform FirePoint;
    
    public GameObject enemyBulletPrefab;
    
    Transform canvasTransform;
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", 1);
        canvas = GameObject.Find("Canvas");
        canvasTransform = canvas.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, FirePoint.position, FirePoint.rotation);

        bullet.transform.SetParent(canvasTransform);

        Invoke("Shoot", 4);

    }
}
