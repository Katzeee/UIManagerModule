# AudioManager

## 介绍

实现对UI控件的统一管理

---

## 结构

- UIManager：总管理器
  - PanelManager：以Panel为单位进行管理
    - UIEvent：Panel下的子控件各自管理

---

## 脚本

- UIEvent：管理控件自身
  - Attributes：
  - Methods：
    - Init：初始化，当初始化时将自己注册到UIManager以实现以中介者模式进行管理
    - AddButtonListener：若为按钮控件，则可以通过此接口添加监听
    - AddSliderListener：若为滑块控件，则可以通过此接口添加监听
    - 针对其他UI模块可以自己编写接口



- PanelBase：实现对Panel的管理，Panel基类，场景中的每一个Panel脚本都继承于此基类
  - Attributes：
  - Methods：
    - Init：初始化，注册自己管理的子控件，只会注册需要注册的，也就是需要进行管理的子控件
    - GetWidget：根据控件名获得子控件
    - GetEvent：根据控件名获得子控件的Event脚本
    - AddButtonListener：Panel自身用于给子按钮控件添加事件监听的方法，是通过调用其子控件上UIEvent的方法实现的
    - AddSliderListener：同上



- UIManager：实现对控件的统一管理，不直接管理Panel
  - Attributes：
    - Instance：采用单例模式进行访问
    - allWigdet：储存所有控件的信息，包括名字和所属Panel
  - Methods：
    - RegistGameObject：提供接口让控件注册到allWigdet
    - GetWidget：返回需要的控件



- LoadingCtrl：一个使用UIManager管理LoadingPanel的例子
