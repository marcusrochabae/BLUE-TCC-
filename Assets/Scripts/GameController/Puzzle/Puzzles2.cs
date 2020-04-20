using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzles2 : MonoBehaviour
{
    public string m_ObjPuzzle;
    private string m_Name;
    public int m_NItem;
    private string m_Feedback;
    private bool m_buttonAct = false;
    private _GC m_GCScript;
    private feedbacksPuzzle m_feedbacksPuzzle;
    private TrocarCamera TrocarCamera;
    public int m_PuzzleNecessario;
    private int m_TamanhoLista;
    public GameObject m_ImagemItem;
    public string m_NomeImagem;
    private string m_NomeImagemJson;

    public ObjectSounds m_ObjectSounds = ObjectSounds.none;
    public enum ObjectSounds { none, nickel, lockpick, scissors, carestacker, wardrobe }

    private void Start(){
        m_GCScript = FindObjectOfType(typeof(_GC)) as _GC;
        TrocarCamera = FindObjectOfType(typeof(TrocarCamera)) as TrocarCamera;
        m_feedbacksPuzzle = FindObjectOfType(typeof(feedbacksPuzzle)) as feedbacksPuzzle;
    }

    private void Update(){
        // Busco os resultados do JSON
        var PuzzleJSON = Puzzles.Instance.Search(m_ObjPuzzle);

        // Armazeno em duas variaveis
        m_Name = PuzzleJSON.Name;
        m_NItem = PuzzleJSON.NItem;
        m_Feedback = PuzzleJSON.Feedback;
        m_NomeImagemJson = PuzzleJSON.Imagem;


        //Faço uma condição para verificar se o player está em cima do obj e se ele apertou o btn de interação
        if(Input.GetButtonDown("Interact") && m_buttonAct){
            m_GCScript.m_ItemLista.Add(m_NItem);
            Destroy(this.gameObject);
            m_feedbacksPuzzle.setText(m_Feedback);
            if(m_PuzzleNecessario == 3){
                TrocarCamera.ChangeSprite();
            }
            
            if(m_NomeImagem != ""){
                if(m_NomeImagem == m_NomeImagemJson){
                    switch (m_ObjectSounds)
                    {
                        case ObjectSounds.nickel:
                            soundFX.playSound(sound.m_nickelSound);
                            break;
                        case ObjectSounds.lockpick:
                            soundFX.playSound(sound.m_lockpickSound);
                            break;
                        case ObjectSounds.scissors:
                            soundFX.playSound(sound.m_scissorsSound);
                            break;
                        case ObjectSounds.carestacker:
                            soundFX.playSound(sound.m_carestackerSound);
                            break;
                        case ObjectSounds.wardrobe:
                            soundFX.playSound(sound.m_wardrobeSound);
                            break;
                    }

                    m_ImagemItem.SetActive(true);
                }
            }
        }
    }

    // Verifico se o player está em cima deste obj
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            // Verifico se o item que ele tem o item necessario para pegar
            m_TamanhoLista = m_GCScript.m_ItemLista.Count;
            if(m_PuzzleNecessario != -1){
                for(var i = 0; i < m_TamanhoLista; i++){
                    if(m_GCScript.m_ItemLista[i] == m_PuzzleNecessario){
                        m_buttonAct = true;
                    }
                }
            }else{
                m_buttonAct = true;
            }
        }
    }

    // Verifico se o player não está em cima deste obj
    void OnTriggerExit2D(Collider2D col){
        m_buttonAct = false;
    }

}
