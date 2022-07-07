using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameManager gameManager;
    public GameObject winPanel;
    public GameObject mainCanvas;
    public TextMeshProUGUI winText;

    private int currentSecond;
    private int currentMinutes;

    private Coroutine myCoroutine;

    private void Start()
    {
        RestartTimer();
    }

    public void StartTimer()
    {
        myCoroutine = StartCoroutine(TimerCounter());
    }

    public void StopTimer()
    {
        StopCoroutine(myCoroutine);
    }

    private IEnumerator TimerCounter()
    {

        yield return new WaitForSeconds(1f);

        currentSecond-=1;

        if (currentSecond < 00 && currentMinutes > 00)
        {
            currentSecond = 59;
            currentMinutes--;
        }

        RefreshTimer();

        if (currentMinutes > 0 || currentSecond > 0)
            myCoroutine = StartCoroutine(TimerCounter());
        else
        {
            StopTimer();
            if (gameManager.dayAmount < 7)
            {
                gameManager.ChangeDay();
                RestartTimer();
            }
        }
    }

    private void Update()
    {
        if (gameManager.dayAmount == 7 && currentMinutes == 0 && currentSecond <= 0)
        {
            mainCanvas.SetActive(false);
            winPanel.SetActive(true);
            Time.timeScale = 0f;
            winText.text = "Congratulations!\nYou have delivered " + gameManager.givenPackagesAmount + " packages!";
        }
    }

    private void RefreshTimer()
    {
        timer.text = currentMinutes.ToString("00") + ":" + currentSecond.ToString("00");
    }

    private void RestartTimer()
    {
        currentMinutes = 5;
        currentSecond = 0;
        RefreshTimer();
        StartTimer();
    }
}
