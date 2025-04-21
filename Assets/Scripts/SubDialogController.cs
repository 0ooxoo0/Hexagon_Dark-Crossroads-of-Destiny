using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[System.Serializable]
public class SubVibor
{
    public List<string> Dialog;
    public List<int> IndecsGovoriashego;
}

public class SubDialogController : MonoBehaviour
{
    public int Novellaprogress;

    public List<GameObject> buttons;
    public Transform buttonsObject;
   //public GameObject ElementNovelli;
    public NovellaController _NovellaController;
    public bool DiactiveDialog = false;
    public int vibor = 0;
    //public GameObject trigger;

    public CharacterComtroller playerCharacterController;
    public PlayerController playerController;



    public List<SubVibor> Vibori;

    public void StartIIsus()
    {
        int i = 0;
        while (i < buttons.Count)
        {
            buttons[i].SetActive(true);
            buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
            _NovellaController.gameObject.SetActive(true);
            StartNovella();
            buttons[i].SetActive(false);
            i++;
        }
    }

    public void End()
    {
        int i = 0;
        while (i < buttons.Count)
        {
            Destroy(buttons[i]);
            i++;
        }
        buttons = null;
            DiactiveDialog = true;

        Debug.Log("ElementNovelli.SetActive(false);");
        //ElementNovelli.SetActive(false);
        Debug.Log("Of_Corse");
        playerController.enabled = true;
    }

    public void ProgressPlus()
    {
        Novellaprogress++;
    }

    public void StartNovella()
    {
        _NovellaController.gameObject.SetActive(true);
        _NovellaController.Dialog(Vibori, gameObject.GetComponent<SubDialogController>());
    }

    public void Vibor(int vib)
    {
        Novellaprogress = 0;
        vibor = vib;
        _NovellaController.ProgressPlus();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (DiactiveDialog != true)
        {
            if (other.tag == "Player")
            {
                playerController.enabled = false;
                playerCharacterController.Move(Vector2.right, 0);
                //playerCharacterController.enabled = false;
                int i = 0;
                while (i<buttons.Count)
                {
                    buttons[i].SetActive(true);
                    buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
                    //ElementNovelli.SetActive(true);
                    StartNovella();
                    buttons[i].SetActive(false);
                    i++;
                }
            }
        }
    }
}
