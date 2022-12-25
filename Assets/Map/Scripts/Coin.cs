using UnityEngine;

namespace Map.Scripts
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _value;
        public float Value => _value;
    }
}
