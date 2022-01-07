using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungsiSentuhBuah : MonoBehaviour
{

    private void OnMouseDown()
    {
        GetComponent<Animation>().Play("button");
        Sistem.instance.PanggilSuaraBuah();
    }
}
