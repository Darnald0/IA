//using BehaviorDesigner.Runtime.Tasks;

//namespace TeamJester
//{
//    [TaskCategory("Jester")]

//    public class JesterShoot : Action
//    {

//        public override TaskStatus OnUpdate()
//        {
//            if(JesterController.instance._spaceShip.Energy >= JesterController.instance._spaceShip.ShootEnergyCost)
//            {
//                JesterController.instance.nextInputData.shoot = true;
//                return TaskStatus.Success;
//            }
//            return TaskStatus.Running;
//        }

//    }

//}
