using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


public class GameRules : MonoBehaviour
{
    int onInList = 0;
    List<int> pattern = new List<int>();
    System.Random rand = new System.Random();
    bool playingBack = false;
    bool redCode;
    bool blueCode;
    bool yellowCode;
    bool greenCode;

    public KeyCode pressedRed;
    public KeyCode pressedBlue;
    public KeyCode pressedYellow;
    public KeyCode pressedGreen;

    public GameObject red;
    public GameObject blue;
    public GameObject yellow;
    public GameObject green;


    // Start is called before the first frame update
    void Start()
    {
        red.gameObject.SetActive(false);
        blue.gameObject.SetActive(false);
        yellow.gameObject.SetActive(false);
        green.gameObject.SetActive(false);
        pattern.Add(rand.Next(0, 4));
        new Thread(playback).Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressedRed))
        {
            testCorrect(0);
        }

        if (Input.GetKeyDown(pressedBlue))
        {
            testCorrect(1);
        }

        if (Input.GetKeyDown(pressedYellow))
        {
            testCorrect(2);
        }

        if (Input.GetKeyDown(pressedGreen))
        {
            testCorrect(3);
        }

        //redCode
        if (redCode == true)
        {
            red.gameObject.SetActive(true);
        }

        if (redCode == false)
        {
            red.gameObject.SetActive(false);
        }

        //blueCode
        if (blueCode == true)
        {
            blue.gameObject.SetActive(true);
        }

        if (blueCode == false)
        {
            blue.gameObject.SetActive(false);
        }

        //yellowCode
        if (yellowCode == true)
        {
            yellow.gameObject.SetActive(true);
        }

        if (yellowCode == false)
        {
            yellow.gameObject.SetActive(false);
        }

        //greenCode
        if (greenCode == true)
        {
            green.gameObject.SetActive(true);
        }

        if (greenCode == false)
        {
            green.gameObject.SetActive(false);
        }
    }


    void testCorrect(int color)
    {
        if (playingBack)
            return;
        if (pattern[onInList] == color)
        {
            onInList++;
        }
        else
        {
            print("You Fail! Final score: " + pattern.Count.ToString());
            onInList = 0;
            pattern = new List<int>();
            new Thread(playback).Start();
        }
        if (onInList >= pattern.Count)
        {
            pattern.Add(rand.Next(0, 4));
            onInList = 0;
            new Thread(playback).Start();
        }
        print("Score: " + pattern.Count.ToString());                  //<<This needs to show as text on screen.
        print("Item within pattern: " + onInList.ToString());         //<<This needs to show as text on screen.
    }

    void playback()
    {
        playingBack = true;
        foreach (int color in pattern)
        {
            switch (color)
            {
                case 0:
                    redCode = true;
                    Thread.Sleep(1000);
                    redCode = false;
                    break;
                case 1:
                    blueCode = true;
                    Thread.Sleep(1000);
                    blueCode = false;
                    break;
                case 2:
                    yellowCode = true;
                    Thread.Sleep(1000);
                    yellowCode = false;
                    break;
                case 3:
                    greenCode = true;
                    Thread.Sleep(1000);
                    greenCode = false;
                    break;
            }
            Thread.Sleep(1000);
        }
        playingBack = false;
    }
}

