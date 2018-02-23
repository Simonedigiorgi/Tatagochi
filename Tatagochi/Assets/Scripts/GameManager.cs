using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject hungerText;
    public GameObject happinessText;

    public GameObject foodPanel;
    public Sprite foodIcons;

    public GameObject player;

	void Start () {
		
	}
	
	void Update () {
        hungerText.GetComponent<Text>().text = player.GetComponent<Player>()._hunger.ToString();
        happinessText.GetComponent<Text>().text = player.GetComponent<Player>()._happiness.ToString();
	}

    void FixedUpdate() { Screen.SetResolution(480, 800, true); }

    public void buttonBehaviour(int i)
    {
        switch (i)
        {
            case (0):
            default:

                break;
            case (1):

                break;
            case (2):
                foodPanel.SetActive(!foodPanel.activeInHierarchy);
                break;
            case (3):

                break;
            case (4):
                player.GetComponent<Player>().SavePlayer();
                Application.Quit();
                break;
        }
    }

    public void SelectFood(int i)
    {
        Toggle(foodPanel);
    }

    public void Toggle(GameObject g)
    {
        if (g.activeInHierarchy)
        {
            g.SetActive(false);
        }
    }
}
