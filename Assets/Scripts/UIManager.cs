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

    private void Start()    // 시작할 사용자의 데이터 선언
    {
        userData.userName = "이형석";
        userData.sixPassNumber = 123450;
        userData.currentMoney = 100000;
        userData.depositMoney = 50000;
        UpdateUI();
    }

    private void UpdateUI() // 변수가 수정됨에 따른 UI에 들어가는 값 업데이트
    {
        nameText.text = userData.userName;
        currentMoneyText.text = "현재 금액: " + userData.currentMoney;
        depositMoneyText.text = "예치 금액: " + userData.depositMoney;
    }

    public void OnClickDeposit()
    {
        chooseButton.SetActive(false);
        inOutbool = true;
        deposit.SetActive(true);

    }

    public void OnClickWithdrawal()
    {
        chooseButton.SetActive(false);
        inOutbool = false;
        withdrawal.SetActive(true);
    }

    public void OnClickMoney5()
    {
        CheckInOut(50000);
    }

    public void OnClickMoney3()
    {
        CheckInOut(30000);
    }

    public void OnClickMoney1()
    {
        CheckInOut(10000);
    }

    public void CancelButton()
    {
        deposit.SetActive(false);
        withdrawal.SetActive(false);
        chooseButton.SetActive(true);
    }

    public void CheckInOut(int money)
    {
        if (userData.currentMoney < money && inOutbool) ActiveMessage();

        else if (userData.depositMoney < money && !inOutbool) ActiveMessage();

        else
        {
            if (inOutbool)
            {
                userData.Deposit(money);
                deposit.SetActive(false);
                UpdateUI();
                chooseButton.SetActive(true);
            }

            else
            {
                userData.Withdrawal(money);
                withdrawal.SetActive(false);
                UpdateUI();
                chooseButton.SetActive(true);
            }
        }
    }        

    public void CustomDeposit()
    {
        int dmoney = int.Parse(customDMoneyInput.text);
        if (userData.currentMoney < dmoney && inOutbool) ActiveMessage();
        else
        {
            userData.currentMoney -= dmoney;
            userData.depositMoney += dmoney;
            UpdateUI();
            deposit.SetActive(false);
            chooseButton.SetActive(true);
        }
        
    }

    public void CustomWithdrawal()
    {
        int wmoney = int.Parse(customWMoneyInput.text);
        if (userData.depositMoney < wmoney && !inOutbool) ActiveMessage();
        else
        {
            userData.currentMoney += wmoney;
            userData.depositMoney -= wmoney;
            UpdateUI();
            withdrawal.SetActive(false);
            chooseButton.SetActive(true);
        }        
    }

    public void ActiveMessage()
    {
        Message.SetActive(true);
        MSG.text = inOutbool ? "잔액이 부족합니다." : "출금할 금액이 부족합니다.";
    }

    //public void CheckDMoeny(int money)
    //{
    //    if(userData.currentMoney < money)
    //    {
    //        Message.SetActive(true);
    //        MSG.text = "잔액이 부족합니다.";
    //    }
    //}

    //public void CheckWMoney(int money)
    //{
    //    if(userData.depositMoney < money)
    //    {
    //        Message.SetActive(true);
    //        MSG.text = "출금할 금액이 부족합니다.";
    //    }
    //}

    public void TurnOffMessage()
    {
        Message.SetActive(false);
    }

}
