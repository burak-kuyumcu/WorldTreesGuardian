using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text damageText,strText,agiText,critText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageText.text=PlayerManager.instance.player.GetComponent<PlayerStats>().damage.GetValue().ToString();
        strText.text = PlayerManager.instance.player.GetComponent<PlayerStats>().strength.GetValue().ToString();
        agiText.text = PlayerManager.instance.player.GetComponent<PlayerStats>().agility.GetValue().ToString();
        critText.text ="%"+ PlayerManager.instance.player.GetComponent<PlayerStats>().CalculatedCriticalChance().ToString(); ;
    }
}
