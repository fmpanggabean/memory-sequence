using System;
using UnityEngine;

namespace MemorySequence {
    public class Factory : MonoBehaviour {
        //prefabs
        public FactoryAsset factoryContainer;


        public T CreateGameObject<T>(string objectName, Transform parent) where T : MonoBehaviour{
            return Instantiate(factoryContainer.GetObject(objectName), parent).GetComponent<T>();
        }
    }
}