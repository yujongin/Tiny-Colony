using UnityEngine;

public static class Define
{
    public enum EItemName
    {
        Human,
        House01,
        House02,
        Tree01,
        Tree02,
        WindTurbine,
        NuclearPowerStation,
        Bomb
    }

    public enum EUIEvent
    {
        LeftClick,
        RigthClick,
        PointerEnter,
        PointerExit
    }

    public enum EScene
    {
        TitleScene,
        GameScene
    }

    public enum EBonusPoint
    {
        House = 10,
        Tree = 15,
        WindTurbine = 20,
        NuclearPowerStation = 50
    }
}
