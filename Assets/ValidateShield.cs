using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateShield : MonoBehaviour
{
    [SerializeField] GameObject customer;
    [SerializeField] GameObject victoryRoyale;
    [SerializeField] GameObject youSuck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            victoryRoyale.SetActive(true);
        }
    }

    public void ValidateCurrentShield(GameObject shields)
    {
        GameObject shield = shields.GetComponentInChildren<Shield>().gameObject;
        ShieldSO requestedShield = customer.GetComponent<Customer>().requestedShield;

        if(shield.name == requestedShield.shieldType.name && shields.GetComponent<ShieldManager>().currentColor == requestedShield.color)
        {
            victoryRoyale.SetActive(true);
        }
        else
        {
            youSuck.SetActive(true);
        }
    }
}
