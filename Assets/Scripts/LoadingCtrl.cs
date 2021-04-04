using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCtrl : PanelBase
{
    public void onClick()
    {
        Debug.Log("Start!!");
    }
    // Start is called before the first frame update

    public void onValueChanged(float value)
    {
        Debug.Log(value);
    }

    /// <summary>
    /// 尝试给Panel下的子控件添加事件监听
    /// </summary>
    void Start()
    {
        AddButtonListener("StartButton_U", onClick);
        AddSliderListener("VolumeSlider_U", onValueChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
