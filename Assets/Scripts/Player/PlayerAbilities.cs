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
    public float skill_1waitingTime;

    [Header("Ability_2")]
    public Image skill2;
    public float coolDown2;
    public float skill_2waitingTime;

    bool isCooldown_1 = false;
    bool isCooldown_2 = false;

    //
    public bool canMove;

    bool canAttack2 = true;
    bool canAttack3 = true;

    //
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

        if(Input.GetKey(KeyCode.W) && !isCooldown_2 && canAttack2 && RageManager.instance.currentRage >= 0)
        {
            isCooldown_2 = true;
            Ability_2();
        }
    }

    // ABILITY 1---------
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

    // ABILITY 2--------
    public void Ability_2()
    {
        movement.anim.SetTrigger("SpinAttack");
        canMove = false;
        RageManager.instance.LoseRage(10);

    }
}
