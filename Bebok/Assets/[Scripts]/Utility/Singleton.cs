using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance { get; private set; }

    protected virtual void Awake() {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this as T;
    }

    private void OnApplicationQuit() {
        Instance = null;
        Destroy(gameObject);
    }
}


public abstract class SingletonPersistent<T> : Singleton<T> where T : MonoBehaviour {
    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
