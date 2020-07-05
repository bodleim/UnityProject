using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("속도증가포션", 0, "캐릭터의 속도가 1분간 증가하는 신비한 포션", 0, 0, 0, 0, Item.ItemType.Use));
        items.Add(new Item("뼈", 0, "평범한 드랍아이템", 0, 0, 0, 0, Item.ItemType.Drop));
        items.Add(new Item("체력포션", 0, "체력이 올라간다!", 0, 0, 0, 0, Item.ItemType.Use));
        items.Add(new Item("돼지고기", 0, "굉장히 기름진 음식이다.", 0, 0, 0, 0, Item.ItemType.Use));
    }

}
