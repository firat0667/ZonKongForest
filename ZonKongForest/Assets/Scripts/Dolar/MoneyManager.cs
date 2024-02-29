using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class MoneyManager : MonoBehaviour
{
    public int MoneyCount;
    public Text MoneyText;

    public static MoneyManager Instance;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        GetMoney();
    }

    public void GetMoney()
    {
        MoneyCount = PlayerPrefs.GetInt(Money.MoneyString);
        MoneyText.text = MoneyCount.ToString();
    }

    public void AddMoney(int money)
    {
        MoneyCount += money;
        MoneyText.text= MoneyCount.ToString();
        PlayerPrefs.SetInt(Money.MoneyString,MoneyCount);
        GetMoney();
    }
}
