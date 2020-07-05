using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> inventory = new List<Item>();
    // 인벤토리를 리스트로 만듭니다.
    private itemDatabase db;
    // 아이템 데이터베이스는 db로 축약해서 사용합니다.

    public int slotX, slotY;    // 인벤토리 가로 세로 속성 설정 위한 변수
    public List<Item> slots = new List<Item>(); // 인벤토리 속성 변수



	// Use this for initialization
	void Start () {
        for(int i=0; i<slotX*slotY; i++)
        {
            slots.Add(new Item("", 0, "", 0, 0, 0, 0, Item.ItemType.Default));
            // 아이템 슬롯칸에 빈 오브젝트 추가하기
        }
        db = GameObject.FindGameObjectWithTag("Item Database").GetComponent<itemDatabase>();
      
        inventory.Add(db.items[0]);
      
	}

    void OnGUI()
    {
        
    }
}
