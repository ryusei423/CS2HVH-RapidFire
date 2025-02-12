using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using Microsoft.Extensions.Logging;

namespace Rapid;
public class HelloWorldPlugin : BasePlugin
{
    public override string ModuleName => "Rapid";
	public override string ModuleAuthor => "mETE0R";
    public override string ModuleVersion => "0.0.1";

    public override void Load(bool hotReload)
    {
        RegisterListener<Listeners.OnTick>(() =>
        {
            var dogshit = Utilities.GetPlayers();



            for (var i = 0; i < dogshit.Count; i++)
            {
                if (dogshit[i] == null ||
                dogshit[i].IsBot ||
                !dogshit[i].PawnIsAlive) continue;

                var weapon = dogshit[i].Pawn.Get().WeaponServices.ActiveWeapon.Get();

                if (weapon.Clip1 <= 0) continue;

                weapon.NextPrimaryAttackTick = 0;
                weapon.NextPrimaryAttackTickRatio = 0;
                weapon.NextSecondaryAttackTick = 0;
                weapon.NextSecondaryAttackTickRatio = 0;

                Utilities.SetStateChanged(weapon, "CBasePlayerWeapon", "m_nNextPrimaryAttackTick");
                Utilities.SetStateChanged(weapon, "CBasePlayerWeapon", "m_flNextPrimaryAttackTickRatio");
                Utilities.SetStateChanged(weapon, "CBasePlayerWeapon", "m_nNextSecondaryAttackTick");
                Utilities.SetStateChanged(weapon, "CBasePlayerWeapon", "m_flNextSecondaryAttackTickRatio");
            }


        });



    }
}
