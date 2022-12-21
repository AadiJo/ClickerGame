using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text ui;
    public Text gpc;
    public Text gps;
    private int amount;

    public void Increment()
    {
        GameManager.gold += GameManager.multiplier;
    }

    public void GoldPerClick()
    {
        GameManager.gold += GameManager.gps * Time.deltaTime;
    }

    public void Buy(int id)
    {
        if (id == 1 && GameManager.gold >= 25)
        {
            GameManager.multiplier += 1;
            GameManager.gold -= 25;
        }
        if (id == 2 && GameManager.gold >= 250)
        {
            GameManager.multiplier += 15;
            GameManager.gold -= 250;
        }
        if (id == 3 && GameManager.gold >= 1000)
        {
            GameManager.multiplier += 60;
            GameManager.gold -= 1000;
        }
    }


    public void Upgrade(int id)
    {
        if (id == 1 && GameManager.gold >= 50)
        {
            GameManager.gps += 1f;
            GameManager.gold -= 50;
        }
    }

    public void YourSpendAll(int id)
    {
        if (id == 1)
        {
            amount = (int) Mathf.Floor(GameManager.gold / 25);
            GameManager.gold -= 25 * amount;
            GameManager.multiplier += (1 * amount);
        }

        if (id == 2)
        {
            amount = (int)Mathf.Floor(GameManager.gold / 250);
            GameManager.gold -= 250 * amount;
            GameManager.multiplier += (15 * amount);
        }

        if (id == 3)
        {
            amount = (int)Mathf.Floor(GameManager.gold / 1000);
            GameManager.gold -= 1000 * amount;
            GameManager.multiplier += (60 * amount);
        }
    }


    public void UpgradesSpendAll(int id)
    {
        if (id == 1)
        {
            amount = (int)Mathf.Floor(GameManager.gold / 50);
            GameManager.gold -= 50 * amount;
            GameManager.gps += (1 * amount);
        }
    }

    public void Update()
    {   
        GoldPerClick();
        ui.text =  ((int)GameManager.gold).ToString();
        gpc.text = "Gold Per Click: " + GameManager.multiplier;
        gps.text = "Gold Per Second: " + GameManager.gps;
    }
}
