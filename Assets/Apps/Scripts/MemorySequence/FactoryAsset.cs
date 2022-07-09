using UnityEngine;
using System.Collections.Generic;
using System;

namespace MemorySequence {
    [System.Serializable]
    public class FactoryLabel {
        public string label;
        public GameObject prefab;
    }
    [CreateAssetMenu(fileName = "Factory Asset", menuName = "Scriptable Objects/Factory Asset")]
    public class FactoryAsset : ScriptableObject {
        public List<FactoryLabel> objects;

        internal GameObject GetObject(string objectName) {
            foreach(FactoryLabel fl in objects) {
                if (fl.label == objectName) {
                    return fl.prefab;
                }
            }
            return null;
        }
    }
}