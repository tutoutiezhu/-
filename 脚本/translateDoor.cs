using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateDoor : MonoBehaviour
{
    //声明去往的坐标
    public Transform goToPos;
    //声明游戏角色的坐标
    private Transform playerPos;
    public bool isButton;

    void Start()
    {
        //获取游戏角色的坐标
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        isButton = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isButton == true) {
            
            playerPos.transform.position = goToPos.transform.position;

        }
    }
    //添加碰撞判断
    private void OnTriggerEnter2D(Collider2D other)
    {
        //发生碰撞后按下键盘的E键
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //将游戏角色的位置修改为去往的位置
        //    playerPos.transform.position = goToPos.transform.position;
        // }
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc != null)
        {
            isButton = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playercontrol pc = other.GetComponent<playercontrol>();
        if (pc!=null) {
            isButton = false;
        }
    }


}
