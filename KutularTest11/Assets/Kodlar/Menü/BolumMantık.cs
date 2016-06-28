using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BolumMantık : MonoBehaviour {
    public GameObject y1,y2,y3;
	// Use this for initialization
	void Start () {
        if (gameObject.name == "Level 1 Buton")
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 0)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(false);
                y2.SetActive(false);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(false);
                y2.SetActive(false);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 2)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(true);
                y2.SetActive(false);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 3)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(true);
                y2.SetActive(true);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 4)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(true);
                y2.SetActive(true);
                y3.SetActive(true);
            }
        }
        else
        {
            if (PlayerPrefs.GetInt(gameObject.name) == 0)
            {
                GetComponent<Button>().interactable = false;
                y1.SetActive(false);
                y2.SetActive(false);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 1)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(false);
                y2.SetActive(false);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 2)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(true);
                y2.SetActive(false);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 3)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(true);
                y2.SetActive(true);
                y3.SetActive(false);
            }
            if (PlayerPrefs.GetInt(gameObject.name) == 4)
            {
                GetComponent<Button>().interactable = true;
                y1.SetActive(true);
                y2.SetActive(true);
                y3.SetActive(true);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
    }
}
