using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesExtras : MonoBehaviour
{
    public GameObject paredes;
    public PolygonCollider2D colisor;
    SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererExtra;
    public bool necessario;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoverParedes()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.2f);
        if(necessario == true)
        {
            spriteRendererExtra.color = new Color(1, 1, 1, 0.2f);
        }
    }
    public void VoltarParedes()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
        if (necessario == true)
        {
            spriteRendererExtra.color = new Color(1, 1, 1, 1);
        }
    }
}
