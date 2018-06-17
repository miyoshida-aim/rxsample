using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CharacterViewController : MonoBehaviour {


    [SerializeField] CharacterDetailPresenter characterDetail = null;

    [SerializeField] Button changeButton = null;
    [SerializeField] Character[] sampledata = null;

    // Use this for initialization
    void Start () {

        var characterModel = new CharacterModel(sampledata[0]);
        characterDetail?.Init(characterModel);

        var size = sampledata.Length;
        int index = 0;
        changeButton.BindToOnClick(_ =>
        {
            index++;
            index = index % size;
            characterModel.SetData(sampledata[index]);
            return Observable.ReturnUnit();
        }).AddTo(this);
    }

}
