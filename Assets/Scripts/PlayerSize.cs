using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    Inventory inventory;
    int currentItemNum = 0;
    private Vector3 LargeScale = new Vector3(3.0f, 3.0f, 3.0f);
    private Vector3 MediumScale = new Vector3(2.0f, 2.0f, 2.0f);
    private Vector3 SmallScale = new Vector3 (1.0f, 1.0f, 1.0f); 

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = SmallScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentItemNum = Inventory.instance.items.Count;
        print(currentItemNum);

        if(currentItemNum <= 5)
        {
            transform.localScale = SmallScale;
        }
        else if(currentItemNum > 5  && currentItemNum <= 10)
        {
            transform.localScale = MediumScale;
        }
        else if(currentItemNum > 10)
        {
            transform.localScale = LargeScale;
        }
    }
}
