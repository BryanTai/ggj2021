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
    public static float current_height = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = SmallScale;
    }

    // Update is called once per frame
    void Update()
    {
        currentItemNum = Inventory.instance.items.Count;

        transform.position = new Vector3(transform.position.x, current_height, transform.position.z);

        if (currentItemNum <= 5)
        {
            transform.localScale = SmallScale;
            current_height = 0.6f;
        }
        else if(currentItemNum > 5  && currentItemNum <= 10)
        {
            transform.localScale = MediumScale;
            current_height = 1.1f;
        }
        else if(currentItemNum > 10)
        {
            transform.localScale = LargeScale;
            current_height = 1.6f;
        }
    }
}
