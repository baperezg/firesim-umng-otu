using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeRemaining = 60; 
    private bool timerIsRunning = false;
    private FireAlarm alarm;
    private Fire fire;
    public GameObject phoneObject;
    private EmergencyDialer phone;


    private void Start()
    {
        timerIsRunning = true;
        alarm = FindObjectOfType<FireAlarm>();
        fire = FindObjectOfType<Fire>();
        phone = phoneObject.GetComponent<EmergencyDialer>();
    }

    private void Update()
    {
        if (timerIsRunning)
        {

            if (alarm.isCompleted && fire.isCompleted && phone.isCompleted)
            {
                Debug.Log("All tasks completed!");
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
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
