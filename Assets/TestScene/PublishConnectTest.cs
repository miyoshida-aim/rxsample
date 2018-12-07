using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UniRx;

public class PublishConnectTest
{

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator Test1()
    {
        var timer = Observable.IntervalFrame(1).Take(10).SelectMany(_ =>
        {
            Debug.Log("selectmany");
            return Observable.ReturnUnit();
        });

        timer.Subscribe(_ => Debug.Log("timer1"));
        timer.Subscribe(_ => Debug.Log("timer2"));

        yield return timer.ToYieldInstruction();

        Debug.Log("test end");
    }

//Test2 (0.138s)
//---
//selectmany
//timer1 v = 0
//timer2 v = 0
//selectmany
//timer1 v = 1
//timer2 v = 1
//selectmany
//timer1 v = 2
//timer2 v = 2
//test end
    [UnityTest]
    public IEnumerator Test2()
    {
        var timer = Observable.IntervalFrame(1).Take(3).SelectMany(l =>
        {
            Debug.Log("selectmany");
            return Observable.Return(l);
        }).Share();

        yield return null;
        yield return null;
        yield return null;

        timer.Subscribe(v => Debug.Log("timer1 v = " + v));
        timer.Subscribe(v => Debug.Log("timer2 v = " + v));

        yield return timer.ToYieldInstruction();

        Debug.Log("test end");
    }


//Test3 (0.136s)
//---
//connect
//selectmany
//timer1 v = 0
//timer2 v = 0
//selectmany
//timer1 v = 1
//timer2 v = 1
//selectmany
//timer1 v = 2
//timer2 v = 2
//test end
    [UnityTest]
    public IEnumerator Test3()
    {
        var timer = Observable.IntervalFrame(1).Take(3).SelectMany(l =>
        {
            Debug.Log("selectmany");
            return Observable.Return(l);
        }).Publish();

        yield return null;
        yield return null;
        yield return null;

        timer.Subscribe(v => Debug.Log("timer1 v = " + v));
        timer.Subscribe(v => Debug.Log("timer2 v = " + v));

        Debug.Log("connect");
        timer.Connect();
        yield return timer.ToYieldInstruction();
        Debug.Log("test end");
        yield break;
    }
}
