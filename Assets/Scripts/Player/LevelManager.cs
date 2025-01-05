using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int level=1;

    public float experience;
    public Image experienceBar;
    PlayerStats myStats;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static int ExperienceToNextLevel(int currentLevel)
    {
        if(currentLevel ==0) {
        return 0;}

        return (currentLevel*currentLevel+currentLevel)*5;
    }

    public void SetExperience(float exp)
    {
        experience += exp;
        float expNeeded = ExperienceToNextLevel(level);
        float previousExperience=ExperienceToNextLevel(level-1);

        if(experience>=expNeeded)
        {
            LevelUp();
            expNeeded = ExperienceToNextLevel(level);
            previousExperience = ExperienceToNextLevel(level - 1);
        }

        experienceBar.fillAmount=(experience-previousExperience)/(expNeeded-previousExperience);

        if(experienceBar.fillAmount==1)
        {
            experienceBar.fillAmount = 0;
        }
    }

    public void LevelUp()
    {
        level++;
        levelText.text = level.ToString();
        myStats.strength.AddModifiers(1);
    }









}
