using UnityEngine;
using UnityEngine.UI;

public class ConfessionInputUpdater : MonoBehaviour
{
    [SerializeField] private InputField inputField = null;
    [SerializeField] private Button submitButton = null;
    
    public InputField InputField => inputField;
    public Button SubmitButton => submitButton;
}
