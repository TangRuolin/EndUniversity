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
    }
}

