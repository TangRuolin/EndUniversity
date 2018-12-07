using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMgr  {

    private static EventMgr _instance;
    public static EventMgr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new EventMgr();
            }
            return _instance;
        }
    }

    private Dictionary<EventKey, List<System.Action<object[]>>> map = new Dictionary<EventKey, List<System.Action<object[]>>>();
    public void Add(EventKey key, System.Action<object[]> fun)
    {
        if (map.ContainsKey(key))
        {
            map[key].Add(fun);
            return;
        }
        List<System.Action<object[]>> list = new List<System.Action<object[]>>();
        list.Add(fun);
        map.Add(key, list);
    }
    public void Remove(EventKey key, System.Action<object[]> fun)
    {
        if (!map.ContainsKey(key))
        {
            return;
        }
        List<System.Action<object[]>> list = map[key];
        list.Remove(fun);
        if(list.Count == 0)
        {
            map.Remove(key);
        }
    }
    public void Trigger(EventKey key,params object[] objs)
    {
        if (map.ContainsKey(key))
        {
            List<System.Action<object[]>> list = map[key];
            int l = list.Count;
            for(int i = 0; i < l; i++)
            {
                list[i](objs);
            }
        }
    }
}

public enum EventKey
{

}
