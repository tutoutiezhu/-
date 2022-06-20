using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TOnextscene : MonoBehaviour
{
    public Key ky;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ky.haveKey == true)//拿到了钥匙
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ky.haveKey = false;//一关一个钥匙
        
        }    
    }
}
