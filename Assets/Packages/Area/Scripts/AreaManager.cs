using System;
using UnityEngine;

namespace Areas
{
    public class AreaManager : MonoBehaviour
    {
        public Action<GameObject, Area> EntityEnteredToArea;

        public void OnEntityEnteredToArea(GameObject entity, Area area)
        {
            EntityEnteredToArea?.Invoke(entity, area);
        }
    }
}