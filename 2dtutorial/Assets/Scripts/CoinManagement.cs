using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagement : MonoBehaviour
{
    //Coin variable
    public int coin = 0;
    //Coint Text
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coin.ToString(); //Connect the coin text to the actual coin amount
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoinPickup()
    {
        coin = coin + 1; //Add 1 coin to the current coin amount
        coinText.text = coin.ToString(); //Update count to the current coin amount
    }
}
