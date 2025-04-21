using System.Collections;
using UnityEngine;

public class HecsagonMap : MonoBehaviour
{
    public GameObject HexPrefab;
    void Start()
    {
         CreateMap();
    }

    void Update()
    {
        
    }
    public IEnumerator CreateMap()
    {
        yield return null;
    }
}
