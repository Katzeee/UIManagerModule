using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelBase : MonoBehaviour
{
    /// <summary>
    /// 初始化，注册自己管理的子控件，只注册需要注册的，即以_U结尾的
    /// </summary>
    void Init()
    {
        Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            //Debug.Log(allChildren[i].name);
            if (allChildren[i].name.EndsWith("_U"))//如果不这样会给所有的子物体挂上UIEvent
            {
                allChildren[i].gameObject.AddComponent<UIEvent>();
            }
        }
    }

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// 获取子控件的GameObject
    /// </summary>
    /// <param name="tmpWidgetName"></param>
    /// <returns></returns>
    public GameObject GetWidget(string tmpWidgetName)
    {
        return UIManager.Instance.GetWidget(name, tmpWidgetName);
    }

    /// <summary>
    /// 获取子控件的Event脚本，用于添加监听事件
    /// </summary>
    /// <param name="tmpWidgetName"></param>
    /// <returns></returns>
    public UIEvent GetEvent(string tmpWidgetName)
    {
        GameObject tmpObj = GetWidget(tmpWidgetName);
        if(tmpObj != null)
        {
            return tmpObj.GetComponent<UIEvent>();
        }
        return null;
    }


    /// <summary>
    /// 给按钮控件添加事件监听
    /// </summary>
    /// <param name="tmpWidgetName"></param>
    /// <param name="tmpAction"></param>
    public void AddButtonListener(string tmpWidgetName, UnityAction tmpAction)
    {
        UIEvent tmpEvnet = GetEvent(tmpWidgetName);
        tmpEvnet.AddButtonListener(tmpAction);
    }

    public void AddSliderListener(string tmpWidgetName, UnityAction<float> tmpAction)
    {
        UIEvent tmpEvnet = GetEvent(tmpWidgetName);
        tmpEvnet.AddSliderListener(tmpAction);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
