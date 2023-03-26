using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SelectLevel : MonoBehaviour
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

    public void NextScene()
    {
        SceneManager.UnloadSceneAsync(ConstantScene.SelectLevelScene, UnloadSceneOptions.None);
        MainController.SELECTED_LEVEL = selectLevel;
        SceneManager.LoadScene(ConstantScene.NavigationbarScene, LoadSceneMode.Additive);
    }

}
