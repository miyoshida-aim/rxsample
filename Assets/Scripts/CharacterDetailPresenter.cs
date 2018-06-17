using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailPresenter : MonoBehaviour {

    CharacterModel characterModel;

    [SerializeField] Text nameText = null;
    [SerializeField] Text hpText = null;
    [SerializeField] Text atkText = null;
    [SerializeField] Text defText = null;
    [SerializeField] Text spdText = null;
    [SerializeField] Text rareText = null;

    public void Init(CharacterModel character)
    {
        characterModel = character;
        characterModel.NameRp.SubscribeToText(nameText).AddTo(this);
        characterModel.HpRp.SubscribeToText(hpText).AddTo(this);
        characterModel.AtkRp.SubscribeToText(atkText).AddTo(this);
        characterModel.DefRp.SubscribeToText(defText).AddTo(this);
        characterModel.SpdRp.SubscribeToText(spdText).AddTo(this);
        characterModel.RareRp.SubscribeToText(rareText).AddTo(this);
    }







}
