using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoCtr{
    private static LogoCtr _instance;
    private static LogoCtr Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LogoCtr();
            }
            return _instance;
        }
    }
	

}
