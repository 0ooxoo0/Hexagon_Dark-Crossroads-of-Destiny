using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChecker : MonoBehaviour
{
    public Tilemap tilemap; // Ваш Tilemap
    WalkSound walkSound;
    public string TileName;

    private void Start()
    {
        StartCoroutine(_TileChecker());
    }

    IEnumerator _TileChecker()
    {
        while (true)
        {
            // Получаем позицию персонажа в мире
            Vector3 worldPos = transform.position;

            // Конвертируем в координаты тайлмапа
            Vector3Int cellPos = tilemap.WorldToCell(worldPos);

            // Получаем тайл
            TileBase tile = tilemap.GetTile(cellPos);

            if (tile != null)
            {
                // Если используете стандартные тайлы
                //Sprite tileSprite = tilemap.GetSprite(cellPos);
                Debug.Log("Current tile sprite: " + tile.name);

                // Пример проверки свойств
                if (tile.name == "Grass")
                {
                    Debug.Log("Это трава! изменение звука шагов.");
                }
            }
            yield return new WaitForFixedUpdate();
        }
    }
}