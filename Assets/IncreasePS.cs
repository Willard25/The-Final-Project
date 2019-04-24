using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePS : MonoBehaviour
{
    public int kevin;

    void Start()
    {
        if (kevin > 1)
        {
            kevin = 15;
        }
        else
        {
            kevin = 1;
        }
    }

    void Update()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startSpeed = kevin;
    }

    public void fastPar()
    {
        kevin = 15;
        Start();
    }
}
