///整个游戏所需要的常量，都存放在这个类里

using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public class Const
    {
        public const float logoBiaoyuTime = 3.5f; // logo标语的显示事件
        public const string LoadBGPath = "Texture/Load/"; //下载图片的路径
        public static System.Random random = new System.Random(); // 适用于大多数情况的随机数random

        public const int playerMoveSpe = 8;//玩家正常的移速
        public const int playerMoveSpeQ = 10;//玩家加快的移速
        public const int playerMoveQTime = 5;//玩家加速后维持的时间
        public const float playerMoveChangeTime = 0.05f; //玩家从静止到移动的协程变化时间

        public const float attackTimeUnit = 1.5f;//玩家攻击的单位时间
        public const float attackTimeUnitQ = 1;//狂暴后玩家攻击的单位时间

        public const float arrowMoveYieldTime =0.4f;//箭矢延迟发射的时间
        public const float arrowMoveDis = 16;//箭矢移动距离
        public const float arrowContinue = 0.3f;//箭矢持续事件
        public const float arrowMoveSpe = 50f;//箭矢移动速度

        public const float aiViewDis = 50;//敌人的视野距离
        public const float aiViewAngle = 90;//敌人的视野角度范围
        public const float aiAttackDis = 2;//敌人的攻击距离
        public const float aiAttackAngle = 160;//敌人的攻击范围

    }
}

