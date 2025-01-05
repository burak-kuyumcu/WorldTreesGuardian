using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem instance;
    public List<string> dialogueLines = new List<string>();

    public GameObject dialoguePanel;

    Text dialogueText, nameText;
    public string npcName;

    int dialougeIndex;
    private void Awake()
    {
        dialogueText = dialoguePanel.transform.Find("DialougeText").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("NPCNamePanel").GetChild(0).GetComponent<Text>();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewDialouge(string[] lines, string npcName)
    {
        dialougeIndex = 0;
        dialogueLines = new List<string>();

        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        this.npcName = npcName;
        CreateDialouge();
    }

    public void CreateDialouge()
    {
        dialogueText.text = dialogueLines[dialougeIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void NextLine()
    {
        if(dialougeIndex < dialogueLines.Count - 1)
        {
            dialougeIndex++;
            dialogueText.text = dialogueLines[dialougeIndex];
        }

        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
