using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KutuKontrol : MonoBehaviour {
    public GameObject kutu;
    public static int genişlik = 6, yükseklik = 8;
    public static Vector2 tiklananKutu = new Vector2(-1,-1);
    Color[] renkler = new Color[] { Color.red, Color.blue, Color.yellow, Color.green };
    public int kutuSayısı = 64;
    public int yıldız1, yıldız2, yıldız3;
    int puan = 0;
    float kontrolZamanlayıcı = 2f;
    public static Kutu KutuVarmı(float x,float y)
    {
        Kutu[] kutular = FindObjectsOfType<Kutu>();
        foreach (Kutu item in kutular)
        {
            if ((Vector2)item.transform.position== new Vector2(x,y))
            {
                return item;
            }
        }
        return null;
    }
    void KutuKoy(float x,float y)
    {
        int index = Random.Range(0, renkler.Length);
        GameObject temp = (GameObject)Instantiate(kutu, new Vector2(x, y), Quaternion.identity);
        temp.GetComponent<Renderer>().material.color = renkler[index];
    }
    public void KutularıKaldır(List<Kutu> Kutular)
    {
        foreach (Kutu item in Kutular)
        {
            item.Patlak = true;
            Destroy(item.gameObject);
        }
    }
    void BölümüBitirme()
    {
        int sonrakiBolum;
        if (HamleKaldımı() == false)// YAPILACAK HAMLE KALMADIYSA OYUNU BİTİR
        {
            //Application.LoadLevel("Anamenü");
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelMenü");
            if (puan >= yıldız1 && puan < yıldız2)
            {
                Debug.Log(puan.ToString());
                sonrakiBolum = int.Parse(Application.loadedLevelName) + 1;
                PlayerPrefs.SetInt("Level " + sonrakiBolum.ToString() + " Buton", 1);
                PlayerPrefs.SetInt("Level " + Application.loadedLevelName + " Buton", 2);
            }
            if (puan >= yıldız2 && puan < yıldız3)
            {
                Debug.Log("iki yıldız");
                sonrakiBolum = int.Parse(Application.loadedLevelName) + 1;
                PlayerPrefs.SetInt("Level " + sonrakiBolum.ToString() + " Buton", 1);
                PlayerPrefs.SetInt("Level " + Application.loadedLevelName + " Buton", 3);
            }
            if (puan >= yıldız3)
            {
                Debug.Log("üç yıldız");
                sonrakiBolum = int.Parse(Application.loadedLevelName) + 1;
                PlayerPrefs.SetInt("Level " + sonrakiBolum.ToString() + " Buton", 1);
                PlayerPrefs.SetInt("Level " + Application.loadedLevelName + " Buton", 4);
            }
        }
        //0 = Bölüm kitli
        //1= Bölüm Açık
        //2 = 1 Yıldız
        //3 = 2 Yıldız
        //4 = 3 YIldız
    }
    void Update () {
        kontrolZamanlayıcı -= Time.deltaTime;
        if (kutuSayısı > 0)
        {
            for (int x = 0; x < genişlik; x++)
            {
                if (!KutuVarmı(x, yükseklik - 1))
                {
                    KutuKoy(x, yükseklik - 1);
                    kutuSayısı--;
                    
                }
            }
        }
        if (tiklananKutu!=new Vector2(-1,-1))
        {
            
            List<Kutu> patlatılacakKutular = TaşırmaAlgoritması((int)tiklananKutu.x, (int)tiklananKutu.y, new bool[genişlik,yükseklik],KutuVarmı(tiklananKutu.x,tiklananKutu.y).GetComponent<Renderer>().material.color);
            if (patlatılacakKutular.Count>2)
            {
                puan += Puanla(patlatılacakKutular);
                KutularıKaldır(patlatılacakKutular);
                kontrolZamanlayıcı = 2f;
            }

            tiklananKutu = new Vector2(-1, -1);
            
        }
        if (kontrolZamanlayıcı<=0)
        {
            BölümüBitirme();
            kontrolZamanlayıcı = 2f;
        }
        
    }
    public bool HamleKaldımı()
    {
        for (int x = 0; x < genişlik; x++)
        {
            for (int y = 0; y < yükseklik; y++)
            {
                List<Kutu> patlatılacakKutular = new List<Kutu>();
                Kutu geç = KutuVarmı(x, y);
                if (geç!=null)
                {
                    if (!geç.Patlak)
                    {
                        patlatılacakKutular = TaşırmaAlgoritması((int)geç.transform.position.x, (int)geç.transform.position.y, new bool[genişlik, yükseklik], geç.GetComponent<Renderer>().material.color);
                        if (patlatılacakKutular.Count > 2)
                        {
                            return true;
                        }
                    }
                }            

            }
        }
        return false;
    }
    private int Puanla(List<Kutu> patlayanlar)
    {
        int puan = 1, çoklayıcı = 1;
        çoklayıcı = patlayanlar.Count / 2;
        puan = patlayanlar.Count * çoklayıcı;
        return puan;
    }
    static bool EtrafındaAynıRenkVarmı(float x,float y)
    {
        Kutu k = KutuVarmı(x, y);
        if (k!=null)
        {
            if (k.AynıRenk(KutuVarmı(x,y+1)))
            {
                return true;
            }
            else if (k.AynıRenk(KutuVarmı(x, y - 1)))
            {
                return true;
            }
            else if (k.AynıRenk(KutuVarmı(x+1, y)))
            {
                return true;
            }
            else if (k.AynıRenk(KutuVarmı(x-1, y)))
            {
                return true;
            }
        }
        return false;
    }
    public static List<Kutu> TaşırmaAlgoritması(int x, int y, bool[,] kontrolEdildi,Color Renk)
    {
        List<Kutu> patlayacak = new List<Kutu>();
        if (x >= 0 && y >= 0 && x < genişlik && y < yükseklik)
        {
            if (kontrolEdildi[x, y])
            {
                return patlayacak;
            }
            Kutu geç= KutuVarmı(x,y);
            if (geç != null)
            {
                if (!geç.Patlak)
                {
                    if (geç.GetComponent<Renderer>().material.color == Renk)
                    {
                        patlayacak.Add(geç);

                    }
                    else
                    {
                        return patlayacak;
                    }
                }
            }
            if (!EtrafındaAynıRenkVarmı(x,y))
            {
                return patlayacak;
            }
            kontrolEdildi[x, y] = true;
            patlayacak.AddRange(TaşırmaAlgoritması(x - 1, y, kontrolEdildi, Renk));
            patlayacak.AddRange(TaşırmaAlgoritması(x + 1, y, kontrolEdildi, Renk));
            patlayacak.AddRange(TaşırmaAlgoritması(x, y - 1, kontrolEdildi, Renk));
            patlayacak.AddRange(TaşırmaAlgoritması(x, y + 1, kontrolEdildi, Renk));
        }
        return patlayacak;
    }
}
