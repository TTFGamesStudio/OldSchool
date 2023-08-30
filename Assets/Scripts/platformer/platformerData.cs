using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class platformerData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int coins = 0;
    [SerializeField] private int hearts = 3;
    [SerializeField] private Image[] heartImages;

    // Start is called before the first frame update
    void Start()
    {
        updateCoins(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCoin()
    {
        coins++;
        updateCoins();
    }

    public bool addHeart()
    {
        if (hearts <= 3)
        {
            hearts++;
            updateHearts();
            return true;
        }
        else
            return false;
    }

    public void removeHeart()
    {
        hearts--;
        updateHearts();
    }

    public void updateHearts()
    {
        if(hearts == 3)
        {
            heartImages[2].color = new UnityEngine.Color(1, 1, 1, 1);
        }
        else
        {
            heartImages[2].color = new UnityEngine.Color(1, 1, 1, 0);
        }

        if(hearts>=2)
        {
            heartImages[1].color = new UnityEngine.Color(1, 1, 1, 1);
        }
        else
        {
            heartImages[1].color = new UnityEngine.Color(1, 1, 1, 0);
        }

        if (hearts >= 1)
        {
            heartImages[0].color = new UnityEngine.Color(1, 1, 1, 1);
        }
        else
        {
            heartImages[0].color = new UnityEngine.Color(1, 1, 1, 0);
        }
    }


    private void updateCoins()
    {
        coinText.text = "Coins - " + coins;
    }
}
