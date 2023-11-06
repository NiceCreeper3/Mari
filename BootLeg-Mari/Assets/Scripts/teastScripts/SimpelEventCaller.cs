using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EventTools", menuName = "EventTools/values less event trigger")]
public class SimpelEventCaller : ScriptableObject
{
    /// (what this is)
    /// this is a basic event trigger script
    /// the reason to use this is to make a broder range four the event
    /// and to make it presist even ind a prefab
    /// and genrelig brake dependensig
    /// 
    /// (the way to use it)
    /// make a scriptebolObject 
    /// then refrens it ind the caller and lisener
    /// make it so the caller uses the callEvent method using the scriptebolObject refrens
    /// and now all scripts that are have a refrens to that scriptebolObject and is subript
    /// will get the call even
    /// 
    /// PLEASE rember to write where the subkriber gets the event from

    // the event to call
    public event Action OnEventCallCaller;

    // is the methode we use to call the event 
    public void callEvent()
    {
        OnEventCallCaller?.Invoke();
    }
}
