using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIEvent : MonoBehaviour
{
    /// <summary>
    /// 将自己注册到UIManager
    /// </summary>
    private void Init()
    {
        PanelBase parent = transform.GetComponentInParent<PanelBase>();
        UIManager.Instance.RegistGameObject(parent.name, transform.name, gameObject);

    }

    /// <summary>
    /// 提供接口添加按钮监听事件
    /// </summary>
    /// <param name="tmpAction"></param>
    public void AddButtonListener(UnityAction tmpAction)
    {
        Button tmpButton = transform.GetComponent<Button>();
        if(tmpButton != null)
        {
            tmpButton.onClick.AddListener(tmpAction);
        }
    }

    /// <summary>
    /// 提供接口添加滑块监听事件
    /// </summary>
    /// <param name="tmpAction"></param>
    public void AddSliderListener(UnityAction<float> tmpAction)
    {
        Slider tmpSlider = transform.GetComponent<Slider>();
        if (tmpSlider != null)
        {
            tmpSlider.onValueChanged.AddListener(tmpAction);
        }
    }

    private void Awake()
    {

        Init();
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
