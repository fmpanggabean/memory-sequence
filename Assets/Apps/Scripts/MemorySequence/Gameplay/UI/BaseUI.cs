using System;
using UnityEngine;

namespace MemorySequence.Gameplay.UI {
    public class BaseUI : MonoBehaviour {
        protected GameManager gameManager;


        protected void Awake() {
            gameManager = FindObjectOfType<GameManager>();
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }
    }
}