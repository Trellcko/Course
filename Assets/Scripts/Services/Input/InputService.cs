using UnityEngine;

namespace CodeBase.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Fire = "Fire";

        public abstract Vector2 Axis { get; }

        protected Vector2 GetSimpleInputAxis()
        {
            return new(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }

        public bool IsAttackButtonUp =>
            SimpleInput.GetButtonUp(Fire);
    }

}