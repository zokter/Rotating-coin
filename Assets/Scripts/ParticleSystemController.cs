using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] ps;

    public void ActivatePS()
    {
        for(int i = 0; i < ps.Length; i++)
        {
            ps[i].Play();
        }
    }

}
