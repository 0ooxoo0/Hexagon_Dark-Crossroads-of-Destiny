using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualNovellaController : MonoBehaviour
{
    [SerializeField] List<Sprite> images;
    [SerializeField] List<string> strings;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image image;

    [SerializeField] int i = 0;

    private void Start()
    {
        i = 0;
        image.sprite = images[i];
        text.text = strings[i];
        i = 1;
    }

    public void Listaem()
    {
        if (i < images.Count && i < strings.Count)
        {
            image.sprite = images[i];
            text.text = strings[i];
            i++;
        }
        else
        {
            End();
        }
    }

    public void End()
    {
        gameObject.SetActive(false);
    }
}
