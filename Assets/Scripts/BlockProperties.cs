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
        InitializeOre(ore);

        // Generate Block Type
        InitializeBlock(block);
        
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

    private void InitializeOre(Sprite ore)
    {
        if (ore != null) {
            oreSprite.sprite = ore;
        }
        
    }

    private void InitializeBlock(Sprite block)
    {
        blockSprite.sprite = block;
    }

    public void RevealBlock()
    {
        isVisible = true;
        visibilitySprite.sprite = spriteHidden;
        visibilitySprite.color = Color.white;

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
