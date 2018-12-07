using UnityEngine;
using LuaInterface;
using System;

public class HelloWorld : MonoBehaviour
{
    void Awake()
    {
        LuaState lua = new LuaState();
        lua.Start();
        string hello =
            @"            
			    --a = 'hello'    
                --print('hello tolua#')
				--print(#a)
				--a = {}
      			--k = 'x'
               -- a[k] = 10
				--a[2] = 20
				--a[k] = a[k]+10
               -- print(a[k])
				--print(a[2])  

				--a = {}
				--a[10] = 10
				--a[11] = 10
--a[21] = 10
				--print(a[10])
				--print(#a)
               for i=1,10,1 do print(i) end
               max = i
				print(max)
                                
            ";
        
        lua.DoString(hello, "HelloWorld.cs");
        lua.CheckTop();
        lua.Dispose();
        lua = null;
    }
}
