using UnityEngine;

namespace CodeBase.Services.Input
{
    public class MobileInputServie : InputService
    {
        public override Vector2 Axis => 
            GetSimpleInputAxis();
    }

}