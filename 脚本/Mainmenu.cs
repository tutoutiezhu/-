using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Mainmenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isShow;
    public GameObject options;
   


    
    private void Update()
    {
        

        //ESC��(�ر�)�˵�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isShow = !isShow;
            if (isShow)
            {
                PauseGame();

            }
            else {
                BackToGame();
            }
            //pauseMenu.SetActive(isShow);
          

        }

        
    }  

    private void Start()
    {
        isShow = false ;
        
    }
    public void Playgame()
    {
        SceneManager.LoadScene(1);//��ʼ��Ϸ

    }


    public void Quitgame()
    {
        Application.Quit();//�˳���Ϸ
    }

    //�򿪲���˵��ѡ��
    public void enterOptions() {

        options.SetActive(true);
    
    }
    //�رղ���˵��ѡ��
    public void quitOptions() {

        options.SetActive(false);
    
    }

    public void UIEnable()
    {

        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);//UI����

    }

    public void PauseGame()
    {


        pauseMenu.SetActive(true);//����ͣ�˵�
        Time.timeScale = 0f;//�׽�֮��

    }

    public void BackToGame()
    {

        pauseMenu.SetActive(false);//�ر���ͣ�˵�
        Time.timeScale = 1f;//ʱ�俪ʼ����

    }

}
