using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [Header("Настройки объектов")]
    public Transform player;   // Ссылка на объект, за которым следим
    public Transform target;   // Ссылка на объект, который проверяем

    [Header("Настройки расстояний")]
    public float checkDistance = 5f; // Порог расстояния
    float speed;

    void Update()
    {
        if (player == null || target == null) return;

        // Считаем расстояние между объектами
        float distance = Vector2.Distance(player.position, target.position);


        // Если расстояние больше заданного порога, делаем что-то

        //if (distance > checkDistance)
        //{

        //    if (distance < checkDistance + 1)
        //    {
        //        if(speed>0)
        //        GetComponent<EnemyController>().moveSpeed = speed;
        //    }
        //    else
        //    {
        //        if (GetComponent<EnemyController>().moveSpeed != 0)
        //        {
        //            speed = GetComponent<EnemyController>().moveSpeed;
        //            GetComponent<EnemyController>().moveSpeed = 0;
        //        }

        //    }
        //}
    }
}
