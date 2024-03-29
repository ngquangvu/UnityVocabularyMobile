using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public static Models.SCREEN_MODE_ENUM SCREEN_MODE = Models.SCREEN_MODE_ENUM.HOME;
    public static Models.SCREEN_MODE_ENUM LAST_SCREEN_MODE = Models.SCREEN_MODE_ENUM.HOME;

    public static bool IS_SHOWING_NAVBAR = true;

    void Awake()
    {
        SceneManager.LoadScene(ConstantScene.NavigationbarScene, LoadSceneMode.Additive);
    }
}
