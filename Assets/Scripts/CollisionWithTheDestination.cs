using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithTheDestination : MonoBehaviour
{
    public GameManager gameManager;
    public Destination destination;
    
    private int randomMoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(gameManager.havingPackagesAmount > 0)
                {
                    gameManager.ChangeAmountOfThePackagesInTheCar(-1);
                    gameManager.AddGivenPackages();
                    randomMoney = Random.Range(5, 15);
                    gameManager.ChangeMoney(randomMoney);
                    destination.ChangePosition();
                    gameManager.ShowAlert(1);
                    StartCoroutine(gameManager.AlertDuration(1f, 1));
                }
                else
                {
                    StartCoroutine(gameManager.AlertDuration(1f, 2));
                }
            }
        }
    }
}
