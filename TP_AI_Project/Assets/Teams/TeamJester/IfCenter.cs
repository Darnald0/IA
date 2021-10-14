//using BehaviorDesigner.Runtime.Tasks;
//using System.Collections;
//using System.Collections.Generic;
//using TeamJester;
//using UnityEngine;

//namespace TeamJester
//{
//    [TaskCategory("Jester")]
//    public class IfCenter : Conditional
//    {
//        private Vector2 shipPos;

//        public override TaskStatus OnUpdate()
//        {
//            shipPos = JesterController.instance._spaceShip.Position;
//            if (shipPos.x <= 0.1f && shipPos.x >= -0.1f )
//            {
//                return TaskStatus.Success;
//            }
//            return TaskStatus.Failure;
//        }
//    }

//}
