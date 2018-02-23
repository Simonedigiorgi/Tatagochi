using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private int hunger;
    [SerializeField] private int happiness;

    private bool serverTime;
    private int clickCount;

    void Start () {
        //PlayerPrefs.SetString("then", "01/23/2018 15:30:10");
        updateStatus();
	}
	
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);

            if(hit)
            {

                if(hit.transform.gameObject.tag == "Player")
                {
                    clickCount++;
                    if(clickCount >= 3)
                    {
                        clickCount = 0;
                        updateHappiness(1);
                    }
                }
            }
        }
    }

    public void updateStatus()
    {
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }

        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
        }

        TimeSpan ts = getTimeSpan();

        hunger -= (int)(ts.TotalHours * 2);                                                             // Sottrae ogni ora
        if(hunger < 0)
        {
            hunger = 0;
            Debug.Log("fine partita");
        }

        happiness -= (int)((100 - hunger) * (ts.TotalHours / 5));
        if (happiness < 0)
        {
            happiness = 0;
        }

        if (serverTime)
        {
            updateServer();
        }
        else
        {
            InvokeRepeating("updateDevice", 0f, 30f);
        }


    }

    private void updateServer()
    {

    }

    private void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (serverTime)
        {
            return new TimeSpan();
        }
        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    private string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int _hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int _happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public void updateHappiness(int i)
    {
        happiness += i;
        if(happiness > 100)
        {
            happiness = 100;
        }
    }

    public void SavePlayer()
    {
        if (!serverTime)
        {
            updateDevice();
            PlayerPrefs.SetInt("hunger", hunger);
            PlayerPrefs.SetInt("happiness", happiness);
        }
    }
}
