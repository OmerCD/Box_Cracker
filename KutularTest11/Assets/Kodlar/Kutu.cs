using UnityEngine;
using System.Collections;

public class Kutu : MonoBehaviour {
    bool patlak;
<<<<<<< HEAD
=======
    //Hasan sen topsun
>>>>>>> origin/master
    public bool Patlak
    {
        get
        {
            return patlak;
        }

        set
        {
            patlak = value;
        }
    }

    void OnMouseUpAsButton()
    {
        KutuKontrol.tiklananKutu = (Vector2)transform.position;
    }
    public bool AynıRenk(Kutu DiğerKutu)
    {
        if (DiğerKutu == null)
            return false;
        return GetComponent<Renderer>().material.color == DiğerKutu.GetComponent<Renderer>().material.color;
    }
	// Use this for initialization
	void Start () {
        patlak = false;
	}
	
	// Update is called once per frame
	void Update () {
        float x = transform.position.x;
        float y = transform.position.y;
        if (y > 0 && !KutuKontrol.KutuVarmı(x, y - 1))
        {
            while (y > 0 && !KutuKontrol.KutuVarmı(x, y - 1))
            {
                y--;
            }
            transform.position = new Vector2(x, y);
        }
        else if (y==0 && !KutuKontrol.KutuVarmı(x-1,0))
        {
            while (x>0 && !KutuKontrol.KutuVarmı(x-1,0))
            {
                x--;
            }
            transform.position = new Vector2(x, y);
        }
    }
}
