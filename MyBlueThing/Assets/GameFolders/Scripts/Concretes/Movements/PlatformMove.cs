using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlatformMove : MonoBehaviour
{
    private GameObject[] gidilecekNoktalar;
    private Vector3 aradakiMesafe;
    private int aradakiMesafeSayac;
    bool aradakiMesafeBirKereAl = true;
    bool ileriGeri = true;


    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];

        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilecekNoktalar[i].transform.SetParent(transform.parent);
        }
    }


    void FixedUpdate()
    {
        noktalaraGit();
    }

    void noktalaraGit()
    {
        if (aradakiMesafeBirKereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayac].transform.position - transform.position).normalized;
            aradakiMesafeBirKereAl = false;
        }

        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayac].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * 4;

        if (mesafe < 0.5f)
        {
            aradakiMesafeBirKereAl = true;

            if (aradakiMesafeSayac == gidilecekNoktalar.Length - 1)
            {
                ileriGeri = false;
            }

            else if (aradakiMesafeSayac == 0)
            {
                ileriGeri = true;
            }

            if (ileriGeri)
            {
                aradakiMesafeSayac++;
            }

            else
            {
                aradakiMesafeSayac--;
            }
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;   //çizilecek olanalrın rengini ayarlama
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);     //üretilen obje kadar yuvarlak şekil üretme çapını 1 yapma
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);      //ilk oluşan objeden bir sonrakine çizgi çizme
        }
    }
#endif

}

#if UNITY_EDITOR  //sadece editörde çalışır, build edilmez yük olmaz
[CustomEditor(typeof(PlatformMove))]
[System.Serializable]


class sawEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlatformMove Sawscript = (PlatformMove)target;    //yukarıda ki sawkont classında yazılan herşeyi burada sawkont. yazıp erişebilmek için yazılan kod
        if (GUILayout.Button("ÜRET", GUILayout.MinWidth(100), GUILayout.Width(100))) //unityde scripte üret isminde 100-100 boyutunda(gereksiz) bir button ekledik
        {
            GameObject yeniobjem = new GameObject();
            yeniobjem.transform.parent = Sawscript.transform; //yeni objeleri testere objesinin altina ekleyecek
            yeniobjem.transform.position = Sawscript.transform.position;
            yeniobjem.name = Sawscript.transform.childCount.ToString(); //testerenin altında oluşan objelerin(child) sayısını alıp adına onu verecek
        }
    }
}
#endif