using UnityEngine;

public class BlockSideProcessor : MonoBehaviour
{
    public float checkDistance = 1.15f;
    public LayerMask blockLayer;


    public void CheckBlockSides(GameObject block)
    {
        // Directions to check (up, down, left, right)
        Vector2[] directions = {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right
        };

        // loop through each direction
        foreach (var direction in directions) {
            // check if any sides are blocks
            Vector2 originPoint = block.transform.position;
            originPoint += direction * checkDistance;
            Debug.Log("originPoint: " + originPoint);
            RaycastHit2D hit = Physics2D.Raycast(originPoint, direction, checkDistance, blockLayer);

            // if there is make them visible
            if (hit.collider != null) { // maybe be more specific, like name of gameobject too
                Debug.Log("Side: " + direction);

                GameObject sideBlock = hit.collider.gameObject;
                BlockProperties blockProperties = sideBlock.GetComponent<BlockProperties>();
                blockProperties.RevealBlock();
            }

        }
    }


}
