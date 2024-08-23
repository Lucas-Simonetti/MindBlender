using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Camera : MonoBehaviour
{

    public PolygonCollider2D areaCamera;
    public int bateria;
    public float ativarCamera, desativarCamera;
    public bool cameraAtiva, pressed;

    // Start is called before the first frame update
    void Start()
    {

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
            StartCoroutine(gravador());
            StartCoroutine(Pressed());
        }
        if (ativarCamera != 0 && cameraAtiva == true && !pressed)
        {
            cameraAtiva = false;
            StopAllCoroutines();
            StartCoroutine(Pressed());
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
