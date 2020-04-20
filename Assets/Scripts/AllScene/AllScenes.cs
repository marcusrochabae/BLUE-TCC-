using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AllScenes : MonoBehaviour
{
    public EventSystem m_EventSystem;

    public GameObject m_SelectedObject;

    private bool m_click = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.None;
    }

    //private void OnEnable()
    //{
    //    SelectObjectOnInput();
    //}

    private void Update()
    {
        // Cursor.lockState = CursorLockMode.None;

        if (Input.GetMouseButtonDown(0))
        {
            SelectObjectOnInput();
        }
    }

    private void SelectObjectOnInput()
    {
        if (m_EventSystem == null)
            return;

        if (m_SelectedObject == null)
            return;

        m_EventSystem.SetSelectedGameObject(null);
        m_EventSystem.SetSelectedGameObject(m_SelectedObject);
        Canvas.ForceUpdateCanvases();
    }

}
