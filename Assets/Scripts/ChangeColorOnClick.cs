using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    Camera cam;
    [SerializeField] private LayerMask mask;
    [SerializeField] private SoundManager sm;
    [SerializeField] private ParticleSystemController psc;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit, mask))
            {
                hit.transform.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                sm.PlaySound();
                psc.ActivatePS();
            }
        }
    }
}
