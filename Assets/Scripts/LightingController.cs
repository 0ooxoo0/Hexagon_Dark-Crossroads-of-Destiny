using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightingController : MonoBehaviour
{
    private Light2D Light;
    private int DayTime = 2;
    private Color[] DayColors = new Color[] { new Color(0.749f, 0.447f, 0.322f)/*Вечер*/, new Color(0.047f, 0.078f, 0.220f)/*Ночь*/, Color.white /*День*/ };

    private float transitionSpeed = 15f;

    private Coroutine currentTransition;
    void Start()
    {
        Light = GetComponent<Light2D>();
        ToggleLight();
    }

    //void Update()
    //{
    //    if (Toggle == true)
    //    {
    //        ToggleLight();
    //        Toggle = false;
    //    }
    //}

    public void ToggleLight()
    {
        if (currentTransition != null)
        {
            StopCoroutine(currentTransition);
        }

        currentTransition = StartCoroutine(TimeTransition(DayColors[DayTime]));
    }

    private IEnumerator TimeTransition(Color ColorTime)
    {
        Debug.Log(ColorTime);
        Color startColor = Light.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionSpeed)
        {
            Light.color = Color.Lerp(startColor, ColorTime, elapsedTime / transitionSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Light.color = ColorTime;
        yield return new WaitForSeconds(20*(DayTime+1));
        if (DayTime == 2)
            DayTime = 0;
        else
            DayTime += 1;

        ToggleLight();
    }

    private void OnDisable()
    {
        if (currentTransition != null)
        {
            StopCoroutine(currentTransition);
        }
    }
}
