using UnityEngine;
using UnityEngine.Events;

public class QuestUpdaterTrigger : MonoBehaviour
{
    public int id = 0;
    public int count = 1;
    [SerializeField] bool trigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")&& trigger)
            QuestBus.GetInstance().OnUpdateCounter?.Invoke(id, count);
    }
    public void QuestUpdate()
    {
            QuestBus.GetInstance().OnUpdateCounter?.Invoke(id, count);
    }
}
