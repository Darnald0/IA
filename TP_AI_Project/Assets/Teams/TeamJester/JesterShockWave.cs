using BehaviorDesigner.Runtime.Tasks;

namespace TeamJester
{
    [TaskCategory("Jester")]

    public class JesterShockWave : Action
    {
        public JesterController controller;
        public override TaskStatus OnUpdate()
        {
            if (controller._spaceShip.Energy >= controller._spaceShip.ShockwaveEnergyCost)
            {
                controller.nextInputData.fireShockwave = true;
                return TaskStatus.Success;
            }
            return TaskStatus.Running;
        }

    }

}
