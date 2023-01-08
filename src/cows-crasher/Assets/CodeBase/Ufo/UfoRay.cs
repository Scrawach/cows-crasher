using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Ufo
{
    public class UfoRay : MonoBehaviour
    {
        [SerializeField] 
        private float _speed = 3;
        
        private PlayerInput _input;
        private List<UfoAttractedObject> _attractedObjects;

        private void Awake()
        {
            _input = new PlayerInput(Camera.main);
            _attractedObjects = new List<UfoAttractedObject>();
        }

        private void Update()
        {
            if (_input.IsInteractButtonPressed())
                ActivateRay();
            else
                DeactivateRay();
        }

        public void Remove(UfoAttractedObject attractedObject) => 
            _attractedObjects.Remove(attractedObject);

        private void ActivateRay()
        {
            foreach (var attracted in _attractedObjects)
            {
                attracted.BeginAttract();
                attracted.PullTo(transform.position, _speed);
            }
        }

        private void DeactivateRay()
        {
            foreach (var attracted in _attractedObjects.Where(a => a.IsAttracting)) 
                attracted.EndAttract();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedObject attracted)) 
                _attractedObjects.Add(attracted);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out UfoAttractedObject attracted)
                && _attractedObjects.Contains(attracted))
            {
                attracted.EndAttract();
                _attractedObjects.Remove(attracted);
            }
        }
    }
}