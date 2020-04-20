using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Chat : MonoBehaviour
{
    public static Chat Instance { get; private set; }

    // Não entendi o pq desse trecho, mas ok.
    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    [Header("Chat Box")]
    public Text m_textBox;
    public float m_timeText;
    public Dialog m_Dialog;

    public void Start()
    {
        TextAsset texto = Resources.Load<TextAsset>("teste");
        m_Dialog = JsonUtility.FromJson<Dialog>(texto.text);
    }

    public Trigger Search(string name)
    {
        return m_Dialog.Triggers.Find(x => x.Name.Contains(name));
    }

}

[Serializable]
public class Trigger
{
    public string Name;

    public string Text;
}

[Serializable]
public class Dialog
{
    public List<Trigger> Triggers;
}