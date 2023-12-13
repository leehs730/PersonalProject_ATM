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

    public void OnClickDeposit() // 입금 버튼을 클릭 시 입금할 금액 메뉴가 뜸
    {
        chooseButton.SetActive(false);
        inOutbool = true;
        deposit.SetActive(true);

    }

    public void OnClickWithdrawal() // 출금 버튼을 클릭 시 출금 할 금액 메뉴가 뜸
    {
        chooseButton.SetActive(false);
        inOutbool = false;
        withdrawal.SetActive(true);
    }

    public void OnClickMoney5() // 입출금의 5만원을 할당하는 버튼
    {
        CheckInOut(50000);
    }

    public void OnClickMoney3() // 입출금의 3만원을 할당하는 버튼
    {
        CheckInOut(30000);
    }

    public void OnClickMoney1() // 입출금의 1만원을 할당하는 버튼
    {
        CheckInOut(10000);
    }

    public void CancelButton() // 취소 버튼으로 다시 메인 화면으로 돌아감
    {
        deposit.SetActive(false);
        withdrawal.SetActive(false);
        chooseButton.SetActive(true);
    }

    public void CheckInOut(int money) // 입금인지 출금인지 확인과, 초과 금액을 확인하는 메서드
    {
        // 입금 금액이 현재 금액을 넘은것과 현재 메뉴의 상태가 입금일 시, 입금불가 메시지 팝업창 출력
        if (userData.currentMoney < money && inOutbool) ActiveMessage(); 

        // 출금 금액이 예치 금액을 넘은 것과 현재 메뉴의 상태가 출금일 시, 출금불가 메시지 팝업창 출력
        else if (userData.depositMoney < money && !inOutbool) ActiveMessage();

        else
        {
            if (inOutbool) // 정상 입금 후 매인 메뉴로 이동
            {
                userData.Deposit(money);
                deposit.SetActive(false);
                UpdateUI();
                chooseButton.SetActive(true);
            }

            else // 정상 출금 후 메인 메뉴로 이동
            {
                userData.Withdrawal(money);
                withdrawal.SetActive(false);
                UpdateUI();
                chooseButton.SetActive(true);
            }
        }
    }        

    public void CustomDeposit()  // 직접 입금 금액을 입력 후, 초과인지 확인 후 입금
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

    public void CustomWithdrawal() // 직접 출금 금액을 입력 후, 초과인지 확인 후 출금
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

    public void ActiveMessage() // 입출금 잔액이 부족하다는 메시지를 팝업창의 텍스트 안에 삽입 후 출력
    {
        Message.SetActive(true);
        MSG.text = inOutbool ? "잔액이 부족합니다." : "출금할 금액이 부족합니다.";
    }

    public void TurnOffMessage() // 메시지 팝업 창에서 확인 버튼을 누르면 끄도록 하는 버튼 메서드
    {
        Message.SetActive(false);
    }

}
