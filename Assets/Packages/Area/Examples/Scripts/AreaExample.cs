using UnityEngine;

namespace Areas.Example
{
    public class AreaExample : MonoBehaviour
    {
        [SerializeField] private AreaManager _areaManager;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _areaManager.EntityEnteredToArea += MessageDebug;
        }

        private void MessageDebug(GameObject entity, Area area)
        {
            if (area.AreaTag == "winArea")
            {
                Debug.Log(entity.name + " entered to " + area.AreaTag + "!");
            }
        }
    }
}