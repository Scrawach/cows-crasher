using System;
using UnityEngine;

namespace CodeBase.LevelManagement
{
    public abstract class Cutscene : MonoBehaviour
    {
        public abstract void Play(Action onEnded = null);
    }
}