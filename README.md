# xiv-argb-fans
Using arduino to link argb LED device and PC games together
Now developing : synchronization between FFXIV character buff and argb Fans
An usage case: https://www.bilibili.com/video/BV1dT411T7y8

## FF14 角色buff联动风扇颜色
使用例见上文链接

### 游戏状态获取
通过ACT读取战斗日志，用触发器向控制程序发送包含灯光控制指令的http请求

### 控制程序
用中间程序监听指定端口的http请求，接收ACT的指令，处理并通过USB串口发送给arduino开发板

#### C#实现
见hud文件夹

#### python实现
（施工中）

### arduino
见light_control文件夹

### LED风扇
使用5v3pin接口的argb风扇，WS2812B协议
也可以接LED灯条