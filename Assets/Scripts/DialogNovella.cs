using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNovella : MonoBehaviour
{
    [SerializeField] GameObject DialogPanel;
    [SerializeField] NovellaController novellaController;
    PlayerController Player;
    [SerializeField] int persona;
    void Start()
    {

    }


    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        novellaController.InstatiatePersoni(0, 0);
    //        novellaController.InstatiatePersoni(persona, 2);
    //        Player = other.GetComponent<PlayerController>();
    //        Player.IdleTrue();
    //        DialogPanel.SetActive(true);
    //        Player.enabled = false;
    //    }
    //}
}
