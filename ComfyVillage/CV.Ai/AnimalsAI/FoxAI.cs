using System;
using System.Collections.Generic;
using System.Text;
using CV.Agents;
using CV.Agents.Animals;
using CV.Agents.Intents;
using CV.Ai.Modules;
using CV.Ai.Objectives;
using CV.Map.basicStruct;

namespace CV.Ai.AnimalsAI
{
    public class FoxAI : AIBase<Fox>
    {

        public FoxAI(Fox fox) : base()
        {
            _agent = fox;
        }

        protected override void Act()
        {
            _agent.Intent.MoveIntent = MoveModule.GetSpeedVector(_agent.Location ,CurrentObjective.Location, _agent.MaxVelocity);
        }

        protected override void Decide()
        {

            if (CurrentObjective != null)
            {
                if (_agent.Location.Distance(CurrentObjective.Location) < 5)
                    CurrentObjective = null;
                else
                {
                    return;
                }
            }

            CurrentObjective = new Objective();
            CurrentObjective.Location = DetectionModule.GetRandomLocation(_agent.Location, 30);
            CurrentObjective.Attitude = Atittude.Move;
        }
    }
}
