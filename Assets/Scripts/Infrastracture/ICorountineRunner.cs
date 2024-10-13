using System.Collections;
using UnityEngine;

namespace CodeBase.Infastructure
{
    public interface ICorountineRunner
    {
        public Coroutine StartCoroutine(IEnumerator corountine);
    }
}