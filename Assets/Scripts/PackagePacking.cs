using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackagePacking : MonoBehaviour
{
    public GameManager gameManager;
    public Slider slider;
    public CarController car;
    public GameObject fill, boarder;
    public Post post;
    public float progress;
    public int packingSpeed;

    private void Awake()
    {
        packingSpeed = 1;
        fill.SetActive(false);
        boarder.SetActive(false);
    }

    public IEnumerator PackPackage()
    {
        gameManager.ShowAlert(0);
        yield return new WaitForSeconds(.1f);

        progress += packingSpeed;
        slider.value = progress;

        if (progress < 100)
        {
            StartCoroutine(PackPackage());
        }
        else
        {
            StopCoroutine(PackPackage());
            gameManager.ChangeAmountOfThePackagesInTheCar(1);
            post.canGetPackage = true;
            car.canMove = true;
            fill.SetActive(false);
            boarder.SetActive(false);
            slider.value = 0;
            gameManager.HideAlert();
        }
    }
}
