using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageManager : MonoBehaviour
{
    public static RageManager instance;

    public Image rageMeter;

    [HideInInspector]
    public float maxRage;
    [HideInInspector]
    public float currentRage;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxRage = 100;
        currentRage =0;
    }

    // Update is called once per frame
    void Update()
    {
        currentRage -= Time.deltaTime / 10;

        if(currentRage<=0)
        {
            currentRage = 0;
        }
        rageMeter.fillAmount = currentRage/maxRage;
    }

    public void GainRage(float rage)
    {
        currentRage += rage;
    }

    public void LoseRage(float rage)
    {
        currentRage -= rage;
    }
}
