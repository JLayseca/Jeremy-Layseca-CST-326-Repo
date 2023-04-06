using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public static int HP;
    public int startHP = 20;
    public static int Rounds;

    void Start()
    {
        Money = startMoney;
        HP = startHP;

        Rounds = 0;
    }
}
