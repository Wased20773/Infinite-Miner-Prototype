using UnityEngine;
using System.Collections.Generic;

public class GenerateBlocks : MonoBehaviour
{
    /* ----- For Blocks ----- */
    public GameObject blockPref;
    public float baseWidth = 7f;
    public float baseHeight = 7f;
    public float gap = 0.25f;
    public List<string> oreTypeList = new List<string>(); 
    

    /* ----- For Ores ----- */
    public List<string> orePool = new List<string>(); 
    public int orePoolSize;

    public void GenerateBlocksInRows() {
        // Get the block size
        float blockWidth = blockPref.transform.localScale.x;
        float blockHeight = blockPref.transform.localScale.y;

        // Calculate total width and height of the grid while also including gaps
        float totalWidth = (baseWidth * blockWidth) + (gap * (baseWidth - 1));
        float totalHeight = (baseHeight * blockHeight) + (gap * (baseHeight - 1));

        // Create start position (it will be the top left side of the grid)
        Vector2 startPosition = new Vector2((-totalWidth/2), (totalHeight/2));

        Vector2 blockPosition = startPosition;
        for (int row = 0; row < baseHeight; ++row) { // Check per row
            for (int column = 0; column < baseWidth; ++column) { // Check per column
                // Generate the block
                GameObject currentBlock = Instantiate(blockPref, blockPosition, Quaternion.identity);

                // Initialize Block
                BlockProperties blockProperties = currentBlock.GetComponent<BlockProperties>();
                blockProperties.InitilizeBlock(row, null, null);
                // Check chances with ore pool



                blockPosition.x += blockWidth + gap;
            }
            // transition to next column
            blockPosition.y -= blockHeight + gap;
            blockPosition.x = startPosition.x;
            
        }
    }

}

