using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instancia;

    [Header("Componentes")]
    public Rigidbody2D corpoPlayer;
    public CapsuleCollider2D colisorPlayer;
    public CircleCollider2D pePlayer;
    public Animator animatorPlayer;
    public List<ItemHistoria> historias;
    public SpriteRenderer spriteRenderer;
    public bool podeMover;

    [Header("Movimentação")]
    public float inputX ;
    public float inputY;
    public float velocidade;
    public float corrida;

    [Header("interações")]
    public float pegarItem;

    [Header("Lanterna")]
    public Transform lanterna;
    public Transform gravador;

    [Header("Animações")]
    private Animator animator;
    private Vector2 lastMoveDirection;

    [Header("Audio")]
    public AudioSource caixaEfeitos;
    public AudioSource caixaMusica;
    public AudioClip passos;
    public AudioClip musica;
    public bool canLoop;
    public Slider sliderMusic;
    public Slider sliderEffects;

    private void Awake()
    {
        instancia = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.value = Menu.instancia.valorSliderMusic;
        sliderEffects.value = Menu.instancia.valorSliderEffects;
        animator = GetComponent<Animator>();
        podeMover = true;
        caixaMusica.clip = musica;
        caixaMusica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(podeMover == true)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
            corrida = Input.GetAxis("Fire3");

            if((inputX == 0 && inputY == 0) && corpoPlayer.velocity.x != 0 || corpoPlayer.velocity.y != 0)
            {
                lastMoveDirection = corpoPlayer.velocity;
            }

        }
        else
        {
            inputX = 0;
            inputY = 0;
            corrida = 0;
        }
        if(corpoPlayer.velocity.x != 0 || corpoPlayer.velocity.y != 0 && !caixaEfeitos.isPlaying)
        {
            LoopSound(passos);
        }
        caixaMusica.volume = sliderMusic.value;
        caixaEfeitos.volume = sliderEffects.value;
    }

    private void FixedUpdate()
    {
        if(corrida == 1)
        {
            velocidade = 2;
        }
        else
        {
            velocidade = 1;
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
            gravador.eulerAngles = new Vector3(0, 0, angle);
        }

        UpdateAnimationState();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pegarItem = Input.GetAxis("Fire1");
        if (pegarItem != 0 && collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
        }
        if (pegarItem != 0 && collision.gameObject.GetComponent<ItemHistoria>())
        {
            collision.gameObject.GetComponent<ItemHistoria>().MostrarCarta();
            podeMover = false;
            Destroy(collision.gameObject);
        }
    }

    void UpdateAnimationState()
    {
        animator.SetFloat("AnimMoveX", inputX);
        animator.SetFloat("AnimMoveY", inputY);
        animator.SetFloat("AnimMoveMagnitude", corpoPlayer.velocity.magnitude);
        animator.SetFloat("AnimLastMoveX", lastMoveDirection.x);
        animator.SetFloat("AnimLastMoveY", lastMoveDirection.y);
    }


    public void LoopSound(AudioClip clip)
    {
        if (canLoop)
        {
            caixaEfeitos.PlayOneShot(clip);
            StartCoroutine("LoopRotine");
            canLoop = false;
        }
    }
    IEnumerator LoopRotine()
    {
        yield return new WaitForSeconds(0.3F);
        canLoop = true;
    }

    public void MudarCamada()
    {
        spriteRenderer.sortingOrder = 8;
    }
    public void VoltarCamada()
    {
        spriteRenderer.sortingOrder = 10;
    }
    public void MudarCamadaEstranha()
    {
        spriteRenderer.sortingOrder = 7;
    }


}
