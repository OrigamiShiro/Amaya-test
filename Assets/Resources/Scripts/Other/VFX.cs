using UnityEngine;
using DG.Tweening;

namespace Amaya
{
    public class VFX
    {
        public static void Shake(Transform obj)
        {
            obj.DOShakePosition(0.5f);
        }
    }
}