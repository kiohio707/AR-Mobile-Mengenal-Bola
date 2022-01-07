using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sistem : MonoBehaviour
{
    public static Sistem instance;
    public int ID;
    public GameObject TempatSpawn;
    public GameObject Gui_Utama;
    public GameObject[] KoleksiBola;
    public AudioClip[] SuaraBuah;
    AudioSource Suara;
    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ID = 0;
        //SpawnObject();
        Gui_Utama.SetActive(false);
        Suara = gameObject.AddComponent<AudioSource>();
    }

    public void SpawnObject()
    {
        GameObject BendaSebelumnya = GameObject.FindGameObjectWithTag("Ball");
        if (BendaSebelumnya != null) Destroy(BendaSebelumnya);

        GameObject Benda = Instantiate(KoleksiBola[ID]);
        Benda.transform.SetParent(TempatSpawn.transform, false);
        Benda.transform.localScale = new Vector3(75, 75, 75);
        TempatSpawn.GetComponent<Animation>().Play("PopUp");
        KumpulanSuara.instance.Panggil_Suara(1);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GantiBola(true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GantiBola(false);
        }
    }

    public void GantiBola(bool Kanan)
    {
        if (Kanan)
        {
            if (ID >= KoleksiBola.Length - 1)
            {
                ID = 0;
            }
            else
            {
                ID++;
            }
        }
        else
        {
            if (ID <= 0)
            {
                ID = KoleksiBola.Length - 1;
            }
            else
            {
                ID--;
            }
        }

        SpawnObject();
        PanggilSuaraBuah();
    }

    public void PanggilSuaraBuah()
    {
        Suara.clip = SuaraBuah[ID];
        Suara.Play();
    }
}
