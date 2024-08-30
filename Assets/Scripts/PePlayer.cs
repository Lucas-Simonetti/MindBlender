using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PePlayer : MonoBehaviour
{
    GameObject paredeAtual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Paredes>())
        {
            collision.gameObject.GetComponent<Paredes>().RemoverParedes();
            Player.instancia.MudarCamada();
        }
        if (collision.gameObject.GetComponent<ParedesExtras>())
        {
            collision.gameObject.GetComponent<ParedesExtras>().RemoverParedes();
            Player.instancia.MudarCamadaEstranha();
        }
        if (Player.instancia.pegarItem != 0 && collision.gameObject.CompareTag("Alucinacao"))
        {
            collision.gameObject.GetComponent<Animator>().Rebind();
            collision.gameObject.GetComponent<Animator>().Play("Chave Alucinacao 3");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Paredes>())
        {
            collision.gameObject.GetComponent<Paredes>().VoltarParedes();
            Player.instancia.VoltarCamada();
        }
        if (collision.gameObject.GetComponent<ParedesExtras>())
        {
            collision.gameObject.GetComponent<ParedesExtras>().VoltarParedes();
            Player.instancia.VoltarCamada();
        }


    }

}
