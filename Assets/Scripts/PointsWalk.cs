using UnityEngine;

public class PointsWalk : MonoBehaviour
{
    public EnemyController enemy;
    public int index = 0;
    void Start()
    {
        if (enemy != null)
            enemy.PointsWalk = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointNext()
    {

        index++; 
        if (index >= transform.childCount)
        {
            Debug.LogWarning("Index максимальный");
            enemy.Target = null;
            enemy.Start();
            return;
        }
        else
            enemy.Target = transform.GetChild(index);
    }
}
