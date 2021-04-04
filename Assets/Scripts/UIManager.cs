using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 第一个string是Panel名，第二个string是子控件名
    /// </summary>
    Dictionary<string, Dictionary<string, GameObject>> allWigdet;
    public static UIManager Instance { get; private set; }

    /// <summary>
    /// 注意要让UIManager最先执行
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        allWigdet = new Dictionary<string, Dictionary<string, GameObject>>();//这里需要在Awake中执行
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// 提供接口让Widget注册
    /// </summary>
    /// <param name="tmpPanelName"></param>
    /// <param name="tmpWidgetName"></param>
    /// <param name="tmpObj">控件的obj</param>
    public void RegistGameObject(string tmpPanelName, string tmpWidgetName, GameObject tmpObj)
    {
        if (!allWigdet.ContainsKey(tmpPanelName))
        {
            allWigdet[tmpPanelName] = new Dictionary<string, GameObject>();//如果panel未注册则先注册panel

        }
        allWigdet[tmpPanelName].Add(tmpWidgetName, tmpObj);//注册子控件
    }

    /// <summary>
    /// 提供接口获得已注册的Widget
    /// </summary>
    /// <param name="tmpPanelName"></param>
    /// <param name="tmpWidgetName"></param>
    /// <returns></returns>
    public GameObject GetWidget(string tmpPanelName, string tmpWidgetName)
    {
        if (allWigdet.ContainsKey(tmpPanelName))
        {
            return allWigdet[tmpPanelName][tmpWidgetName];
        }
        return null;
    }
}
