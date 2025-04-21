using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minicarta : MonoBehaviour
{
    public List<MinicartaItem> items;
    public Transform Player;
    public MinMaxRadius radius;
    [SerializeField] private float radCard;

    public void Start()
    {

    }

    public void Update()
    {
        for (int i = 0; i < items.Count; i++)
        {
            float dist = Vector3.Distance(items[i].target.position, Player.position);
            //Debug.Log(dist + "<=" + radius.MaxRadius);
            if (dist < radius.MaxRadius && dist > radius.MinRadius)
            {
                items[i].PoyavlenieStart(1);
                Vector2 pos = Player.position - items[i].target.position;
                pos = pos.normalized * Mathf.Clamp(dist, radCard, radCard);
                items[i].transform.localPosition = new Vector2(-pos.x, -pos.y);
            }
            else
            {
                //Debug.Log("Ugasanie");
                items[i].UgasStart(1);
            }
        }
    }
}
[System.Serializable]
public class MinMaxRadius
{
    public float MinRadius;
    public float MaxRadius;
}