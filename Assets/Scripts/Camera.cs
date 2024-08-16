using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Camera : MonoBehaviour
{

    public PolygonCollider2D areaCamera;
    public float ativarCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        ativarCamera = Input.GetAxis("Fire2");
        if (ativarCamera != 0 && collision.gameObject.CompareTag("Alucinacao"))
        {
            Destroy(collision.gameObject);
        }
    }
}
