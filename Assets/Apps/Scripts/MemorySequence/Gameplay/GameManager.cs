using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MemorySequence.Gameplay {
    public class GameManager : MonoBehaviour, IManager {
        //actions
        public event Action onGameInitialize;
        public event Action onSequenceStartShowing;
        public event Action onSequenceEndShowing;

        private SpawnManager spawnManager;

        [SerializeField] private List<SequenceButton> sequenceButtonList;
        [SerializeField] private List<int> sequenceChallenge;

        private int difficulty;

        private void Awake() {
            spawnManager = FindObjectOfType<SpawnManager>();

            sequenceButtonList = new List<SequenceButton>();
            sequenceChallenge = new List<int>();
        }
        private void Start() {
            Initialize();
            StartGame();
        }

        private void OnEnable() {
            onSequenceStartShowing += DisableClick;
            onSequenceEndShowing += EnableClick;
        }

        private void OnDisable() {
            onSequenceStartShowing -= DisableClick;
            onSequenceEndShowing -= EnableClick;
        }

        private void Initialize() {
            sequenceButtonList = spawnManager.SpawnButtons(this);

            onGameInitialize?.Invoke();
        }

        private void StartGame() {
            difficulty = 1;
            GenerateSequenceChallenge();

            StartCoroutine( ShowSequenceChallenge() );
        }

        private void DisableClick() {
            foreach(SequenceButton sb in sequenceButtonList) {
                sb.DisableClick();
            }
        }

        private void EnableClick() {
            foreach (SequenceButton sb in sequenceButtonList) {
                sb.EnableClick();
            }
        }

        public IEnumerator ShowSequenceChallenge() {
            onSequenceStartShowing?.Invoke();

            foreach(int index in sequenceChallenge) {
                sequenceButtonList[index].Present();
                yield return new WaitForSeconds(1);
            }

            onSequenceEndShowing?.Invoke();
        }

        private void GenerateSequenceChallenge() {
            for (int i=0; i<GetSequenceChallengeCount(); i++) {
                sequenceChallenge.Add(GetRandomSequenceIndex());
            }
        }

        private int GetRandomSequenceIndex() {
            return UnityEngine.Random.Range(0, sequenceButtonList.Count);
        }

        private int GetSequenceChallengeCount() {
            return 3 + (difficulty / 3);
        }
    }
}
