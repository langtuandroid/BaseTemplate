using System;
using System.Collections;
using System.Collections.Generic;
using _Watchm1.Config;
using UnityEngine;
public enum UITypes
{
    Background,
    Icon
}
public interface IUIBuilder<T> : IBaseBuilder<T> where T : ScriptableObject
{
    public T BuilderConfig { get; set; }
   
}
