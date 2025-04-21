using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _questName;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _progress;
    [SerializeField] private Image _image;
    public GameObject SelectBtn;
    public Mask mask;
    public QuestData Data { get; private set; }

    public void DescriptFalse()
    {
        mask.enabled = true;
    }
    public void DescriptTrue()
    {
        mask.enabled = false;
        if (SelectBtn != null)
            SelectBtn.SetActive(true);
    }

    private void OnEnable()
    {
        QuestBus.GetInstance().OnUpdateData += update;
    }

    private void OnDisable()
    {
        QuestBus.GetInstance().OnUpdateData -= update;
    }

    public void Highlight()
    {
        QuestBus.GetInstance().OnHighlighted?.Invoke(Data, _image);
    }

    public void Init(QuestData data)
    {
        Data = data;
        //_description.maskable = true;
        _questName.text = data.quest_name;
        _description.text = data.quest_description;
        //_description.maskable = false;
        _progress.text = $"{data.progress}\n{data.goal}"; //Прогресс
        //_description.gameObject.SetActive(false);
    }

    public void update()
    {
        _progress.text = $"{Data.progress}\n{Data.goal}"; //Прогресс
    } 
}
