using System;
using UnityEngine;

namespace CodeBase
{
    public abstract class AgentFollowing : MonoBehaviour
    {
        protected Transform Target;

        public void Construct(Transform target)
        {
            Target = target;
        }
    }
}
