using UnityEngine;

namespace Assets.Scripts.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void OnNotify();
    }
}
