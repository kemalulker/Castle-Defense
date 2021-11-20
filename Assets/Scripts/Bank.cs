using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] TextMeshProUGUI displayBalance;
    
    int currentBalance = 0;
    public int CurrentBalance { get => currentBalance; }

    void Awake() 
    {
        currentBalance = startingBalance;
        UpdateBalanceUI();
    }
    
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalanceUI();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance <= 0)
        {
            currentBalance = 0;
        }
        UpdateBalanceUI();
    }

    void UpdateBalanceUI()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }
}
