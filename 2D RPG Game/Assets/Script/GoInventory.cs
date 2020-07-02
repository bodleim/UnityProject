using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInventory : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject hideInvBtn;
    public GameObject hidePauseBtn;

    public void GoInv(){
        hideInvBtn.SetActive(false);
        hidePauseBtn.SetActive(false);
    }
}
