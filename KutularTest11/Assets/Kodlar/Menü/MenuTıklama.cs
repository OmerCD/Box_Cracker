using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuTıklama : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
	}
    public void Buton1()
    {
        SceneManager.LoadScene("LevelMenü");
    }
    public void Buton2()
    {
        //Ses Kes
    }
    public void Buton3()
    {
        //Müzik kes, kelime yapma
    }       
}
