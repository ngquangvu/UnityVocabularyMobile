using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationBar : MonoBehaviour
{

    public GameObject goNavigationBar;
    public GameObject goBtnHome;
    public GameObject goBtnSkillUp;
    public GameObject goBtnStudy;
    public GameObject goBtnAccount;
    public GameObject goBtnSetting;
    public Image imgIconBtnHome;
    public Image imgIconBtnSkillUp;
    public Image imgIconBtnStudy;
    public Image imgIconBtnAccount;
    public Image imgIconBtnSetting;

    private List<Image> listImageIcon = new List<Image>();
    Vector2 normalSizeIcon = new Vector2(30, 30);
    Vector2 bigSizeIcon = new Vector2(35, 35);


    // Start is called before the first frame update
    void Start()
    {
        ChangeScreen(imgIconBtnHome, Models.SCREEN_MODE_ENUM.HOME, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToHomeScreen()
    {
        ChangeScreen(imgIconBtnHome, Models.SCREEN_MODE_ENUM.HOME);
    }

    public void ChangeToSkillUpScreen()
    {
        ChangeScreen(imgIconBtnSkillUp, Models.SCREEN_MODE_ENUM.SKILL_UP);
    }

    public void ChangeToStudyScreen()
    {
        ChangeScreen(imgIconBtnStudy, Models.SCREEN_MODE_ENUM.STUDY);
    }

    public void ChangeToAccountScreen()
    {
        ChangeScreen(imgIconBtnAccount, Models.SCREEN_MODE_ENUM.ACCOUNT);
    }

    public void ChangeToSettingScreen()
    {
        ChangeScreen(imgIconBtnSetting, Models.SCREEN_MODE_ENUM.SETTING);
    }

    private void ChangeScreen(Image imgIconButton, Models.SCREEN_MODE_ENUM mode, bool isSkipCheckMode = false)
    {
        // If button is actived already -> return
        if (MainController.SCREEN_MODE == mode && isSkipCheckMode == false)
        {
            return;
        }

        // Change buttons state, change screen
        ChangeButtonToUnSelect();
        ChangeColorAndSizeToSelect(imgIconButton);

        MainController.LAST_SCREEN_MODE = MainController.SCREEN_MODE;
        MainController.SCREEN_MODE = mode;

        // Load scene
        LoadModeScene();

        // Unload last scene
        UnloadModeScene();
    }

    private void ChangeButtonToUnSelect()
    {
        switch (MainController.SCREEN_MODE)
        {
            case Models.SCREEN_MODE_ENUM.HOME:
                ChangeColorAndSizeToUnSelect(imgIconBtnHome);
                break;
            case Models.SCREEN_MODE_ENUM.SKILL_UP:
                ChangeColorAndSizeToUnSelect(imgIconBtnSkillUp);
                break;
            case Models.SCREEN_MODE_ENUM.STUDY:
                ChangeColorAndSizeToUnSelect(imgIconBtnStudy);
                break;
            case Models.SCREEN_MODE_ENUM.ACCOUNT:
                ChangeColorAndSizeToUnSelect(imgIconBtnAccount);
                break;
            case Models.SCREEN_MODE_ENUM.SETTING:
                ChangeColorAndSizeToUnSelect(imgIconBtnSetting);
                break;
            default:
                break;
        }
    }

    private void ChangeColorAndSizeToSelect(Image imageIconSelect)
    {
        imageIconSelect.color = ConstantValues.colorIndigo;
        ChangeSizeIconAnimate(imageIconSelect.gameObject, true);
    }

    private void ChangeColorAndSizeToUnSelect(Image imageIconUnSelect)
    {
        imageIconUnSelect.color = ConstantValues.colorLightBlack;
        ChangeSizeIconAnimate(imageIconUnSelect.gameObject, false);
    }

    private void ChangeSizeIconAnimate(GameObject goSelect, bool isChangeToBig)
    {
        // Setup animation atts
        AnimationCurve curveX = new AnimationCurve();
        AnimationCurve curveY = new AnimationCurve();
        curveX = AnimationCurve.EaseInOut(0f, isChangeToBig ? normalSizeIcon.x : bigSizeIcon.x,
            0.3f, isChangeToBig ? bigSizeIcon.x : normalSizeIcon.x);
        curveY = AnimationCurve.EaseInOut(0f, isChangeToBig ? normalSizeIcon.y : bigSizeIcon.y,
            0.3f, isChangeToBig ? bigSizeIcon.y : normalSizeIcon.y);

        // Init AnimationClip
        AnimationClip clip = new AnimationClip();
        clip.legacy = true;
        clip.SetCurve("", typeof(RectTransform), "m_SizeDelta.x", curveX);
        clip.SetCurve("", typeof(RectTransform), "m_SizeDelta.y", curveY);

        // Add clip to AnimationClip
        Animation anim = goSelect.GetComponent<Animation>();
        anim.AddClip(clip, "SizeChangeAnimation");

        // Play animation
        anim.Play("SizeChangeAnimation");

        // Delete clip
        Destroy(clip);
    }

    private void LoadModeScene()
    {
        switch (MainController.SCREEN_MODE)
        {
            case Models.SCREEN_MODE_ENUM.HOME:
                SceneManager.LoadSceneAsync(ConstantScene.HomeScene, LoadSceneMode.Additive);
                break;
            case Models.SCREEN_MODE_ENUM.SKILL_UP:
                SceneManager.LoadSceneAsync(ConstantScene.SkillupScene, LoadSceneMode.Additive);
                break;
            case Models.SCREEN_MODE_ENUM.STUDY:
                SceneManager.LoadSceneAsync(ConstantScene.StudyScene, LoadSceneMode.Additive);
                break;
            case Models.SCREEN_MODE_ENUM.ACCOUNT:
                SceneManager.LoadSceneAsync(ConstantScene.AccountScene, LoadSceneMode.Additive);
                break;
            case Models.SCREEN_MODE_ENUM.SETTING:
                SceneManager.LoadSceneAsync(ConstantScene.SettingScene, LoadSceneMode.Additive);
                break;
            default:
                break;
        }
    }

    private void UnloadModeScene()
    {
        switch (MainController.LAST_SCREEN_MODE)
        {
            case Models.SCREEN_MODE_ENUM.HOME:
                SceneManager.UnloadSceneAsync(ConstantScene.HomeScene, UnloadSceneOptions.None);
                break;
            case Models.SCREEN_MODE_ENUM.SKILL_UP:
                SceneManager.UnloadSceneAsync(ConstantScene.SkillupScene, UnloadSceneOptions.None);
                break;
            case Models.SCREEN_MODE_ENUM.STUDY:
                SceneManager.UnloadSceneAsync(ConstantScene.StudyScene, UnloadSceneOptions.None);
                break;
            case Models.SCREEN_MODE_ENUM.ACCOUNT:
                SceneManager.UnloadSceneAsync(ConstantScene.AccountScene, UnloadSceneOptions.None);
                break;
            case Models.SCREEN_MODE_ENUM.SETTING:
                SceneManager.UnloadSceneAsync(ConstantScene.SettingScene, UnloadSceneOptions.None);
                break;
            default:
                break;
        }
    }
}
