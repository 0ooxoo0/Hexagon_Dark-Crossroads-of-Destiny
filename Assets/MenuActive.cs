using UnityEngine;
using UnityEngine.InputSystem;

public class MenuActive : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel; // Ссылка на панель меню
    [SerializeField] private InputActionReference menuAction; // Действие для открытия меню

    private void OnEnable()
    {
        // Включаем действие и подписываемся на событие
        menuAction.action.Enable();
        menuAction.action.performed += ToggleMenu;
    }

    private void OnDisable()
    {
        // Отписываемся от события при выключении
        menuAction.action.performed -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        // Переключаем видимость меню
        menuPanel.SetActive(!menuPanel.activeSelf);
        menuPanel.GetComponent<MenuController>().StartMenu();
    }
}