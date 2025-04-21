using UnityEngine;
using UnityEngine.Rendering;

public class Blur : MonoBehaviour
{
    public Volume volume;

    void Start()
    {

    }


    void Update()
    {
        
    }

    public void VolumeBool(bool ad)
    {
        volume.enabled = ad;
    }
}
