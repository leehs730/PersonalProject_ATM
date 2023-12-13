using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject chooseButton;
    public GameObject deposit;
    public GameObject withdrawal;
    public GameObject Message;
    

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI currentMoneyText;
    public TextMeshProUGUI depositMoneyText;
    public Button confirmButton;
    public TMP_InputField customDMoneyInput;
    public TMP_InputField customWMoneyInput;
    public string customMoney;
    public TextMeshProUGUI MSG;
    public bool inOutbool;

    public UserData userData;

    private void Start()
    {
        userData.userName = "이형석";
        userData.sixPassNumber = 123450;
        userData.currentMoney = 100000;
        userData.depositMoney = 50000;
        UpdateUI();
    }

    private void UpdateUI()
    {
        nameText.text = userData.userName;
        currentMoneyText.text = "현재 금액: " + userData.currentMoney;
        depositMoneyText.text = "예치 금액: " + userData.depositMoney;
    }

    public void OnClickDeposit()
    {
        Debug.Log("입금 예시");
        chooseButton.SetActive(false);
        inOutbool = true;
        deposit.SetActive(true);

    }

    public void OnClickWithdrawal()
    {
        Debug.Log("출금 예시");
        chooseButton.SetActive(false);
        inOutbool = false;
        withdrawal.SetActive(true);
    }

    public void OnClickMoney5()
    {
        CheckInOut(50000);
        chooseButton.SetActive(true);
    }

    public void OnClickMoney3()
    {
        CheckInOut(30000);
        chooseButton.SetActive(true);
    }

    public void OnClickMoney1()
    {
        CheckInOut(10000);
        chooseButton.SetActive(true);
    }

    public void CancelButton()
    {
        deposit.SetActive(false);
        withdrawal.SetActive(false);
        chooseButton.SetActive(true);
    }

    public void CheckInOut(int money)
    {
        if (inOutbool)
        {
            userData.Deposit(money);
            deposit.SetActive(false);
            UpdateUI();
        }

        else
        {
            userData.Withdrawal(money);
            withdrawal.SetActive(false);
            UpdateUI();
        }
    }

    public void CustomDeposit()
    {
        userData.currentMoney -= int.Parse(customDMoneyInput.text);
        userData.depositMoney += int.Parse(customDMoneyInput.text);
        UpdateUI();
        deposit.SetActive(false);
        chooseButton.SetActive(true);
    }

    public void CustomWithdrawal()
    {
        userData.currentMoney += int.Parse(customWMoneyInput.text);
        userData.depositMoney -= int.Parse(customWMoneyInput.text);
        UpdateUI();
        withdrawal.SetActive(false);
        chooseButton.SetActive(true);
    }
}
