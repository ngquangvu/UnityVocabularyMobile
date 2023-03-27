using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static Models.SCREEN_MODE_ENUM SCREEN_MODE = Models.SCREEN_MODE_ENUM.HOME;
    public static Models.SCREEN_MODE_ENUM LAST_SCREEN_MODE = Models.SCREEN_MODE_ENUM.HOME;
    public static Models.SELECT_LEVEL SELECTED_LEVEL = Models.SELECT_LEVEL.LEVEL_NaN;

    public static bool IS_SHOWING_NAVBAR = true;

    void Awake()
    {
        SceneManager.LoadScene(ConstantScene.SelectLevelScene, LoadSceneMode.Additive);
    }

    // public void BackScreen()
    // {
    //     if (LAST_SCREEN_MODE == Models.SCREEN_MODE_ENUM.SELECT_LEVEL)
    //     {
    //         SceneManager.LoadScene(ConstantScene.SelectLevelScene, LoadSceneMode.Additive);
    //     }
    //     else
    //     {
    //         SceneManager.LoadScene(Utilities.ScreenEnumToString(LAST_SCREEN_MODE), LoadSceneMode.Additive);
    //     }
    // }
}
