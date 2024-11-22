using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTripe : MonoBehaviour
{

    public PolygonCollider2D colisor;
    public int rotacao = 0;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprite;

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
    public void UpdatePosition()
    {
        rotacao++;
        if (rotacao <= 7)
        {
            spriteRenderer.sprite = sprite[rotacao];
        }
        else
        {
            rotacao = 0;
            spriteRenderer.sprite = sprite[rotacao];
        }
    }
}
