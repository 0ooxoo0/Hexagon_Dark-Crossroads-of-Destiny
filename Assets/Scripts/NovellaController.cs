using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NovellaController : MonoBehaviour
{
    [SerializeField] List<Sprite> Personi;
    [SerializeField] List<Image> Positione;
    PlayerController Player;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject Joystic;
    [SerializeField] GameObject Skills;
    SubDialogController subDialog;
    [SerializeField] bool NativeDialog;

    public void ProgressPlus()
    {
        subDialog.ProgressPlus();
        subDialog.StartNovella();
    }


    public void Dialog(List<SubVibor> vibor, SubDialogController SDC)
    {
        if (!NativeDialog)
        {
            if (Joystic != null)
            {
                Joystic.transform.GetChild(0).transform.localPosition = Vector3.zero;
                Joystic.SetActive(false);
            }
            if (Skills != null)
                Skills.SetActive(false);
        }
        List<string> Dialogs = vibor[SDC.vibor].Dialog;
        List<int> index = vibor[SDC.vibor].IndecsGovoriashego;
        //StopCoroutine(corutine(null));
        StopAllCoroutines();
        subDialog = SDC;

        if (SDC.Novellaprogress == index.Count)
            text.text = Dialogs[SDC.Novellaprogress - 1];

        if (SDC.Novellaprogress < index.Count)
        {
            StartCoroutine(corutine(Dialogs[SDC.Novellaprogress]));
            Positione[0].sprite = Personi[index[SDC.Novellaprogress] - 1];
            if (SDC.Novellaprogress == index.Count - 1)
            {
                int i = 0;
                if (SDC.buttons != null)
                {
                    if (GetComponent<Button>())
                        GetComponent<Button>().enabled = false;

                    while (i < SDC.buttons.Count)
                    {
                        SDC.buttons[i].SetActive(true);
                        SDC.buttons[i].transform.parent = SDC.buttonsObject;
                        i++;
                    }
                }
            }
        }
        else if (SDC.DiactiveDialog == false && SDC.Novellaprogress >= index.Count)
        {
            //int i = 0;
            //if (SDC.trigger)
                //SDC.trigger.SetActive(true);
            //SDC.ElementNovelli.SetActive(false);
            Debug.Log("JoysticActive");
            if (Joystic != null)
                Joystic.SetActive(true);
            if (Skills != null)
                Skills.SetActive(true);
        }
    }

    public void EndNovella()
    {
        if (Joystic != null)
            Joystic.SetActive(true);
        if (Skills != null)
            Skills.SetActive(true);
        if (gameObject != null)
            gameObject.SetActive(false);
    }

    IEnumerator corutine(string txt)
    {
        text.text = "";
        foreach (char letter in txt.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
