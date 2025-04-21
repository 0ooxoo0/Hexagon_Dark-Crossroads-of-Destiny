using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillsController : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        // Пример: проверка тега
        if (clickedObject.CompareTag("Skill"))
        {
            clickedObject.transform.GetChild(0).gameObject.SetActive(!clickedObject.transform.GetChild(0).gameObject.active);
            Debug.Log("Кликнут навык: " + clickedObject.name);
        }
    }

    // Наведение курсора
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject.CompareTag("Skill"))
        {
            Debug.Log("Курсор над объектом: " + clickedObject.name);
            clickedObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Курсор покинул объект
    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject.CompareTag("Skill"))
        {
            Debug.Log("Курсор ушел с объекта: " + clickedObject.name);
            clickedObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Начало зажатия
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject.CompareTag("Skill"))
        {
            isHolding = true;
            clickedObject.GetComponent<Animator>().SetBool("Upgrade", true);
            Debug.Log("Зажатие началось");
            StartCoroutine(HoldTimer(clickedObject));
        }
    }

    // Окончание зажатия
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        Debug.Log("Зажатие окончено");
    }

    // Корутина для отслеживания времени удержания
    private System.Collections.IEnumerator HoldTimer(GameObject clickedObject)
    {
        float holdTime = 0f;
        while (isHolding)
        {
            holdTime += Time.deltaTime;
            Debug.Log($"Удержание {clickedObject}: {holdTime:F1} сек");

            if(holdTime>2f)
            {
                clickedObject.GetComponent<Animator>().SetBool("Upgrade", false);
                clickedObject.GetComponent<Animator>().SetBool("Finish", true);
                clickedObject.GetComponent<Image>().raycastTarget = false;
                yield return null;
            }

            yield return null;
        }
        clickedObject.GetComponent<Animator>().SetBool("Upgrade", false);
    }
}
