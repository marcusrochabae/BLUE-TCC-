using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    #region [ Singleton ]
    private static Pause m_Instance = null;

    public EventSystem m_EventSystem;

    public GameObject m_SelectedObject;

    public static Pause Instance
    {
        get { return m_Instance; }
    }

    private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else if (m_Instance != this)
            Destroy(gameObject);
    }
    #endregion

    private bool m_KeyToPause;

    private IdentificarControle m_IdentificarControle;
    public GameObject m_PausePanel;

    public bool m_IsPaused { get; private set; }

    private void Start(){
        m_IdentificarControle = FindObjectOfType(typeof(IdentificarControle)) as IdentificarControle;
    }

    private void Update()
    {
        m_KeyToPause = m_IdentificarControle.m_Start;
        if (m_KeyToPause)
            TogglePause();
    }

    private void TogglePause()
    {
        if (!m_IsPaused){
            Show();
            if (m_EventSystem == null)
                return;

            if (m_SelectedObject == null)
                return;

            m_EventSystem.SetSelectedGameObject(null);
            m_EventSystem.SetSelectedGameObject(m_SelectedObject);
            Canvas.ForceUpdateCanvases();
        }else{
            Hide();
        }
    }

    public void Show()
    {
        m_PausePanel.SetActive(true);
        m_IsPaused = !m_IsPaused;
        Time.timeScale = 0.0f;
    }

    public void Hide()
    {
        m_PausePanel.SetActive(false);
        m_IsPaused = !m_IsPaused;
        Time.timeScale = 1.0f;
    }
}