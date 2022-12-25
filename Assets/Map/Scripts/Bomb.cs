using UnityEngine;

namespace Map.Scripts
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _damage;
        public float Damage => _damage;
    }
}
