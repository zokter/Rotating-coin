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

    private Touch touch;

    void Start()
    {
        cam = Camera.main;
#if UNITY_IOS || UNITY_ANDROID
        Screen.orientation = ScreenOrientation.LandscapeLeft;
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE_WIN
        Vector3 mousePosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(mousePosition);
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                hit.transform.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                sm.PlaySound();
                psc.ActivatePS();
            }
        }
#endif
#if UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            {
                Ray ray = cam.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (touch.phase == TouchPhase.Began)
                {
                    if (Physics.Raycast(ray, out hit, 100.0f, mask))
                    {
                        hit.transform.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                        sm.PlaySound();
                        psc.ActivatePS();
                    }
                }

            }
        }
#endif

    }
}
