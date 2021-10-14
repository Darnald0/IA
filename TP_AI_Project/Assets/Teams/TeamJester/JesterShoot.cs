using BehaviorDesigner.Runtime.Tasks;

namespace TeamJester
{
    [TaskCategory("Jester")]

    public class JesterShoot : Action
    {
        public JesterController controller;
        public override TaskStatus OnUpdate()
        {
            if(controller._spaceShip.Energy >= controller._spaceShip.ShootEnergyCost)
            {
                controller.nextInputData.shoot = true;
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }

    }

}
