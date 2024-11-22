using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tripe : MonoBehaviour
{

    public GameObject gravador;
    public Rigidbody2D corpoTripe;
    public BoxCollider2D colisorTripe;
    public CircleCollider2D acionadorTripe;
    public bool cameraColocada = false;
    public GameObject luz;
    public GameObject cameraTripe;
    public int rotacao = 0;
    public SpriteRenderer sprites;
    public List<Sprite> sprite;



    // Start is called before the first frame update
    void Start()
    {
        gravador.SetActive(false);
        luz.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarCamera()
    {
        gravador.SetActive(true);
        luz.SetActive(true);
        cameraColocada = true;
    }
    public void EsconderCamera()
    {
        gravador.SetActive(false);
        luz.SetActive(false);
        cameraColocada = false;
    }
    public void UpdatePosition()
    {
        rotacao++;
        if (rotacao <= 7)
        {
            sprites.sprite = sprite[rotacao];
        }
        else
        {
            rotacao = 0;
            sprites.sprite = sprite[rotacao];
        }
    }

}
