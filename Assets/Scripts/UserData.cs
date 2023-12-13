using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public string userName;
    public int sixPassNumber;
    public int currentMoney;
    public int depositMoney;

    public void Deposit(int money)
    {
        currentMoney -= money;
        depositMoney += money;
    }

    public void Withdrawal(int money)
    {
        depositMoney -= money;
        currentMoney += money;
    }
}
