using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class TestSceneMain : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;

    readonly ISubject<Unit> request = new Subject<Unit>();

    ReactiveProperty<bool> boolRP = new ReactiveProperty<bool>();

    // Use this for initialization
    void Start()
    {
        boolRP.Value = true;

        button1.OnClickAsObservable()
            .Subscribe(_ =>
            {
                request.OnNext(Unit.Default);
            }).AddTo(this);


        request.Select(_ => CoroutineTaskAsync().TakeUntil(boolRP.Where(b => !b)))
            .Switch()
            .Subscribe()
            .AddTo(this);


        button2.OnClickAsObservable()
            .Subscribe(_ =>
            {
                boolRP.Value = !boolRP.Value;
            }).AddTo(this);
    }


    IObservable<Unit> CoroutineTaskAsync()
    {
        return Observable.FromCoroutine(() => CoroutineTaskCore());
    }


    IEnumerator CoroutineTaskCore()
    {


        while (true)
        {

            yield return new WaitForSeconds(0.2f);
            Debug.Log("aaaa");
        }


    }

}
