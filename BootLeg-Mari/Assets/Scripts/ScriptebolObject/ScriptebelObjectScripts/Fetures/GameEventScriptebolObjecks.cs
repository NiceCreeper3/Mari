using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventTools", menuName = "EventTools/Event")]
public class GameEventScriptebolObjecks : ScriptableObject
{
    private List<EventListener> _listListeners = new List<EventListener>();

    public void Raise(object data)
    {
        Debug.Log("Event has bean raised");

        for (int i = _listListeners.Count - 1; i >= 0; i--)
            _listListeners[i].OnEventRaised(data);
    }

    // "Subskribes" to the given event
    public void RegisterListener(EventListener listener)
    {
        if (!_listListeners.Contains(listener))
            _listListeners.Add(listener);
    }

    public void UnregisterListener(EventListener listener)
    {
        if (_listListeners.Contains(listener))
            _listListeners.Remove(listener);
    }
}
