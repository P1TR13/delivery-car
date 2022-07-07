using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    public PackagePacking package;
    public CarController car;
    public GameManager gameManager;
    public GameObject fill, boarder;
    public bool canGetPackage;

    private void Start()
    {
        canGetPackage = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameManager.havingPackagesAmount < gameManager.maxPackages && canGetPackage)
            {
                canGetPackage = false;
                car.canMove = false;
                package.progress = 0;
                fill.SetActive(true);
                boarder.SetActive(true);
                StartCoroutine(package.PackPackage());
            }
            else if (Input.GetKeyDown(KeyCode.Space) && gameManager.havingPackagesAmount >= gameManager.maxPackages && canGetPackage)
            {
                StartCoroutine(gameManager.AlertDuration(1f, 3));
            }
        }
    }
}
