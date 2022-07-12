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
        private AudioManager audioManager;
        public Challenge challenge;


        private void Awake() {
            spawnManager = FindObjectOfType<SpawnManager>();
            audioManager = FindObjectOfType<AudioManager>();

            challenge = new Challenge();
        }
        private void Start() {
            Initialize();
            StartChallenge();
        }

        private void OnEnable() {
            onSequenceStartShowing += DisableClick;
            onSequenceEndShowing += EnableClick;

            challenge.onChallengeIsDone += StartChallenge;
        }

        private void OnDisable() {
            onSequenceStartShowing -= DisableClick;
            onSequenceEndShowing -= EnableClick;

            challenge.onChallengeIsDone -= StartChallenge;
        }

        private void Initialize() {
            challenge.sequenceButtonList = spawnManager.SpawnButtons(this);
            challenge.SetAudio(audioManager.audio);

            MappingSequenceEvent();

            onGameInitialize?.Invoke();
        }

        private void MappingSequenceEvent() {
            foreach(SequenceButton sb in challenge.sequenceButtonList) {
                sb.onClick += challenge.CompareInputToChallenge;
            }
        }

        private void StartChallenge() {
            challenge.GenerateSequenceChallenge();
            Debug.LogFormat(
                "\nChallenge started with difficulty of {0}." +
                "\nGenerating {1} sequences"
                , challenge.GetDifficulty(), challenge.GetSequenceChallengeCount());

            ShowSequenceChallenge();
        }

        private void DisableClick() {
            foreach(SequenceButton sb in challenge.sequenceButtonList) {
                sb.DisableClick();
            }
        }

        private void EnableClick() {
            foreach (SequenceButton sb in challenge.sequenceButtonList) {
                sb.EnableClick();
            }
        }

        public void ShowSequenceChallenge() {
            StartCoroutine(SequenceEnumerator());
        }

        public IEnumerator SequenceEnumerator() {
            onSequenceStartShowing?.Invoke();

            foreach(int index in challenge.sequencChallengee) {
                challenge.sequenceButtonList[index].Present();
                yield return new WaitForSeconds(1.4f);
            }

            onSequenceEndShowing?.Invoke();
        }
    }
}
