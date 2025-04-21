using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DropdownAnimator : MonoBehaviour
{
    public GameObject dropdownPanel; // Панель с DropDown
    public Button toggleButton;      // Кнопка для управления
    public float animationDuration = 0.5f; // Длительность анимации
    public float heightOffset = 400f; // Расстояние перемещения панели по оси Y

    public bool isOpen = false;
    private RectTransform rectTransform;
    private Vector2 visiblePosition;
    private Vector2 hiddenPosition;
    [SerializeField] private bool EnableDropDownPanel;
    [SerializeField] private GameObject SelectBtn;

    void Start()
    {
        rectTransform = dropdownPanel.GetComponent<RectTransform>();

        // Устанавливаем видимую и скрытую позиции панели
        visiblePosition = rectTransform.anchoredPosition;
        hiddenPosition = new Vector2(visiblePosition.x, visiblePosition.y + heightOffset);

        // Устанавливаем панель в скрытое положение и деактивируем её
        rectTransform.anchoredPosition = hiddenPosition;
        if (enabled == false)
            dropdownPanel.SetActive(false);

        toggleButton.onClick.AddListener(ToggleDropdown);
    }

    public void ToggleDropdown()
    {
        //StopAllCoroutines(); // Останавливаем любые текущие анимации
        if(SelectBtn!=null)
        SelectBtn.SetActive(false);
        // **Отключаем кнопку перед началом анимации**
        toggleButton.interactable = false;

        if (!isOpen)
        {
            dropdownPanel.SetActive(true);
            StartCoroutine(AnimateDropdown(hiddenPosition, visiblePosition, () =>
            {
                // **Включаем кнопку после завершения анимации**
                toggleButton.interactable = true;
            }));
        }
        else
        {
            StartCoroutine(AnimateDropdown(visiblePosition, hiddenPosition, () =>
            {
                if(enabled == false)
                dropdownPanel.SetActive(false);
                // **Включаем кнопку после завершения анимации**
                toggleButton.interactable = true;
            }));
        }

        isOpen = !isOpen;
    }

    private IEnumerator AnimateDropdown(Vector2 startPos, Vector2 endPos, System.Action onComplete = null)
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / animationDuration);
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;

        onComplete?.Invoke();
    }
}
