using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartaMarker : MonoBehaviour
{
    public GameObject Marker;
    public KartaController Karta;

    public void DeleteMarker()
    {
        Karta.MarkerDelite(Marker);
    }
}
