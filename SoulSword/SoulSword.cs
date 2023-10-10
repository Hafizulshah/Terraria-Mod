using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulSword
{
    public class SoulSword : Mod
    {
        private static int killCounter;

        private void OnNPCLoot(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];

            // Check if the NPC was killed by the player
            if (npc.lifeMax > 5 && npc.value > 0f && npc.damage > 0 && !npc.friendly && npc.active &&
                (Main.expertMode || !npc.boss) && player.active && !player.dead && !player.ghost)
            {
                // Increment the kill counter and check if it's a multiple of 2
                killCounter++;
                if (killCounter % 2 == 0)
                {
                    // Trigger your event here
                    // Example: Main.NewText("Every 2 kills!");
                }
            }
        }
    }
}
