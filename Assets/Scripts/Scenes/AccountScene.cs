using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccountScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SelectLevel()
    {
        MainController.CURRENT_SCREEN = Models.SCREEN_MODE_ENUM.SELECT_LEVEL;
        MainController.LAST_SCREEN = Models.SCREEN_MODE_ENUM.ACCOUNT;
        SceneManager.LoadScene(ConstantScene.SelectLevelScene, LoadSceneMode.Additive);
    }
}
