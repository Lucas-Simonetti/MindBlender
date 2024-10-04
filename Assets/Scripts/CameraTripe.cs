using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTripe : MonoBehaviour
{

    public PolygonCollider2D colisor;

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
        if (collision.gameObject.CompareTag("Alucinacao"))
        {
            collision.gameObject.GetComponent<Alucinacao>().Desativar();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alucinacao"))
        {
            collision.gameObject.GetComponent<Alucinacao>().Ativar();
        }
    }
}
