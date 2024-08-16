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
    public float velocidade;
    public float corrida;

    [Header("interações")]
    public float pegarItem;

    [Header("Lanterna")]
    public Transform lanterna;
    public int vel;


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


    }

    private void FixedUpdate()
    {
        if(corrida == 1)
        {
            velocidade = 4;
        }
        else
        {
            velocidade = 2;
        }

        corpoPlayer.velocity = new Vector2(inputX * velocidade, inputY * velocidade);
        Vector2 movement = new Vector2(inputY, inputX*-1);

        // Make the movement more fluid by using SmoothDamp
        movement = Vector2.SmoothDamp(movement, movement, ref movement, 0.1f);

        // Calculate the direction the player is moving
        Vector2 direction = movement.normalized;

        // Rotate the weapon to face the direction
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            lanterna.eulerAngles = new Vector3(0, 0, angle);
        }

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
