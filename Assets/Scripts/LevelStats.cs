using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelStats : MonoBehaviour
{
    public Text coinText;

    public static int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coins;

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
    }
}
