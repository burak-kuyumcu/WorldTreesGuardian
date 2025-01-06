using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour
{
    public static PlayerAbilities Instance;

    [Header("Ability_1")]
    public Image skill1;
    public float cooldown1;
    bool isCooldown_1=false;

    public float skill_1waitingTime;

    PlayerMovement movement;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)&&!isCooldown_1)
        {
            isCooldown_1 = true;
            Ability_1();
        }
        if (isCooldown_1)
        {
            skill1.fillAmount += 1 / cooldown1 * Time.deltaTime;
        }
        if(skill1.fillAmount==1)
        {
            skill1.fillAmount = 0;
            isCooldown_1 = false;
        }
    }

    public void Ability_1()
    {
        movement.agent.speed = 14;
        StartCoroutine(Ability_1_Timer());

    }

    IEnumerator Ability_1_Timer()
    {
        yield return new WaitForSeconds(skill_1waitingTime);
        movement.agent.speed = 6;
    }
}
