Public Class Enumerations

    Public Enum PageEnum
        MainMenu
        LoadGame
        NewGame
        WorldMap
        Gym
    End Enum

    Public Enum ElementEnum
        Bug
        Dragon
        Electric
        Fighting
        Fire
        Flying
        Ghost
        Grass
        Ground
        Ice
        Normal
        Poison
        Psychic
        Rock
        Water
    End Enum

    Public Enum MoveKindEnum
        Physical
        Special
        Status
    End Enum

    Public Enum Gender
        Female
        Male
    End Enum

    Public Enum MainStatTypeEnum
        HP
        Defense
        Attack
        SpecialDefense
        SpecialAttack
        Speed
    End Enum

    Public Enum Personality
        'HP Related
        Persistent      '(+HP)
        Stubborn        '(++HP, -DEF)
        'Speed Related
        Smart           '(+SPD)
        Arrogant        '(++SPD, -SPDEF)
        'Attack Related
        Strong          '(+ATK)
        Cocky           '(++ATK, -SPD)
        'Special Attack Related
        Wise            '(+SPATK)
        Aloof           '(++SPATK, -HP)
        'Defense Related
        Considerate     '(+DEF)
        Meek            '(++DEF, -ATK)
        'Special Defense Related
        Intuitive       '(+SPDEF)
        Moody           '(++SPDEF, SPATK)
    End Enum

End Class
