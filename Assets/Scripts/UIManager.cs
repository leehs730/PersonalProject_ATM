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

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI currentMoneyText;
    public TextMeshProUGUI depositMoneyText;
    public Button confirmButton;


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
        deposit.SetActive(true);

    }

    public void OnClickWithdrawal()
    {
        Debug.Log("출금 예시");
        chooseButton.SetActive(false);
        withdrawal.SetActive(true);
    }
}
