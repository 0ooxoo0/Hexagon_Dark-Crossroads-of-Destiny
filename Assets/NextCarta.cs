using System.Collections.Generic;
using UnityEngine;

public class NextCarta : MonoBehaviour
{
    public List<GameObject> DiactiveCart;
    public List<GameObject> ActiveCart;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { int i=0;
            while (true)
            {
                if (i>= DiactiveCart.Count && i>= ActiveCart.Count)
                    return;

                if(DiactiveCart.Count>i)
                DiactiveCart[i].SetActive(false);

                if(ActiveCart.Count>i)
                ActiveCart[i].SetActive(true);

                i++;
            }
        }
    }
}
