using UnityEngine;

namespace CodeBase.AI.Components
{
    public class SafetyPlace : MonoBehaviour
    {
        [SerializeField] private int _capacity;
        
        [field: SerializeField] public Transform SafePoint { get; private set; }

        public int FreePlacesAmount => _capacity - _occupiedSeats;

        private int _occupiedSeats;

        public bool HasFreeSpace() =>
            FreePlacesAmount > 0;

        public void TakeSeat() =>
            _occupiedSeats++;

        public void FreeSeat() =>
            _occupiedSeats--;
    }
}