using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KartaController : MonoBehaviour
{
    float q = 0;
    float ql = 0;
    [SerializeField] GameObject Karta;
    [SerializeField] GameObject MarkerPrefab;
    [SerializeField] List<GameObject> MarkerList;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.touchCount == 1)
            transform.GetComponent<ScrollRect>().enabled = true;
        
            if (Input.touchCount == 2 && Input.GetTouch(1).phase == TouchPhase.Began)
            {
            transform.GetComponent<ScrollRect>().enabled = false;
                ql = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position) / 10;
            }
            if (Input.touchCount == 2)
            {
                transform.GetComponent<ScrollRect>().enabled = false;
                q = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position) / 10;
                float r = ((q - ql) * Time.deltaTime)/50;

            if (Karta.transform.localScale.x > 1.5 && r<0)
                Karta.transform.localScale = Karta.transform.localScale + new Vector3(r, r, 0);

            if (Karta.transform.localScale.x < 0.2 && r > 0)
                Karta.transform.localScale = Karta.transform.localScale + new Vector3(r, r, 0);

            if (Karta.transform.localScale.x > 0.2 && Karta.transform.localScale.x < 1.5)
                Karta.transform.localScale = Karta.transform.localScale + new Vector3(r, r, 0);
            }
    }

    public void resume()
    {
        Karta.transform.localScale = Vector3.one;
    }

    public void MarkerDelite(GameObject item)
    {
        MarkerList.Remove(item);
        Destroy(item);
    }

    public void MarkerInstatiate(Transform pos)
    {
        Debug.Log("MarkerInstatiate "+pos.position);
        var q = Instantiate(MarkerPrefab, transform.GetChild(0).transform);
        q.transform.localPosition = new Vector3((pos.transform.position.x * 10.799f) - 540f, (pos.transform.position.z * 10.799f) - 540f, 0);
        MarkerList.Add(q);
        pos.GetComponent<KartaMarker>().Marker = q;
        pos.GetComponent<KartaMarker>().Karta = this;
    }
}
