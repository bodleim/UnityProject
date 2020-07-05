using UnityEngine;
using System.Collections;


[System.Serializable]


public class Item {
    public string itemName;         // 아이템의 이름
    public int itemID;              // 아이템의 고유번호
    public string itemDes;          // 아이템의 설명
    public Texture2D itemIcon;      // 아이템의 아이콘(2D)
    public int itemPower;           // 아이템의 공격력
    public int itemSpeed;           // 아이템의 속도(공속?)
    public int itemDefense;         // 아이템의 방어력
    public int itemEvasion;         // 아이템의 회피력
    public ItemType itemType;       // 아이템의 속성 설정
    
    public enum ItemType            // 아이템의 속성 설정에 대한 갯수
    {
        Weapon,                     // 무기류 (검, 방패, 창 등 해당)
        Costume,                    // 옷류   (상의, 하의, 모자 등 해당)
        Quest,                  // 퀘스트 아이템류
        Drop,                      //드랍 아이템류
        Default,                   //초기화용
        Use         // 소모품류
        
    }

    public Item(string name, int id, string desc, int power, int speed, int defense, int evasion, ItemType type)
        
    {
        itemName = name;
        
        itemID = id;
        itemDes = desc;
        itemPower = power;
    
        
        itemIcon = Resources.Load<Texture2D>("ItemIcons/" +name);
        

        itemSpeed = speed;
        itemDefense = defense;
        itemEvasion = evasion;
        itemType = type;
        
    }
}
