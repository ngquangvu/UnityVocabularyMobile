using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private Color colorSelect = new Color(90f / 255f, 56f / 255f, 178f / 255f, 255f / 255f);
    private Color colorUnSelect = new Color(94f / 255f, 101f / 255f, 122f / 255f, 255f / 255f);

    private List<Image> listImageIcon = new List<Image>();
    Vector2 normalSizeIcon = new Vector2(35, 35);
    Vector2 bigSizeIcon = new Vector2(45, 45);


    // Start is called before the first frame update
    void Start()
    {
        ChangeScreen(imgIconBtnHome, Model.SCREEN_MODE_ENUM.HOME, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToHomeScreen()
    {
        ChangeScreen(imgIconBtnHome, Model.SCREEN_MODE_ENUM.HOME);
    }

    public void ChangeToSkillUpScreen()
    {
        ChangeScreen(imgIconBtnSkillUp, Model.SCREEN_MODE_ENUM.SKILL_UP);
    }

    public void ChangeToStudyScreen()
    {
        ChangeScreen(imgIconBtnStudy, Model.SCREEN_MODE_ENUM.STUDY);
    }

    public void ChangeToAccountScreen()
    {
        ChangeScreen(imgIconBtnAccount, Model.SCREEN_MODE_ENUM.ACCOUNT);

    }

    public void ChangeToSettingScreen()
    {
        ChangeScreen(imgIconBtnSetting, Model.SCREEN_MODE_ENUM.SETTING);

    }

    private void ChangeScreen(Image imgIconButton, Model.SCREEN_MODE_ENUM mode, bool isSkipCheckMode = false)
    {
        // If button is actived already -> return
        if (MainController.SCREEN_MODE == mode && isSkipCheckMode == false)
        {
            return;
        }

        // Change buttons state, change screen
        ChangeButtonToUnSelect();
        ChangeColorAndSizeToSelect(imgIconButton);
        MainController.SCREEN_MODE = mode;
    }

    private void ChangeButtonToUnSelect()
    {
        switch (MainController.SCREEN_MODE)
        {
            case Model.SCREEN_MODE_ENUM.HOME:
                ChangeColorAndSizeToUnSelect(imgIconBtnHome);
                break;
            case Model.SCREEN_MODE_ENUM.SKILL_UP:
                ChangeColorAndSizeToUnSelect(imgIconBtnSkillUp);
                break;
            case Model.SCREEN_MODE_ENUM.STUDY:
                ChangeColorAndSizeToUnSelect(imgIconBtnStudy);
                break;
            case Model.SCREEN_MODE_ENUM.ACCOUNT:
                ChangeColorAndSizeToUnSelect(imgIconBtnAccount);
                break;
            case Model.SCREEN_MODE_ENUM.SETTING:
                ChangeColorAndSizeToUnSelect(imgIconBtnSetting);
                break;
            default:
                break;
        }
    }

    private void ChangeColorAndSizeToSelect(Image imageIconSelect)
    {
        imageIconSelect.color = colorSelect;
        ChangeSizeIconAnimate(imageIconSelect.gameObject, true);
    }

    private void ChangeColorAndSizeToUnSelect(Image imageIconUnSelect)
    {
        imageIconUnSelect.color = colorUnSelect;
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
}
