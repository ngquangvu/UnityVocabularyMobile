using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SelectLevelScene : MonoBehaviour
{
    public GameObject goBtnLevel1;
    public GameObject goBtnLevel2;
    public GameObject goBtnLevel3;
    public GameObject goBtnLevel4;
    public Image imgBtnLevel1;
    public Image imgBtnLevel2;
    public Image imgBtnLevel3;
    public Image imgBtnLevel4;
    public TextMeshProUGUI txtBtnLevel1;
    public TextMeshProUGUI txtBtnLevel2;
    public TextMeshProUGUI txtBtnLevel3;
    public TextMeshProUGUI txtBtnLevel4;
    public Button btnContinue;
    private Models.SELECT_LEVEL selectLevel = new Models.SELECT_LEVEL();

    // Start is called before the first frame update
    void Start()
    {
        btnContinue.interactable = false;
        selectLevel = Models.SELECT_LEVEL.LEVEL_NaN;

        SetSelectedLevel();
    }

    public void ChangeButtonLevelColor(GameObject goSelectLevel)
    {
        imgBtnLevel1.color = goSelectLevel == goBtnLevel1 ? ConstantValues.colorPurple : ConstantValues.colorLightGray;
        txtBtnLevel1.color = goSelectLevel == goBtnLevel1 ? ConstantValues.colorWhite : ConstantValues.colorLightBlack;
        imgBtnLevel2.color = goSelectLevel == goBtnLevel2 ? ConstantValues.colorPurple : ConstantValues.colorLightGray;
        txtBtnLevel2.color = goSelectLevel == goBtnLevel2 ? ConstantValues.colorWhite : ConstantValues.colorLightBlack;
        imgBtnLevel3.color = goSelectLevel == goBtnLevel3 ? ConstantValues.colorPurple : ConstantValues.colorLightGray;
        txtBtnLevel3.color = goSelectLevel == goBtnLevel3 ? ConstantValues.colorWhite : ConstantValues.colorLightBlack;
        imgBtnLevel4.color = goSelectLevel == goBtnLevel4 ? ConstantValues.colorPurple : ConstantValues.colorLightGray;
        txtBtnLevel4.color = goSelectLevel == goBtnLevel4 ? ConstantValues.colorWhite : ConstantValues.colorLightBlack;
    }

    public void SelectLevel1()
    {
        selectLevel = Models.SELECT_LEVEL.LEVEL_1;
        btnContinue.interactable = true;
    }

    public void SelectLevel2()
    {
        selectLevel = Models.SELECT_LEVEL.LEVEL_2;
        btnContinue.interactable = true;
    }

    public void SelectLevel3()
    {
        selectLevel = Models.SELECT_LEVEL.LEVEL_3;
        btnContinue.interactable = true;
    }

    public void SelectLevel4()
    {
        selectLevel = Models.SELECT_LEVEL.LEVEL_4;
        btnContinue.interactable = true;
    }

    private void SetSelectedLevel()
    {
        switch (MainController.SELECTED_LEVEL)
        {
            case Models.SELECT_LEVEL.LEVEL_1:
                SelectLevel1();
                ChangeButtonLevelColor(goBtnLevel1);
                break;
            case Models.SELECT_LEVEL.LEVEL_2:
                SelectLevel2();
                ChangeButtonLevelColor(goBtnLevel2);
                break;
            case Models.SELECT_LEVEL.LEVEL_3:
                SelectLevel3();
                ChangeButtonLevelColor(goBtnLevel3);
                break;
            case Models.SELECT_LEVEL.LEVEL_4:
                SelectLevel4();
                ChangeButtonLevelColor(goBtnLevel4);
                break;
            default:
                break;
        }
    }

    public void NextScene()
    {
        MainController.CURRENT_SCREEN = MainController.LAST_SCREEN;
        SceneManager.UnloadSceneAsync(ConstantScene.SelectLevelScene, UnloadSceneOptions.None);
        MainController.SELECTED_LEVEL = selectLevel;
        if (SceneManager.GetSceneByName(ConstantScene.NavigationbarScene).isLoaded == false)
        {
            SceneManager.LoadScene(ConstantScene.NavigationbarScene, LoadSceneMode.Additive);
        }
    }
}
