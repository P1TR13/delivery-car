using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public CarController car;
    public GameManager gameManager;
    public PackagePacking package;
    public bool isActive;
    public Button timeButton, spaceButton;

    private Animator animator;
    private int remainingSpeedUpgrades, remainingSpaceUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        remainingSpaceUpgrades = 9;
        remainingSpeedUpgrades = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && car.canMove)
        {
            isActive = !isActive;
            animator.SetBool("Active", isActive);
        }
        if (!car.canMove)
        {
            isActive = false;
            animator.SetBool("Active", isActive);
        }

        if (gameManager.moneyAmount >= 100)
        {
            if (remainingSpaceUpgrades > 0)
                spaceButton.interactable = true;
            else
                spaceButton.interactable = false;

            if (remainingSpeedUpgrades > 0)
                timeButton.interactable = true;
            else
                timeButton.interactable = false;

        }
        else
        {
            timeButton.interactable = false;
            spaceButton.interactable = false;
        }
    }

    public void ChangePackingSpeed()
    {
        package.packingSpeed = 10 / remainingSpeedUpgrades;
        gameManager.ChangeMoney(-100);
        remainingSpeedUpgrades--;
    }

    public void ChangeMaxPackages()
    {
        gameManager.maxPackages += 5;
        gameManager.ChangeAmountOfThePackagesInTheCar(0);
        gameManager.ChangeMoney(-100);
        remainingSpaceUpgrades--;
    }
}
