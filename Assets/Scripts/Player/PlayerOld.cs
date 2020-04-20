using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOld : MonoBehaviour {

    private Rigidbody2D m_playerRb;

    //variáveis de movimentação do personagem
    [Header("Movement Player")]
    public  int         m_velocityMove;
    public  bool        m_rightVision       = true;
    public  int         m_forceJump;
    private bool        m_JumpButton        = false;
    private bool        m_isGrounded        = false;
    [SerializeField]    Transform           m_raycastGround  = null;
    private float       m_groundDistance    = 0f;
    private bool        m_wallCheck         = false;
    private bool        m_walk;
    private Animator    m_animPlayer;
    public  float       m_horizontal;
    public  int         m_itens;
    private bool        m_itensAct;
    private bool        m_fimAct;

    [Header("Itens")]
    public  bool        m_martelo, m_cabra, m_cartao;
    public  GameObject  m_marteloObj, m_cabraObj, m_cartaoObj;

    // Use this for initialization
    void Start () {
        m_playerRb = GetComponent<Rigidbody2D>();
        m_animPlayer = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        m_horizontal = Input.GetAxis("Horizontal");
        m_JumpButton = Input.GetButtonDown("Jump");
        m_animPlayer.SetBool("walk", m_walk);
	}

    private void FixedUpdate()
    {
        //raycast utilizado para verificar se o player está em contato com o chão para pular
        m_isGrounded = Physics2D.Raycast(m_raycastGround.position, -m_raycastGround.up, m_groundDistance);
        Debug.DrawRay(m_raycastGround.position, -m_raycastGround.up, Color.yellow);

        if (m_JumpButton && m_isGrounded)
        {
            Jump();
        }

        if (m_wallCheck == false && m_isGrounded == true)
        {
            Movement();
        }

        if(Input.GetKeyDown(KeyCode.E) && m_itensAct)
        {
            m_itens += 1;
            if (m_cabra)
            {
                Destroy(this.m_cabraObj);
            }

            if (m_cartao)
            {
                Destroy(this.m_cartaoObj);
            }

            if (m_martelo)
            {
                Destroy(this.m_marteloObj);
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && m_fimAct)
        {
            SceneManager.LoadScene("FinalScene");
        }
    }

    //função de movimento do personagem
    public void Movement()
    {
        m_playerRb.velocity = new Vector2(m_horizontal * m_velocityMove, m_playerRb.velocity.y);

        if(m_horizontal != 0)
        {
            m_walk = true;
        }
        else
        {
            m_walk = false;
        }

        if (m_horizontal < 0 && m_rightVision == true)
        {
            Turn();
        }
        else if (m_horizontal > 0 && m_rightVision == false)
        {
            Turn();
        }  
    }

    //função de pulo
    private void Jump()
    {
        Vector2 m_velocity = m_playerRb.velocity;
        m_velocity.y = 0;
        m_playerRb.velocity = m_velocity;

        m_playerRb.AddForce(new Vector2(0, 1f * m_forceJump));
    }

    //função para virar o personagem
    public void Turn()
    {
        m_rightVision = !m_rightVision;

        Vector3 m_theScale = transform.localScale;

        m_theScale.x *= -1;

        transform.localScale = m_theScale;
    }

    //função de detecção de colisão com triggers
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case "Enemy":
                SceneManager.LoadScene("GameOver");
            break;
            case "Cabra":
                m_itensAct = true;
                m_cabra = true;
            break;
            case "Martelo":
                m_itensAct = true;
                m_martelo = true;
            break;
            case "Cartao":
                m_itensAct = true;
                m_cartao = true;
            break;
            case "Fim":
                m_fimAct = true;
            break;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        switch(col.gameObject.tag){ 
            case "Cabra":
                m_itensAct = false;
                m_cabra = false;
            break;
            case "Martelo":
                m_itensAct = false;
                m_martelo = false;
            break;
            case "Cartao":
                m_itensAct = false;
                m_cartao = false;
            break;
            case "Fim":
                m_fimAct = false;
            break;
        }
    }
}
