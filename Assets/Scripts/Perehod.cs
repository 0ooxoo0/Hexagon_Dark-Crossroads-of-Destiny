using System.Collections;
using UnityEngine;

public class Perehod : MonoBehaviour
{
    public Transform obj1;
    public Transform obj2;


    public int l = 0;
    public int i = 0;
    public int j = 0;

    public bool start;
    public bool _perehod = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created  -68.5
    void Start()
    {
        //StartCoroutine(perehod());
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            if(_perehod)
            StartCoroutine(perehod());
            else
                StartCoroutine(Zahod());

            start = false;
        }
    }

    IEnumerator perehod()
    {
        GameObject One = transform.GetChild(0).gameObject;
        GameObject Two = transform.GetChild(1).gameObject;
        while (true)
        {
            if (j < Two.transform.childCount)
            {
                if (i < Two.transform.GetChild(j).transform.childCount)
                {
                    if (l < Two.transform.GetChild(j).GetChild(i).transform.childCount)
                    {
                        One.transform.GetChild(j).GetChild(i).GetChild(l).gameObject.SetActive(false);
                        Two.transform.GetChild(j).GetChild(i).GetChild(l).gameObject.SetActive(false);
                        l++;
                    }
                    else
                    {
                        l = 0;
                        i++;
                    }
                }
                else
                {
                    i = 0;
                    j++;
                }
            }
            else
            {
                _perehod = false;
                yield return null;
            }
                yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator Zahod()
    {
        GameObject One = transform.GetChild(0).gameObject;
        GameObject Two = transform.GetChild(1).gameObject;
        l = 9;
        i = 2;
        j = 4;
        while (true)
        {
            if (j > 0)
            {
                if (i > 0)
                {
                    if (l > 0)
                    {
                        One.transform.GetChild(j).GetChild(i).GetChild(l).gameObject.SetActive(true);
                        Two.transform.GetChild(j).GetChild(i).GetChild(l).gameObject.SetActive(true);
                        l--;
                    }
                    else
                    {
                        l = 9;
                        i--;
                    }
                }
                else
                {
                    i = 2;
                    j--;
                }
            }
            else
            {
                _perehod = true;
                yield return null;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }
}
