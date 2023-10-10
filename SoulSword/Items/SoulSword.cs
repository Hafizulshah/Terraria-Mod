using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SoulSword.Items
{
    public class SoulSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Sword");
            Tooltip.SetDefault("A sword that grows stronger with every kill\nIncrease 1 damage every 5 kills\nIncrease 50 damage every boss killed\nIncrease stats slightly every 50 kills");
        }

        public override void SetDefaults()
        {
            // Hitbox
            Item.width = 32;
            Item.height = 32;

            // Use and Animation Style
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 25;
            Item.autoReuse = true;

            // Damage Values
            Item.DamageType = DamageClass.Melee;
            Item.damage = 5;
            Item.knockBack = 5;
            Item.crit = 5;

            // Misc
            Item.value = Item.buyPrice(copper: 30);
            Item.rare = ItemRarityID.Purple;

            // Sound
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .AddIngredient(ItemID.IronBar, 20)
                .Register();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (target.life <= 0 && !target.dontCountMe)
            {
                player.GetModPlayer<SoulSwordPlayer>().killCount++;

                if (player.GetModPlayer<SoulSwordPlayer>().killCount % 5 == 0)
                {
                    Item.damage++;
                }
                if (target.boss)
                {
                    Item.damage += 100;
                }
                if (player.GetModPlayer<SoulSwordPlayer>().killCount % 50 == 0)
                {
                    Item.knockBack += 5;
                    Item.crit += 2;
                    Item.useTime--;
                    Item.useAnimation--;
                }
            }
        }
    }
}