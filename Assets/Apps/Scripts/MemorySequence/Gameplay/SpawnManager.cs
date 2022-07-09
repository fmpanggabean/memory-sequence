using System.Collections.Generic;
using UnityEngine;

namespace MemorySequence.Gameplay {
    internal class SpawnManager : MonoBehaviour, IManager{
        private Factory factory;

        [SerializeField]
        private Transform[] spawnPoint;

        private void Awake() {
            factory = FindObjectOfType<Factory>();
        }

        internal List<SequenceButton> SpawnButtons(GameManager gameManager) {
            List<SequenceButton> buttons = new List<SequenceButton>();

            foreach(Transform t in spawnPoint) {
                SequenceButton sb = factory.CreateGameObject<SequenceButton>("Sequence Button", transform);

                sb.SetPosition(t.position);

                buttons.Add(sb);
            }

            return buttons;
        }
    }
}