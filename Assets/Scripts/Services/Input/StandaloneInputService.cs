using UnityEngine;

namespace CodeBase.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = GetSimpleInputAxis();

                if (axis == Vector2.zero)
                {
                    return GetStandaloneAxis();
                }
                return axis;
            }
        }
        public Vector2 GetStandaloneAxis() =>
            new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
    }

}