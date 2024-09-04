using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public static Camera instancia;


    public PolygonCollider2D areaCamera;
    public int bateria;
    public float ativarCamera, desativarCamera;
    public bool cameraAtiva, pressed;
    public GameObject gravando;

    // Start is called before the first frame update
    void Start()
    {
        gravando.SetActive(false);
    }
    private void Update()
    {
        ativarCamera = Input.GetAxisRaw("Fire2");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (ativarCamera != 0 && bateria > 0 && cameraAtiva == false && !pressed)
        {
            cameraAtiva = true;
            gravando.SetActive(true);
            StartCoroutine(gravador());
            StartCoroutine(Pressed());
        }
        if (ativarCamera != 0 && cameraAtiva == true && !pressed)
        {
            cameraAtiva = false;
            gravando.SetActive(false);
            StopAllCoroutines();
            StartCoroutine(Pressed());
        }
        if (cameraAtiva == false)
        {
            gravando.SetActive(false);
        }
    }
    IEnumerator Pressed()
    {
        pressed = true;
        yield return new WaitForSeconds(0.3f);
        pressed = false;
    }
    IEnumerator gravador()
    {
        while (bateria > 0)
        {
            yield return new WaitForSeconds(1);
            bateria--;
        }
        cameraAtiva = false;
        StopCoroutine(gravador());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alucinacao") && cameraAtiva == true)
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
