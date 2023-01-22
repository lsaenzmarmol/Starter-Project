using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CountDown : MonoBehaviour
{

    Text countDownText;

    float timer;
    int countDownNumber = 10; 
    // Start is called before the first frame update
    void Start()
    {
        countDownText = GetComponent<Text>();
        countDownText.text = countDownNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1 && countDownNumber > 0)
        {
            countDownNumber--;
            countDownText.text = countDownNumber.ToString();
            timer = 0;

            if(countDownNumber == 0)
            {
                countDownText.text = "You Lost!";
                Player.instance.PlaySound2(Player.instance.LoseMusic);
                Time.timeScale = 0;
            } 
        }

    }
}
