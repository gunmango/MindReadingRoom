using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        // 싱글톤 인스턴스가 없으면 등록
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환에도 살아남게
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 제거
        }
    }

    [SerializeField] private PopupManager popupManager = null;
    public static PopupManager PopupManager => Instance.popupManager;
    
    [SerializeField] private CursorStateManager cursorStateManager = null;
    public static CursorStateManager CursorStateManager => Instance.cursorStateManager;
    
    [SerializeField] private BookManager bookManager = null;
    public static BookManager BookManager => Instance.bookManager;

    [SerializeField] private WebManager webManager = null;
    public static WebManager WebManager => Instance.webManager;

    [SerializeField] private DataManager dataManager = null;
    public static DataManager DataManager => Instance.dataManager;

    private void Start()
    {
        // bookManager.Initialize();
    }
}