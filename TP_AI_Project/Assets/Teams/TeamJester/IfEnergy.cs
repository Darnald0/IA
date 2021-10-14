using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TeamJester
{
    [TaskCategory("Jester")]
    public class IfEnergy : Conditional
    {
        public float IfRemainingEnergyPercent;
        private float currentEnergyPercent;

        public override void OnStart()
        {
            IfRemainingEnergyPercent = (float)JesterController.instance.tree.GetVariable("IfRemainingEnergyPercent").GetValue();
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
            currentEnergyPercent = JesterController.instance._spaceShip.Energy / 1 * 100;
            return currentEnergyPercent;
        }
    }

}
