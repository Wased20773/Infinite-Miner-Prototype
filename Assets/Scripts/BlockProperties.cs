using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    // Block Type (weakest → strongest → unbreakable)
    // Dirt(1)/Gravel(1) → Stone(2) → Dense Stone(3) → Granite(4) → Magma Rock(5) → Obsidian(6) → Bedrock(unbreakable)
    public string blockType;

    // Ore Type (Cheapest → More expensive)
    // Stone → Coal → Copper → Iron → Silver → Gold → Sapphire → Ruby → Emerald → Platinum → Diamond → More valuable ores with NewGame+?
    public string oreType;

    // Visibility (True or False)
    public bool isVisible;

    // For Rendering
    public SpriteRenderer visibilitySprite;
    public SpriteRenderer oreSprite;
    public SpriteRenderer blockSprite;
    public Sprite spriteHidden;

    void Awake()
    {

    }

    // Initialization List (Generates block with ore)
    public void InitilizeBlock(int row, Sprite ore, Sprite block)
    {
        // Check visibility
        InitializeVisibility(row);

        // Generate Ore
        InitializeOre(row, ore);

        // Generate Block Type
        InitializeBlock(row, block);
        
    }

    private void InitializeVisibility(int row)
    {
        if (row == 0) { // if it's the first row...
            RevealBlock();
        }
        else {
            HideBlock();
        }
        oreType = spriteHidden.name;
    }

    private void InitializeOre(int row, Sprite ore)
    {
        if (ore != null && row != 0) {
            oreSprite.sprite = ore;
            oreSprite.color = Color.red;
        }
        
    }

    private void InitializeBlock(int row, Sprite block)
    {
        blockSprite.sprite = spriteHidden;
        if (row == 0) {
            blockSprite.color = Color.green;
        }
        else {
            blockSprite.color = Color.yellow;
        }

    }

    public void RevealBlock()
    {
        isVisible = true;
        visibilitySprite.sprite = null;
    }
    
    public void HideBlock()
    {
        isVisible = false;
        visibilitySprite.sprite = spriteHidden;
        visibilitySprite.color = Color.grey;
    }

    public bool getVisibility()
    {
        return isVisible;
    }
}
