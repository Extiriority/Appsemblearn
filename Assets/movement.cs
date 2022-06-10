using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Rigidbody2D body;
    [SerializeField] public float movementSpeed = 150f;
    float rotationSpeed;
    RectTransform rectTrans;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        rectTrans = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementSpeed > 100)
        {
            rotationSpeed = -4f / (0.01f * movementSpeed);
        }
        

        body.transform.position += body.transform.right * Time.deltaTime * movementSpeed;

        

       
        body.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * rotationSpeed);

        if (movementSpeed < 300)
            {
            if (Input.GetAxis("Vertical") > 0)
            {
                movementSpeed += Input.GetAxis("Vertical") * 7;
            }
                
            }


        if (movementSpeed > 70)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                movementSpeed += Input.GetAxis("Vertical") * 7;
            }
            
        }



        
         


         body.transform.position = new Vector2(Mathf.Clamp(body.transform.position.x, 0f, Screen.width), Mathf.Clamp(body.transform.position.y, 0f, Screen.height));

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        movementSpeed = 10;
        
            
            
        

    }
}
