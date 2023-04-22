using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagementScript : MonoBehaviour
{
    public int coins = 0;
    public Text coinText;
    void Start()
    {
        coinText.text = coins.ToString();
    }

    void Update()
    {

    }

    public void CoinPickup()
    {
        coins = coins + 1;
        coinText.text = coins.ToString();
    }
}
