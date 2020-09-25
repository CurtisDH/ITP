﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static Dictionary<string, dynamic> _eventDictionary = new Dictionary<string, dynamic>();

    #region Listen
    public static void Listen(string eventName, Action method)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            var eventToAdd = _eventDictionary[eventName];
            eventToAdd += method;
            _eventDictionary.Add(eventName, eventToAdd);
        }
        else
        {
            _eventDictionary.Add(eventName, method);
        }
    }
    public static void Listen<T>(string eventName, Action<T> method)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            var eventToAdd = _eventDictionary[eventName];
            eventToAdd += method;
            _eventDictionary.Add(eventName, eventToAdd);
        }
        else
        {
            _eventDictionary.Add(eventName, method);
        }
    }
    public static void Listen<T>(string eventName, Action<T, T> method)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            var eventToAdd = _eventDictionary[eventName];
            eventToAdd += method;
            _eventDictionary.Add(eventName, eventToAdd);
        }
        else
        {
            _eventDictionary.Add(eventName, method);
        }
    }
    public static void Listen<T>(string eventName, Action<T, T, T> method)
    {
        if (_eventDictionary.ContainsKey(eventName))
        {
            var eventToAdd = _eventDictionary[eventName];
            eventToAdd += method;
            _eventDictionary.Add(eventName, eventToAdd);
        }
        else
        {
            _eventDictionary.Add(eventName, method);
        }
    }
    #endregion
    #region Raising Events

    public static void RaiseEvent(string eventName)
    {
        var EventToRaise = _eventDictionary[eventName] as Action;
        EventToRaise.Invoke();
    }
    public static void RaiseEvent<T>(string eventName, T arg)
    {
        var EventToRaise = _eventDictionary[eventName] as Action<T>;
        EventToRaise.Invoke(arg);
    }
    public static void RaiseEvent<T>(string eventName, T arg, T arg1)
    {
        var EventToRaise = _eventDictionary[eventName] as Action<T, T>;
        EventToRaise.Invoke(arg, arg1);
    }
    public static void RaiseEvent<T>(string eventName, T arg, T arg1, T arg2)
    {
        var EventToRaise = _eventDictionary[eventName] as Action<T, T, T>;
        EventToRaise.Invoke(arg, arg1, arg2);
    }
    #endregion
    #region Unsubscribing methods
    public static void UnsubscribeEvent(string eventName, Action method)
    {
        var eventToUnsubscribe = _eventDictionary[eventName];
        eventToUnsubscribe -= method;
        _eventDictionary[eventName] = eventToUnsubscribe;
    }

    public static void UnsubscribeEvent<T>(string eventName, Action<T> method)
    {
        var eventToUnsubscribe = _eventDictionary[eventName];
        eventToUnsubscribe -= method;
        _eventDictionary[eventName] = eventToUnsubscribe;
    }
    public static void UnsubscribeEvent<T>(string eventName, Action<T, T> method)
    {
        var eventToUnsubscribe = _eventDictionary[eventName];
        eventToUnsubscribe -= method;
        _eventDictionary[eventName] = eventToUnsubscribe;
    }
    public static void UnsubscribeEvent<T>(string eventName, Action<T, T, T> method)
    {
        var eventToUnsubscribe = _eventDictionary[eventName];
        eventToUnsubscribe -= method;
        _eventDictionary[eventName] = eventToUnsubscribe;
    }
    #endregion

}
