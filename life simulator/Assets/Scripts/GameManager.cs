using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int year;
    public int month;
    public int day;

    public TextMeshProUGUI date;
    public TextMeshProUGUI profitText;
    public TextMeshProUGUI moneyText;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public GameObject messagePanel;

    double profitValue = 0;
    double moneyValue = 0;
    int healthValue = 100;

    double dayCounter = 0;
    String[] messages = new string[] { "Message Text." };
    int messageIndex = 0;

    private void Start()
    {
        ValueSetter();
    }

    private void FixedUpdate()
    {
        DateUpdate();
        ValueSetter();
    }

    void DateUpdate()
    {
        dayCounter += Time.fixedDeltaTime;
        if (dayCounter >= 1)
        {
            day += 1;
            dayCounter = 0;
        }

        if (day > 30)
        {
            day = 1;
            month += 1;
            MoneyUpdate();
        }
        if (month > 12)
        {
            month = 1;
            day = 1;
            year += 1;
        }
    }

    void MoneyUpdate()
    {
        moneyValue += profitValue;
    }


    public void ChangeProfit(int n)
    {
        profitValue += n;
    }

    public void ChangeHealth(int n)
    {
        healthValue += n;
    }

    public void ShowMessage()
    {
        String[] x = messages;
        int messageLength = messages.Length;
        if (messageIndex < messageLength)
        {
            messagePanel.SetActive(true);
            TextMeshProUGUI messageText = messagePanel.GetComponentInChildren<TextMeshProUGUI>();
            messageText.text = messages[messageIndex];
            messageIndex += 1;
            Time.timeScale = 0;
        }
        else
        {
            messageIndex = 0;
            messagePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void ValueSetter()
    {
        date.text = year.ToString() + " / " + month.ToString() + " / " + day.ToString();
        profitText.text = profitValue.ToString("F0");
        moneyText.text = moneyValue.ToString("F0");
        if (healthValue > 100)
            healthValue = 100;
        else if (healthValue < 0)
            healthValue = 0;
        healthSlider.value = healthValue;
        healthText.text = healthValue.ToString() + " / 100";
    }
}
