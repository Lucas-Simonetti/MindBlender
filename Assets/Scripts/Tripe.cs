using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripe : MonoBehaviour
{

    public GameObject gravador;
    public Rigidbody2D corpoTripe;
    public BoxCollider2D colisorTripe;
    public CircleCollider2D acionadorTripe;
    public bool cameraColocada = false;
    public GameObject luz;



    // Start is called before the first frame update
    void Start()
    {
        gravador.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarCamera()
    {
        gravador.SetActive(true);
        cameraColocada = true;
    }
    public void EsconderCamera()
    {
        gravador.SetActive(false);
        cameraColocada = false;
    }

}
