using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monstro : MonoBehaviour
{
    [SerializeField] private string Menu;
    public float moveSpeed = 1f;
    public float pursuitRadius = 10f;
    private Transform player;
    private Rigidbody2D enemyBody;
    public CapsuleCollider2D colisorMonstro;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= pursuitRadius)
        {
            MoveTowardsPlayer();
            Player.instancia.MudarMusica(Player.instancia.musicaPerseguicao);
        }
        else
        {
            enemyBody.velocity = Vector3.zero;
            animator.SetInteger("Monstro", 0);
            Player.instancia.MudarMusica(Player.instancia.musica);
        }
    }
    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        enemyBody.velocity = direction * moveSpeed;
        if(direction != Vector3.zero)
        {
            if(direction.x < 0)
            {
                animator.SetInteger("Monstro", 1);
            }
            else
            {
                animator.SetInteger("Monstro", 2);
            }
        }
        else
        {
            animator.SetInteger("Monstro", 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        SceneManager.LoadScene(Menu);
    }
}
