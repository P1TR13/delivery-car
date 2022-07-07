using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBarScript healthBar;
    public GameObject alertObject;
    public TextMeshProUGUI day, givenPackages, money, havingPackages, hp, alert;
    public int dayAmount, givenPackagesAmount, moneyAmount, havingPackagesAmount, maxPackages, maxHealth;
    public float hpAmount, speedAmount;

    private string[] alerts = { "The package is being packed", "The package has been delievered", "You don't have any packages in the car", "You are out of space"};

    // Start is called before the first frame update
    void Start()
    {
        dayAmount = 1;
        givenPackagesAmount = 0;
        moneyAmount = 0;
        havingPackagesAmount = 0;
        maxHealth = 100;
        hpAmount = maxHealth;
        speedAmount = 0f;
        maxPackages = 5;
        day.text = "Day " + dayAmount.ToString();
        givenPackages.text = givenPackagesAmount.ToString();
        money.text = moneyAmount.ToString();
        havingPackages.text = havingPackagesAmount.ToString() + "/" + maxPackages.ToString();
        hp.text = hpAmount.ToString() + "%";
        healthBar.SetMaxHealth(maxHealth);
        alertObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hpAmount <= 0)
            SceneManager.LoadScene("Menu");

    }

    public void ChangeMoney(int moneyChange)
    {
        moneyAmount += moneyChange;
        money.text = moneyAmount.ToString();
    }

    public void ChangeDay()
    {
        dayAmount++;
        day.text = "Day " + dayAmount.ToString();
    }

    public void AddGivenPackages()
    {
        givenPackagesAmount++;
        givenPackages.text = givenPackagesAmount.ToString();
    }

    public void ChangeAmountOfThePackagesInTheCar(int packagesChange)
    {
        havingPackagesAmount += packagesChange;
        havingPackages.text = havingPackagesAmount.ToString() + "/" + maxPackages.ToString();
    }

    public void ChangeHP(float hpChange)
    {
        hpAmount += hpChange;
        hp.text = hpAmount.ToString() + "%";
        healthBar.SetHealth(hpAmount);
    }

    public IEnumerator AlertDuration(float time, int number)
    {
        ShowAlert(number);
        yield return new WaitForSeconds(time);
        HideAlert();
    }

    public void ShowAlert(int alertNumber)
    {
        alert.text = alerts[alertNumber];
        alertObject.SetActive(true);
    }

    public void HideAlert()
    {
        alertObject.SetActive(false);
    }
}
