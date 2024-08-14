using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Componentes")]
    public Rigidbody2D corpoPlayer;
    public CapsuleCollider2D colisorPlayer;
    public Animator animatorPlayer;
    public GameObject item;

    [Header("Movimentação")]
    public float inputX ;
    public float inputY;
    public float velocidade = 2;
    public float corrida;

    [Header("interações")]
    public float pegarItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        corrida = Input.GetAxis("Fire3");

        if (inputX == 1 && inputY == 1)
        {
            inputX = 1;
            inputY = 0.58f;
        }
        if (inputX == 1 && inputY == -1)
        {
            inputX = 1;
            inputY = -0.58f;
        }
        if (inputX == -1 && inputY == 1)
        {
            inputX = -1;
            inputY = 0.58f;
        }
        if (inputX == -1 && inputY == -1)
        {
            inputX = -1;
            inputY = -0.58f;
        }
    }

    private void FixedUpdate()
    {
        if (corrida == 1)
        {
            velocidade = 4;
        }

        corpoPlayer.velocity = new Vector2(inputX * velocidade, inputY * velocidade);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        pegarItem = Input.GetAxis("Fire1");
        if (pegarItem != 0 && collision.gameObject.CompareTag("Item"))
        {
            Destroy(item);
        }
    }

}
