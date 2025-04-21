using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinicartaItem : MonoBehaviour
{
    public Transform target;
    [SerializeField] float Offset;
    Image image;
    public bool Preduprejdenie;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void UgasStart(int Mnojetel)
    {
        Preduprejdenie = false;
        if (image.color.a <= 0)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        //Debug.Log("image.color.a: " + image.color.a);
        if (image.color.a > 1)
            image.color = new Vector4(image.color.r, image.color.b, image.color.g, 1);
        image.color = new Vector4(image.color.r, image.color.b, image.color.g, image.color.a - (Time.deltaTime * 7.5f / Mnojetel));
        //StartCoroutine(Ugasanie());
    }
    public void PoyavlenieStart(int Mnojetel)
    {
        Preduprejdenie = true;
        if (image.color.a >= 1)
            return;
        //Debug.Log("image.color.a: " + image.color.a);
        if (image.color.a <= 0)
        {

            gameObject.SetActive(true);
            image.color = new Vector4(image.color.r, image.color.b, image.color.g, 0);
        }
        image.color = new Vector4(image.color.r, image.color.b, image.color.g, image.color.a + (Time.deltaTime * 5 / Mnojetel));

        //StartCoroutine(Poyavlenie());
    }

    public void Update()
    {
        Vector2 direction = transform.position - transform.parent.position;

        // Вычисляем угол в радианах и конвертируем его в градусы
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Устанавливаем поворот объекта. В 2D обычно вращаем вокруг оси Z
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + Offset));
    }

    IEnumerator Ugasanie()
    {
        float a = image.color.a;
        while (image.color.r > 0)
        {
            image.color = new Vector4(image.color.r, image.color.b, image.color.g, a);
            a -= Time.deltaTime / 2;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
    IEnumerator Poyavlenie()
    {
        float a = image.color.a;
        while (image.color.r < 255)
        {
            image.color = new Vector4(image.color.r, image.color.b, image.color.g, a);
            a += Time.deltaTime / 2;
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
