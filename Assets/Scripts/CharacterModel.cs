using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CharacterModel {


    public ReactiveProperty<string> NameRp = new ReactiveProperty<string>();
    public ReactiveProperty<int> HpRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> AtkRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> DefRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> SpdRp = new ReactiveProperty<int>();
    public ReactiveProperty<int> RareRp = new ReactiveProperty<int>();

    Character data;

    public CharacterModel(Character data)
    {
        SetData(data);
    }


    public void SetData(Character data)
    {
        this.data = data;
        NameRp.Value = data.name;
        HpRp.Value = data.hp;
        AtkRp.Value = data.atk;
        DefRp.Value = data.def;
        SpdRp.Value = data.spd;
        RareRp.Value = data.rarity;
    }
}
