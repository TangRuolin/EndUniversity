using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerCtr : MonoBehaviour
    {
        private void OnEnable()
        {
            EasyJoystick.On_JoystickMove += JoystickMove;
            EasyJoystick.On_JoystickMoveEnd += JoystickMoveEnd;
        }
        /// <summary>
        /// 虚拟摇杆移动时
        /// </summary>
        /// <param name="move"></param>
        private void JoystickMove(MovingJoystick move)
        {
            if(move.joystickName == "MoveJoystick")
            {
                float joyPosX = move.joystickAxis.x;
                float joyPosY = move.joystickAxis.y;

                if(joyPosX != 0 || joyPosY != 0)
                {
                    transform.LookAt(new Vector3(transform.position.x + joyPosX,transform.position.y,transform.position.z + joyPosY));
                    transform.Translate(Vector3.forward * Time.deltaTime * Player.Instance.moveSpe);
                    Player.Instance.Move();
                }
            }
        }
        /// <summary>
        /// 虚拟摇杆结束时
        /// </summary>
        /// <param name="move"></param>
        private void JoystickMoveEnd(MovingJoystick move)
        {
            if(move.joystickName == "MoveJoystick")
            {
                Player.Instance.Idel();
            }
        }
    }
}

