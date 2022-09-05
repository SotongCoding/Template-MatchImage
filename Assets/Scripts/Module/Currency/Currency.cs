using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
    private static Currency _instance;
    public static Currency Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Currency();
            }
            return _instance;
        }
    }

    public bool TrySpeendMoney(int amount, out int moneyLeft)
    {
        moneyLeft = 0;
        if (SaveData.Instance.playerCoins >= amount)
        {
            SaveData.Instance.UpdatePlayerCoins(-amount);
            moneyLeft = SaveData.Instance.playerCoins;


            return true;
        }
        return false;
    }
    public void AddCoin(int amount)
    {
        SaveData.Instance.UpdatePlayerCoins(amount);
    }
}
