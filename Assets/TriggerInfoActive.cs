using TMPro;
using UnityEngine;

public class TriggerInfoActive : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().PlayerGovoritPanel.SetActive(true);
            collision.GetComponent<PlayerController>().PlayerGovoritPanel.GetComponent<PlayerGovorit>().GovorStart(text);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().PlayerGovoritPanel.SetActive(false);
        }
    }
}
