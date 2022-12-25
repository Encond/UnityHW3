using TMPro;
using Map.Scripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _scoreText;

        [SerializeField] private float _health = 100f;
        private float _score = 0f;

        private void Start()
        {
            UpdateHealthText();
            UpdateScoreText();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Coin coin))
                ItemTrigger(coin);
            else if (other.TryGetComponent(out Bomb bomb))
                ItemTrigger(bomb);
        }

        private void ItemTrigger(object item)
        {
            switch (item)
            {
                case Coin coin:
                    ItemDestroy(coin.gameObject);
                    IncreaseScore(coin.Value);
                    UpdateScoreText();
                    break;
                case Bomb bomb:
                    ItemDestroy(bomb.gameObject);
                    DecreaseHealth(bomb.Damage);
                    UpdateHealthText();
                    IsAlive();
                    break;
            }
        }

        private static void ItemDestroy(in GameObject item) => Destroy(item);

        private void UpdateHealthText() => _healthText.text = _health.ToSafeString();

        private void UpdateScoreText() => _scoreText.text = _score.ToSafeString();

        private void DecreaseHealth(float newValue) => _health -= newValue;

        private void IncreaseScore(float newValue) => _score += newValue;

        private void IsAlive()
        {
            if (_health <= 0)
                Destroy(gameObject);
        }
    }
}