using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyScene : MonoBehaviour
{
    public GameObject goScrollViewContent;

    // Start is called before the first frame update
    void Start()
    {
        SetInitScrollView();
    }

    // Set init scroll view position
    private void SetInitScrollView()
    {
        goScrollViewContent.transform.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1);
    }
}
