using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TungstenOpForContentAddon.Content.Items.Weapons.AutomaticRifles
{
	public class Rangemaster : ModItem
	{
		public override void SetDefaults() {
			// Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

			// Common Properties
			Item.width = 122; // Hitbox width of the item.
			Item.height = 24; // Hitbox height of the item.
			Item.scale = 0.75f;
			Item.value = Item.buyPrice(gold: 20);
			Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 14; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 14; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

			// The sound that this item plays when used.
			Item.UseSound = new SoundStyle($"{nameof(TungstenOpForContentAddon)}/Assets/Sounds/Items/Guns/BL1AssaultRifle") {
				Volume = 0.9f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};

			// Weapon Properties
			Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
			Item.damage = 17; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.knockBack = 3f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shootSpeed = 7f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset() {
			return new Vector2(-32f, -2f);
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}
	}
}
