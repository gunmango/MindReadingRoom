using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookContentUpdater : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private TextMeshProUGUI contentText = null;

    public void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetContent(string content)
    {
        contentText.text = content;
    }
}
