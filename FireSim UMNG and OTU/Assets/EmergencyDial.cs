using UnityEngine;
using TMPro;

public class EmergencyDialer : MonoBehaviour
{
    public TMP_Text inputText; 
    public GameObject respondentsUI;
    private string dialedNumbers = "";


    public void OnNumberButtonClicked(int number)
    {
        if (dialedNumbers.Length < 3)
        {
            dialedNumbers += number.ToString();
            UpdateNumberDisplay(dialedNumbers);
        }
    }

    public void OnCallButtonPressed()
    {
        if (dialedNumbers.Length == 3)
        {
            if (dialedNumbers == "911")
            {
                ShowRespondentsOnTheWay();
            }
            else
            {
                ResetDialer();
            }
        }
    }

    private void ResetDialer()
    {
        dialedNumbers = "";
        UpdateNumberDisplay(dialedNumbers);
    }

    private void ShowRespondentsOnTheWay()
    {
        respondentsUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void UpdateNumberDisplay(string numbers)
    {
        inputText.text = numbers;
    }
}
