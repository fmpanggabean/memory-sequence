using System;
using System.Collections.Generic;
using UnityEngine;

namespace MemorySequence.Gameplay {
    public class Challenge {
        public event Action onAnswerWrong;
        public event Action onChallengeIsDone;

        public List<int> sequencChallengee;
        public List<SequenceButton> sequenceButtonList;

        private int challengeIndex;
        private int difficulty;

        public Challenge() {
            sequencChallengee = new List<int>();
            sequenceButtonList = new List<SequenceButton>();

            challengeIndex = 0;
            difficulty = 1;
        }

        internal void AddChallengeIndex(int v) {
            sequencChallengee.Add(v);
        }

        internal void Reset() {
            sequencChallengee.Clear();
            challengeIndex = 0;
        }

        internal void CompareInputToChallenge(SequenceButton sequenceObject) {
            //jawaban benar
            if (GetCurrentChallengeSequence() == sequenceObject) {
                challengeIndex++;
                if (IsChallengeDone()) {
                    difficulty++;
                    onChallengeIsDone?.Invoke();
                }
            } 
            //jawaban salah
            else {
                Debug.Log("jawaban salah!");
                challengeIndex = 0;
                onAnswerWrong?.Invoke();
            }
        }

        private bool IsChallengeDone() {
            return challengeIndex >= GetSequenceChallengeCount();
        }

        private SequenceButton GetCurrentChallengeSequence() {
            return sequenceButtonList[sequencChallengee[challengeIndex]];
        }


        public void GenerateSequenceChallenge() {
            Reset();

            for (int i = 0; i < GetSequenceChallengeCount(); i++) {
                AddChallengeIndex(GetRandomSequenceIndex());
            }
        }

        internal int GetDifficulty() {
            return difficulty;
        }

        private int GetRandomSequenceIndex() {
            return UnityEngine.Random.Range(0, sequenceButtonList.Count);
        }

        public int GetSequenceChallengeCount() {
            return 3 + (difficulty / 3);
        }
    }
}