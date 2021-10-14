//using BehaviorDesigner.Runtime.Tasks;

//namespace TeamJester
//{
//    [TaskCategory("Jester")]
//    public class JesterBomb : Action
//    {

//        public override TaskStatus OnUpdate()
//        {
//            if (JesterController.instance._spaceShip.Energy >= JesterController.instance._spaceShip.MineEnergyCost)
//            {
//                JesterController.instance.nextInputData.dropMine = true;
//                return TaskStatus.Success;
//            }
//            return TaskStatus.Running;
//        }

//    }

//}
