using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProps : MonoBehaviour
{

    public Rigidbody2D corpoProp;
    public BoxCollider2D colisorprop;
    public PolygonCollider2D ativarMovimento;
    public Transform caixa;
    public Animator animator;
    public float posX;
    public float posY;
    public float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        ativarMovimento.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bloquear()
    {
        ativarMovimento.enabled = false;
        caixa.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        caixa.transform.position = new Vector3(posX, posY, 0);
        animator.SetInteger("Caindo", 1);
    }
}
