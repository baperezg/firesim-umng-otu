using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining;
    private bool timerIsRunning = false;

    private FireAlarm alarm;
    public GameObject phoneObject, fireText, finishedText, timesUpText;
    private EmergencyDialer phone;

    public Image task1, task2, task3, task4;
    public Color doneColor, failedColor;

    public GameObject tasksAccomplished, leftRay, rigthRay;


    private void Start()
    {
        timerIsRunning = true;
        alarm = FindObjectOfType<FireAlarm>();
        phone = phoneObject.GetComponent<EmergencyDialer>();
    }

    private void Update()
    {
        if (timerIsRunning)
        {

            if (alarm.isCompleted && FireSpreadManager.Instance.allFiresOut && phone.isCompleted)
            {
                SetTaskColor(doneColor);
                tasksAccomplished.SetActive(true);
                finishedText.SetActive(true);
                leftRay.SetActive(true);
                rigthRay.SetActive(true);
                timerIsRunning = false;
                return;
            }

            if (FireSpreadManager.Instance.allFiresOut)
            {
                SetTaskColor(doneColor);
                tasksAccomplished.SetActive(true);
                fireText.SetActive(true);
                leftRay.SetActive(true);
                rigthRay.SetActive(true);
                timerIsRunning = false;
                return;
            }

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                CheckTasksCompletion();
                tasksAccomplished.SetActive(true);
                timesUpText.SetActive(true);
                leftRay.SetActive(true);
                rigthRay.SetActive(true);
            }
        }
    }
    private void SetTaskColor(Color color)
    {
        task2.color = alarm.isCompleted ? doneColor : failedColor;
        task3.color = phone.isCompleted ? doneColor : failedColor;
        task4.color = FireSpreadManager.Instance.allFiresOut ? doneColor : failedColor;
    }

    private void CheckTasksCompletion()
    {
        SetTaskColor(failedColor);

        if (alarm.isCompleted)
            task2.color = doneColor;
        if (phone.isCompleted)
            task3.color = doneColor;
        if (FireSpreadManager.Instance.allFiresOut)
             task4.color = doneColor;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
