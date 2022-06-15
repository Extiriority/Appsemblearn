using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovement : MonoBehaviour
{

    public GameObject target;
    [SerializeField] public float rotSpeed = 20;
    [SerializeField] public float circleSpeed = 1.5f;
    [SerializeField] public float approachSpeed = 0.5f;
    private EnemyHealth enemyHealth;
    private Rigidbody2D body;
    Transform TargetTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        TargetTransform = target.transform;
        enemyHealth = GetComponent<EnemyHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // erase any position difference in the Z axis
        // direction will be a flat vector in the global XY plane without depth information
        Vector2 targetDirection = TargetTransform.position - transform.position;

        // Now use Lerp as you did
        transform.right = Vector3.Lerp(transform.right, targetDirection, rotSpeed * Time.deltaTime);

        body.transform.position += body.transform.right * approachSpeed;
        body.transform.position += body.transform.up * circleSpeed;


        body.transform.position = new Vector2(Mathf.Clamp(body.transform.position.x, 0f, Screen.width), Mathf.Clamp(body.transform.position.y, 0f, Screen.height));


        if (enemyHealth.enemyHealth == 0)
        {
            rotSpeed = 0;
            circleSpeed = 0;
            approachSpeed = 0;
        }
        
    }
    
}
