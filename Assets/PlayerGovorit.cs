using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerGovorit : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private RectTransform textContainer;
    [SerializeField] private float typingSpeed;
    private Coroutine typingCoroutine;
    public void GovorStart(TextMeshProUGUI text)
    {
        if (typingCoroutine != null) StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(Govor(text));
    }

    private IEnumerator Govor(TextMeshProUGUI text)
    {
        textComponent.text = "";
        foreach (char letter in text.text.ToCharArray())
        {
            textComponent.text += letter;
            // Обновляем размер контейнера
            UpdateTextContainerSize();
            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null;
        yield return null;
    }
    private void UpdateTextContainerSize()
    {
        // Для TextMeshPro
        float preferredHeight = textComponent.preferredHeight;

        // Устанавливаем новую высоту контейнера
        textContainer.sizeDelta = new Vector2(
            textContainer.sizeDelta.x,
            preferredHeight
        );
    }
    private void OnDisable()
    {
        if(typingCoroutine!=null)
        StopCoroutine(typingCoroutine);
    }
}
