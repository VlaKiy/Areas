using Exceptor.Utilities;
using UnityEngine;

namespace Areas
{
    [RequireComponent(typeof(Rigidbody))]
    public class Area : MonoBehaviour
    {
        private const string AREA_MANAGER_GAMEOBJECT_NAME = "AreaManager";

        [Tooltip("Write tag to check the area for a tag later.")]
        [SerializeField] private string _tag;

        [Tooltip("What objects will trigger the area?")]
        [SerializeField] private GameObject[] _whoCanTriggering;

        public string AreaTag => _tag;

        private Collider _collider;
        private AreaManager _areaManager;

        private void Awake()
        {
            Initialize();
        }

        private void LateUpdate()
        {
            if (!_collider.isTrigger)
            {
                _collider.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            SendEventIfTriggering(other.gameObject);
        }

        #region INIT
        private void Initialize()
        {
            InitializeCollider();
            InitializeAreaManager();
        }

        private void InitializeAreaManager()
        {
            if (GameObject.Find(AREA_MANAGER_GAMEOBJECT_NAME).TryGetComponent(out AreaManager areaManager))
            {
                _areaManager = areaManager;
            }
            else
            {
                _areaManager.ThrowIfNull(nameof(_areaManager), "Area Manager is null. You should add Area Manager to your scene!");
            }
        }

        private void InitializeCollider()
        {
            if (TryGetComponent(out Collider collider))
            {
                _collider = collider;
            }
            else
            {
                _collider.ThrowIfNull(nameof(_collider), "Collider is null. You should add Collider to your area!");
            }

            _collider.isTrigger = true;
        }
        #endregion

        private void SendEventIfTriggering(GameObject entity)
        {
            if (IsCanTriggering(entity))
            {
                _areaManager.OnEntityEnteredToArea(entity, this);
            }
        }

        private bool IsCanTriggering(GameObject triggeredObject)
        {
            // Check if entity can triggering.
            foreach (var entity in _whoCanTriggering)
            {
                if (entity == triggeredObject)
                {
                    return true;
                }
            }

            // if not found triggering object.
            return false;
        }
    }
}