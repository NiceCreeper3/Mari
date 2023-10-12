using UnityEngine.Events;
using UnityEngine;

[System.Serializable]  public class CustomGameEvent : UnityEvent< object> {}

public class EventListener : MonoBehaviour
{
    [SerializeField] public GameEventScriptebolObjecks _gameEvent;
    public CustomGameEvent reponse;

    // starts the gameObject linked with the event
    private void Start()
    {
        if (_gameEvent != null)
            _gameEvent.RegisterListener(this);
    }

    public void OnDisable()
    {
        if (_gameEvent != null)
            _gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(object data)
    {
        reponse?.Invoke(data);
    }
}
