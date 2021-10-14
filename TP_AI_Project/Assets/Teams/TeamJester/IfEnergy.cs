using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TeamJester
{
    [TaskCategory("Jester")]
    public class IfEnergy : Conditional
    {
        public JesterController controller;
        public float IfRemainingEnergyPercent;
        private float currentEnergyPercent;

        public override void OnStart()
        {
            IfRemainingEnergyPercent = (float)controller.tree.GetVariable("IfRemainingEnergyPercent").GetValue();
            Debug.Log(IfRemainingEnergyPercent);
        }
        public override TaskStatus OnUpdate()
        {
            float v = ConvertEnergy();
            Debug.Log(v);
            Debug.Log(IfRemainingEnergyPercent);

            if (v - 1 >= IfRemainingEnergyPercent && v + 1 <= IfRemainingEnergyPercent)
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }

        public float ConvertEnergy()
        {
            currentEnergyPercent = controller._spaceShip.Energy / 1 * 100;
            return currentEnergyPercent;
        }
    }

}
