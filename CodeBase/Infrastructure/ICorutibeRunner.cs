using System.Collections;
using GAME_MAIN.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace GAME_MAIN.CodeBase.Infrastructure
{
    public interface ICorutibeRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
