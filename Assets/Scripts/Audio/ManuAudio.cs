using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManuAudio : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public AudioSource fx;
    public void OnPointerEnter(PointerEventData eventData)
    {
        fx.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        fx.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
