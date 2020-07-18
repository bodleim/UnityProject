using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseInteractable : Interactable
{
    public int goScene;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void ChangeScene(int scnumber)
    {
        SceneManager.LoadScene(scnumber);
    }

    public override void Interact()
    {
        Debug.Log("Interacted with House");
        ChangeScene(goScene);
        
    }
}
