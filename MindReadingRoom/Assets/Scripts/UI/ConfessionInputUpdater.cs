using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfessionInputUpdater : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField = null;
    [SerializeField] private Button submitButton = null;
    
    public TMP_InputField InputField => inputField;
    public Button SubmitButton => submitButton;
}
