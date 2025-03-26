using UnityEngine;

public class ClickableBlock : MonoBehaviour
{
    public GameObject block;

    // Update is called once per frame
    void Update()
    {
        // Mouse Click
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("Mouse Click 0");
            GameObject result = GetBlockClicked(Input.mousePosition);

            if (result != null) {
                block = result;
            }

        }

        // !!! NOTICE !!!
        // TEST PROPERLY WITH ACTUAL MOBILE DEVICE! IN SIMULATOR MODE, BOTH MOUSE CLICK AND TOUCH ARE REGISTERED
        // Finger Tap 
        else if (Input.touchCount == 1) { // Makes sure that only one finger is touching
            Debug.Log("Finger Tap");

            Touch touch = Input.GetTouch(0); // get the most recent touch

            // check if it was a TAP, not swipe
            if (touch.phase == TouchPhase.Ended) {
                GameObject result = GetBlockClicked(touch.position);
                
                if (result != null) {
                    block = result;
                }
            }
        }

        // Destory the block
        if (block != null) {
            Destroy(block);
        }
    }

    GameObject GetBlockClicked(Vector2 position)
    {
    Vector2 worldPosition = Camera.main.ScreenToWorldPoint(position);
    RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

    if (hit.collider != null && hit.collider.CompareTag("Block")) // Correct property is "collider"
    {
        Debug.Log("Tapped on: " + hit.collider.gameObject.name);
        return hit.collider.gameObject; // Return the detected GameObject
    }

    return null; // Return null if nothing is detected
    }

}
