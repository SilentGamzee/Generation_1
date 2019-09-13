using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSlot : MonoBehaviour
{
    public Button spin;
    public Image icon1;
    public Image icon2;
    public Image icon3;
    public Sprite[] icons;
    public Text winner;
    public Text bet;
    public Text credits;


    private bool isShow;
    private float timeRemaining = 0f;
    int points = 100;
    int win = 0;
    int[] ic = { 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        isShow = false;
        spin.onClick.AddListener(OnSpin);
        icon1.GetComponent<Image>().sprite = icons[Random.Range(0, icons.Length - 1)];
        icon2.GetComponent<Image>().sprite = icons[Random.Range(0, icons.Length - 1)];
        icon3.GetComponent<Image>().sprite = icons[Random.Range(0, icons.Length - 1)];
        InvokeRepeating("LaunchProjectile", 2.0f, 0.2f);
        credits.text = "Points: " + points.ToString();
        winner.text = "WIN: 0";
        bet.text = "BET: 1";
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            Debug.Log("Waitting..." + timeRemaining);
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0) { isShow = false; chechWin(); }
        }
    }

    void OnSpin()
    {
        isShow = true;
        timeRemaining = 3.0f;

        points -= 2;
        credits.text = "Points: " + points.ToString();
    }

    void LaunchProjectile()
    {
        if (isShow)
        {
            ic[0] = Random.Range(0, icons.Length);
            ic[1] = Random.Range(0, icons.Length);
            ic[2] = Random.Range(0, icons.Length);
            icon1.GetComponent<Image>().sprite = icons[ic[0]];
            icon2.GetComponent<Image>().sprite = icons[ic[1]];
            icon3.GetComponent<Image>().sprite = icons[ic[2]];
        }
    }

    void chechWin()
    {
        if (ic[0] == ic[1] || ic[0] == ic[2] || ic[1] == ic[2])
        {
            win += 1;
            points += 3;
        }
        if (ic[0] == ic[1] && ic[0] == ic[2])
        {
            win += 1;
            points += 10;
        }
        credits.text = "Points: " + points.ToString();
        winner.text = "WIN: " + win.ToString();
    }

}
