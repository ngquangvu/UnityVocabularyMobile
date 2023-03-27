using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static string ScreenEnumToString(Models.SCREEN_MODE_ENUM enumScreenName)
    {
        string strScreenName = "";
        switch (enumScreenName)
        {
            case Models.SCREEN_MODE_ENUM.SELECT_LEVEL:
                strScreenName = ConstantScene.SelectLevelScene;
                break;
            case Models.SCREEN_MODE_ENUM.HOME:
                strScreenName = ConstantScene.HomeScene;
                break;
            case Models.SCREEN_MODE_ENUM.SKILL_UP:
                strScreenName = ConstantScene.SkillupScene;
                break;
            case Models.SCREEN_MODE_ENUM.STUDY:
                strScreenName = ConstantScene.StudyScene;
                break;
            case Models.SCREEN_MODE_ENUM.ACCOUNT:
                strScreenName = ConstantScene.AccountScene;
                break;
            case Models.SCREEN_MODE_ENUM.SETTING:
                strScreenName = ConstantScene.SettingScene;
                break;
            default:
                strScreenName = ConstantScene.HomeScene;
                break;
        }
        return strScreenName;
    }
}
