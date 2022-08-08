using UnityEngine;

namespace _Watchm1.Config
{
    public abstract class BaseSettings<T> : ScriptableObject where T : ScriptableObject
    {
        public static T Current => Resources.Load<T>(typeof(T).Name);
    }
}
