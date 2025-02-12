
最近比较流行的服务端速射的一种实现方式
肯定不是最好的实现，但是它确实工作，我只是无聊

**如果你只想快速参考原理:**

    weapon.NextPrimaryAttackTick = 0;
    Utilities.SetStateChanged(weapon, "CBasePlayerWeapon", "m_nNextPrimaryAttackTick");

