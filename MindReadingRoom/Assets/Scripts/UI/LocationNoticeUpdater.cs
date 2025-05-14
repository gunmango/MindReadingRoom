using TMPro;
using UnityEngine;

public class LocationNoticeUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(string shelfIndex)
    {
        _text.text = $"선반 {shelfIndex}를 찾아보자";
    }
}
