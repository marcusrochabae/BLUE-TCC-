using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarCamera : MonoBehaviour
{
    public Sprite m_CameraSemFio;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(){
        spriteRenderer.sprite = m_CameraSemFio;
    }

}
