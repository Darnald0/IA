//using BehaviorDesigner.Runtime.Tasks;

//namespace TeamJester
//{
//    [TaskCategory("Jester")]

//    public class JesterShockWave : Action
//    {

//        public override TaskStatus OnUpdate()
//        {
//            if (JesterController.instance._spaceShip.Energy >= JesterController.instance._spaceShip.ShockwaveEnergyCost)
//            {
//                JesterController.instance.nextInputData.fireShockwave = true;
//                return TaskStatus.Success;
//            }
//            return TaskStatus.Running;
//        }

//    }

//}
