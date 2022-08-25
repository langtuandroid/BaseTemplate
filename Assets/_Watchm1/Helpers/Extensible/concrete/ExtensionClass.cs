using _Watchm1.Helpers.Extensible.@abstract;
using Unity.VisualScripting;
using UnityEngine;

namespace _Watchm1.Helpers.Extensible.concrete
{
    public static class ExtensionClass
    {
        public static void ChangeColor(this IExtensiable extensiable,Color color, GameObject obj)
        {
            var metarial = obj.GetComponent<Renderer>().material;
            var newColor = new Color(r:color.r, g:color.g, b:color.b, a:.24f);
            metarial.color = newColor;
            
        }
    }
}
