using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{

    public Transform FirePoint;
    public Transform FirePoint2;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    [SerializeField] public float currentBulletType = 1;
    public Transform Canvas;
    private bool CanShoot = true;

    public bool bullet1Selected = false;
    public bool bullet2Selected = false;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (CanShoot)
            {
                Shoot();

                DisableShooting();
                
            }
            

        }

       
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        
        bullet.transform.SetParent(Canvas);
        GameObject bullet2 = Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);

        bullet2.transform.SetParent(Canvas);
    }

    void CanShootAgain()
    {
        CanShoot = true;
    }

    void DisableShooting( )
    {
        CanShoot = false;
        Invoke("CanShootAgain", 1);
    }



    public void SetBulletTo1 ()
    {
        if (bullet1Selected == true)
        {
            currentBulletType = 1;
        }

        bullet1Selected = false;
    }

    public void SetBulletTo2()
    {
        if (bullet2Selected == true)
        {
            currentBulletType = 2;
        }

        bullet2Selected = false;
    }

   


    public void SelectBullet1()
    {
        bullet1Selected = true;
        bullet2Selected = false;
    }

    public void SelectBullet2()
    {
        bullet2Selected = true;
        bullet1Selected = false;
    }
}

