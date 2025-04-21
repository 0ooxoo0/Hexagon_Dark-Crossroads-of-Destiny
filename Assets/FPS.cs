using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fpsText;
    [SerializeField] private float _updateInterval = 1f;

    private float _timeSinceLastUpdate;
    private int _frameCount;
    private float _fps;

    private void Awake()
    {
        if (_fpsText == null)
        {
            _fpsText = GetComponent<TextMeshProUGUI>();
        }

        _timeSinceLastUpdate = _updateInterval;
    }

    private void Update()
    {
        _frameCount++;
        _timeSinceLastUpdate -= Time.deltaTime;

        if (_timeSinceLastUpdate <= 0f)
        {
            CalculateFPS();
            UpdateDisplay();
            ResetCounters();
        }
    }

    private void CalculateFPS()
    {
        _fps = _frameCount / _updateInterval;
    }

    private void UpdateDisplay()
    {
        _fpsText.text = $"{Mathf.RoundToInt(_fps)} FPS";
    }

    private void ResetCounters()
    {
        _frameCount = 0;
        _timeSinceLastUpdate = _updateInterval;
    }
}
