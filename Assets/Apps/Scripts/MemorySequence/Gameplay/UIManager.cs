using UnityEngine;

namespace MemorySequence.Gameplay.UI {
    internal class UIManager : MonoBehaviour, IManager{
        private GameManager gameManager;

        private void Awake() {
            gameManager = FindObjectOfType<GameManager>();
        }
        private void Start() {
            Debug.Log(gameManager);
        }
    }
}