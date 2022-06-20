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
        

        //ESC打开(关闭)菜单
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
        SceneManager.LoadScene(1);//开始游戏

    }


    public void Quitgame()
    {
        Application.Quit();//退出游戏
    }

    //打开操作说明选项
    public void enterOptions() {

        options.SetActive(true);
    
    }
    //关闭操作说明选项
    public void quitOptions() {

        options.SetActive(false);
    
    }

    public void UIEnable()
    {

        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);//UI启动

    }

    public void PauseGame()
    {


        pauseMenu.SetActive(true);//打开暂停菜单
        Time.timeScale = 0f;//白金之星

    }

    public void BackToGame()
    {

        pauseMenu.SetActive(false);//关闭暂停菜单
        Time.timeScale = 1f;//时间开始流动

    }

}
