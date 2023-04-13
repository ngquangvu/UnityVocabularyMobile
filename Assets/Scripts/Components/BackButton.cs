using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public GameObject goButtonBack;

    private void Start()
    {
        goButtonBack.SetActive(MainController.SELECTED_LEVEL != Models.SELECT_LEVEL.LEVEL_NaN);
    }

    public void BackScreen()
    {
        SceneManager.UnloadSceneAsync(Utilities.ScreenEnumToString(MainController.CURRENT_SCREEN), UnloadSceneOptions.None);
        MainController.CURRENT_SCREEN = MainController.LAST_SCREEN;
    }
}
