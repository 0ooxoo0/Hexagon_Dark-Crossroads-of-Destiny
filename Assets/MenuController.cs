using UnityEngine;
using UnityEngine.Rendering;

public class MenuController : MonoBehaviour
{
    [SerializeField] Transform CameraBlur;
    [SerializeField] Transform CameraPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMenu()
    {
        CameraBlur.transform.position = CameraPos.transform.position;
    }
}
