using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelected : MonoBehaviour
{
    public EventSystem m_EventSystem;

    public GameObject m_SelectedObject;

    private void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            SelectObjectOnInput();
        }
    }

    private void OnEnable()
    {
        SelectObjectOnInput();
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