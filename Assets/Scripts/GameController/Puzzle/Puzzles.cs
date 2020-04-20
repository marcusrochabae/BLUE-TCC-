using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Puzzles : MonoBehaviour
{
    public static Puzzles Instance { get; private set; }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public Objetos m_Puzzle;
    public void Start()
    {
        TextAsset texto = Resources.Load<TextAsset>("teste");
        m_Puzzle = JsonUtility.FromJson<Objetos>(texto.text);
    }

    public Puzzle Search(string name)
    {
        return m_Puzzle.Puzzles.Find(x => x.Name.Contains(name));
    }

}

[Serializable]
public class Puzzle
{
    // Colocar o nome do obj e o numero da ordem do puzzle no Json
    public string Name;

    public int NItem;
    
    public string Feedback;

    public string Imagem;

}

[Serializable]
public class Objetos
{
    public List<Puzzle> Puzzles;
}