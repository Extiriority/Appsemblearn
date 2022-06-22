using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    public Rigidbody2D bulletBody;
    [SerializeField] GameObject Self;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
        Invoke("destroySelf", 10);
    }

    // Update is called once per frame
    void Update()
    {
        //bulletBody.transform.position = new Vector3(bulletBody.position.x + 1f, bulletBody.position.y);

        bulletBody.transform.position += bulletBody.transform.right * Time.deltaTime * 500f;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            destroySelf();
        }
        
    }

    void destroySelf()
    {
        Destroy(Self);
    }
}
