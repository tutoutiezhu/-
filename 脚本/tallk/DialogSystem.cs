using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header ("UI组件")]
    public Text textLabel;
    public Image faceImage;
    [Header("文本组件")]
    public TextAsset textFile;
    public int index;

    List<string> textList = new List<string>();
    public float textSpeed;
    public bool textFinished;
    public bool cancelTyping;

    [Header ("头像")]
    public Sprite face01, face02;
     void Awake()
    {
        GetFromFile(textFile);
        
    }
     void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&index ==textList .Count ) {
            gameObject.SetActive(false);
            index = 0; 
        }
        /*if (Input.GetKeyDown(KeyCode.E)&&textFinished == true ) {
            //textLabel.text = textList[index];
            // index++;
            StartCoroutine(SetTextUI());
        }*/
        if (Input.GetKeyDown(KeyCode.E)) {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished) {
                cancelTyping = !cancelTyping;
            }
                
        
        
        }

                
    }
    //读取文件
    void GetFromFile(TextAsset file) {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');
        foreach (var line in lineData) {
            textList.Add(line);
        
        }
    }


    IEnumerator SetTextUI() {
        textFinished = false;
        textLabel.text = "";
        switch (textList[index].Trim().ToString()) {

            case "player":
                faceImage.sprite = face01; index++; break;
            case "npc":
                faceImage.sprite = face02; index++; break;

        }
        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1) {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        
        }
        textLabel.text = textList[index];
        cancelTyping = false;
            
        if (textFinished != true) {
            textFinished = true;
            index++;
        }
    
    
    
    }







}
