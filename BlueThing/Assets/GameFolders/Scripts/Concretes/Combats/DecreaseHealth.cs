using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBlueThing.Combats
{
    public class DecreaseHealth : MonoBehaviour
    {
        [SerializeField] int _maxHealth = 3;
        [SerializeField] int _currentHealth;

        public int CurrentHealth => _currentHealth;
        public bool IsDead => _currentHealth < 1;
        public event System.Action<int,int> OnHealthDecrease;
        public event System.Action<int,int> OnHealthIncrease;
        public event System.Action onDead;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        private void Start()
        {
            //PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("activeScene", SceneManager.GetActiveScene().buildIndex-1);

            OnHealthDecrease?.Invoke(_currentHealth,_maxHealth);
            OnHealthIncrease?.Invoke(_currentHealth,_maxHealth);
        }

        public void TakeHit(Damage damage)
        {
            _currentHealth -= damage.HitDamage;
            if (IsDead)
            {
                onDead.Invoke();
            }
            else
            { 
                OnHealthDecrease?.Invoke(_currentHealth,_maxHealth);
            }
        }

        public void TakeHeal(Heal heal)
        {
            _currentHealth = Mathf.Min(_currentHealth += heal.TakedHeal, _maxHealth);
            OnHealthIncrease?.Invoke(_currentHealth,_maxHealth);
        }
    }
}

