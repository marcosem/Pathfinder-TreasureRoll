Imports System
Imports System.IO
Imports System.Text

Public Structure STRUCTURE_ELEMENT
    Public m_nMinor As Integer
    Public m_nMedium As Integer
    Public m_nMajor As Integer
    Public m_sItem As String
    Public m_nPrice1 As Integer
    Public m_nPrice2 As Integer
    Public m_nPrice3 As Integer
    Public m_sCoin As String
    Public m_sTableLink As String
    Public m_nType As Integer
End Structure


Public Class frmMain
    Private m_bDebugMode As Boolean

    Private m_nTreasureType As Integer

    ' Settlement variables
    Private m_nMagicMinor As Integer
    Private m_nMagicMedium As Integer
    Private m_nMagicMajor As Integer
    Private m_bOnlyMagic As Boolean

    ' NPC Variables
    Private m_nLoot As Integer
    Private m_dLootFactor As Double
    Private m_nEvolution As Integer

    Private m_sSourceFile As String
    Private m_oFileClone As New ArrayList

    Private m_nMinorMagic As Integer
    Private m_nMediumMagic As Integer
    Private m_nMajorMagic As Integer

    Private m_oTableList As New ArrayList
    Private m_oTableListIndexMap As New ArrayList
    Private m_sTreasureTypeCreature As String

    Private TABLE_5_2_RANDOM_ITEMS As String = "[5-2: Random Items]"
    Private TABLE_6_9_GOODS_SERVICES_1 As String = "[6-9: Goods and Services 1]"
    Private TABLE_6_9_GOODS_SERVICES_2 As String = "[6-9: Goods and Services 2]"
    Private TABLE_6_9_GOODS_SERVICES_3 As String = "[6-9: Goods and Services 3]"
    Private TABLE_6_9_GOODS_SERVICES_4 As String = "[6-9: Goods and Services 4]"
    Private TABLE_5_4_ARMOR_SHIELDS As String = "[5-4: Random Armor and Shields]"
    Private TABLE_5_3_ARMOR As String = "[5-3: Random Armor]"
    Private TABLE_5_6_ARMOR_MATERIAL_MET As String = "[5-6: Armor Special Materials: Metals]"
    Private TABLE_5_6_ARMOR_MATERIAL_DRAG As String = "[5-6: Armor Special Materials: Dragonhide]"
    Private TABLE_5_6_ARMOR_MATERIAL_DRAG_MET As String = "[5-6: Armor Special Materials: Dragonhide, metals]"
    Private TABLE_5_4_ARMOR_SHIELDS_MAGICAL As String = "[5-4: Random Armor and Shields: Magical]"
    Private TABLE_5_3_ARMOR_MAGICAL As String = "[5-3: Random Armor: Magical]"
    Private TABLE_5_6_ARMOR_MATERIAL_MET_MAGICAL As String = "[5-6: Armor Special Materials: Metals: Magical]"
    Private TABLE_5_6_ARMOR_MATERIAL_DRAG_MAGICAL As String = "[5-6: Armor Special Materials: Dragonhide: Magical]"
    Private TABLE_5_6_ARMOR_MATERIAL_DRAG_MET_MAGICAL As String = "[5-6: Armor Special Materials: Dragonhide, metals: Magical]"
    Private TABLE_5_8_MAGIC_ARMOR As String = "[5-8: Magic Armor]"
    Private TABLE_5_8_MAGIC_SHIELDS As String = "[5-8: Magic Shields]"
    Private TABLE_5_5_SHIELDS As String = "[5-5: Random Shields]"
    Private TABLE_5_7_SHIELD_MATERIAL_WOOD As String = "[5-7: Shield Special Materials: Wood]"
    Private TABLE_5_7_SHIELD_MATERIAL_STEEL As String = "[5-7: Shield Special Materials: Steel]"
    Private TABLE_5_7_SHIELD_MATERIAL_WOOD_STEEL As String = "[5-7: Shield Special Materials: Wood, steel]"
    Private TABLE_5_5_SHIELDS_MAGICAL As String = "[5-5: Random Shields: Magical]"
    Private TABLE_5_7_SHIELD_MATERIAL_WOOD_MAGICAL As String = "[5-7: Shield Special Materials: Wood: Magical]"
    Private TABLE_5_7_SHIELD_MATERIAL_STEEL_MAGICAL As String = "[5-7: Shield Special Materials: Steel: Magical]"
    Private TABLE_5_7_SHIELD_MATERIAL_WOOD_STEEL_MAGICAL As String = "[5-7: Shield Special Materials: Wood, steel: Magical]"
    Private TABLE_5_9_MAGIC_ARMOR_SPECIAL As String = "[5-9: Magic Armor Special Abilities]"
    Private TABLE_15_6_SPECIFIC_ARMORS As String = "[15-6: Specific Armors]"
    Private TABLE_15_7_SPECIFIC_SHIELDS As String = "[15-7: Specific Shields]"
    Private TABLE_5_10_MAGIC_SHIELD_SPECIAL As String = "[5-10: Magic Shield Special Abilities]"

    Private TABLE_5_19_POTIONS As String = "[5-19: Random Potions and Oils]"
    Private TABLE_5_20_POTIONS_0 As String = "[5-20: 0-Level Potions and Oils]"
    Private TABLE_5_21_POTIONS_1 As String = "[5-21: 1st-Level Potion and Oils]"
    Private TABLE_5_22_POTIONS_2 As String = "[5-22: 2nd-Level Potion and Oils]"
    Private TABLE_5_23_POTIONS_3 As String = "[5-23: 3rd-Level Potion and Oils]"

    Private TABLE_5_24_SCROLLS As String = "[5-24: Random Scrolls]"
    Private TABLE_NUM_SPELL_ARCANE As String = "[5-25: Number of Spells on Scroll: Arcane]"
    Private TABLE_SCROLL_LEVEL_ARCANE As String = "[5-26: Scroll Level: Arcane]"
    Private TABLE_SCROLL_ARCANE_0 As String = "[5-27: 0-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_1 As String = "[5-28: 1st-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_2 As String = "[5-29: 2nd-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_3 As String = "[5-30: 3rd-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_4 As String = "[5-31: 4th-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_5 As String = "[5-32: 5th-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_6 As String = "[5-33: 6th-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_7 As String = "[5-34: 7th-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_8 As String = "[5-35: 8th-Level Arcane Spells]"
    Private TABLE_SCROLL_ARCANE_9 As String = "[5-36: 9th-Level Arcane Spells]"

    Private TABLE_NUM_SPELL_DIVINE As String = "[5-25: Number of Spells on Scroll: Divine]"
    Private TABLE_SCROLL_LEVEL_DIVINE As String = "[5-26: Scroll Level: Divine]"
    Private TABLE_SCROLL_DIVINE_0 As String = "[5-37: 0-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_1 As String = "[5-38: 1st-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_2 As String = "[5-39: 2nd-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_3 As String = "[5-40: 3rd-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_4 As String = "[5-41: 4th-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_5 As String = "[5-42: 5th-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_6 As String = "[5-43: 6th-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_7 As String = "[5-44: 7th-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_8 As String = "[5-45: 8th-Level Divine Spells]"
    Private TABLE_SCROLL_DIVINE_9 As String = "[5-46: 9th-Level Divine Spells]"

    Private TABLE_15_18_MINOR_WONDROUS_ITEMS As String = "[15-18: Minor Wondrous Items]"
    Private TABLE_15_19_MEDIUM_WONDROUS_ITEMS As String = "[15-19: Medium Wondrous Items]"
    Private TABLE_15_20_MAJOR_WONDROUS_ITEMS As String = "[15-20: Major Wondrous Items]"

    Private TABLE_15_13_RINGS As String = "[15-13: Rings]"
    Private TABLE_15_14_RODS As String = "[15-14: Rods]"
    Private TABLE_15_16_STAVES As String = "[15-16: Staves]"

    Private TABLE_5_47_WANDS As String = "[5-47: Random Wands]"
    Private TABLE_5_48_WANDS_0 As String = "[5-48: 0-Level Wands]"
    Private TABLE_5_49_WANDS_1 As String = "[5-49: 1st-Level Wands]"
    Private TABLE_5_50_WANDS_2 As String = "[5-50: 2nd-Level Wands]"
    Private TABLE_5_51_WANDS_3 As String = "[5-51: 3rd-Level Wands]"
    Private TABLE_5_52_WANDS_4 As String = "[5-52: 4th-Level Wands]"

    Private TABLE_5_11_WEAPONS As String = "[5-11: Random Weapons]"
    Private TABLE_5_12_SIMPLE As String = "[5-12: Simple Weapons]"
    Private TABLE_5_13_MARTIAL As String = "[5-13: Martial Weapons]"
    Private TABLE_5_14_EXOTIC As String = "[5-14: Exotic Weapons]"
    Private TABLE_5_15_MATERIAL_METALS As String = "[5-15: Weapon Special Materials: Metals]"
    Private TABLE_5_15_MATERIAL_METALS_WOOD As String = "[5-15: Weapon Special Materials: Metals, wood]"
    Private TABLE_5_15_MATERIAL_WOOD As String = "[5-15: Weapon Special Materials: Wood]"

    Private TABLE_5_11_WEAPONS_MAGICAL As String = "[5-11: Random Weapons: Magical]"
    Private TABLE_5_16_MAGIC_MELEE As String = "[5-16: Magic Weapons: Melee]"
    Private TABLE_5_16_MAGIC_RANGED As String = "[5-16: Magic Weapons: Ranged]"
    Private TABLE_5_17_MELEE_MAGIC As String = "[5-17: Magic Melee Weapon]"
    Private TABLE_5_18_RANGED_MAGIC As String = "[5-18: Magic Ranged Weapon]"
    Private TABLE_15_11_SPECIFIC_WEAPON As String = "[15-11: Specific Weapons]"
    Private TABLE_1_7_GP As String = "[1-7: XP and GP values by CR]"

    'Private TABLE_GEMS As String = "[Gems]"
    Private TABLE_GEM_1 As String = "[7-50: Random gems 1]"
    Private TABLE_GEM_2 As String = "[7-50: Random gems 2]"
    Private TABLE_GEM_3 As String = "[7-50: Random gems 3]"
    Private TABLE_GEM_4 As String = "[7-50: Random gems 4]"
    Private TABLE_GEM_5 As String = "[7-50: Random gems 5]"
    Private TABLE_GEM_6 As String = "[7-50: Random gems 6]"

    'Private TABLE_ART_OBJECTS As String = "[Art Objects]"
    Private TABLE_ART_1 As String = "[7-51: Random Art Objects 1]"
    Private TABLE_ART_2 As String = "[7-51: Random Art Objects 2]"
    Private TABLE_ART_3 As String = "[7-51: Random Art Objects 3]"
    Private TABLE_ART_4 As String = "[7-51: Random Art Objects 4]"
    Private TABLE_ART_5 As String = "[7-51: Random Art Objects 5]"
    Private TABLE_ART_6 As String = "[7-51: Random Art Objects 6]"
    'Private TABLE_ART_7 As String = "[Art 7]"
    'Private TABLE_ART_8 As String = "[Art 8]"
    'Private TABLE_ART_9 As String = "[Art 9]"
    'Private TABLE_ART_10 As String = "[Art 10]"
    'Private TABLE_ART_11 As String = "[Art 11]"
    'Private TABLE_ART_12 As String = "[Art 12]"

    'Private TABLE_COINS As String = "[Treasure Coins]"
    'Private TABLE_GOODS As String = "[Treasure Goods]"
    'Private TABLE_ITEMS As String = "[Treasure Items]"

    Private TABLE_CREATURE_TYPE As String = "[Creature Treasure Type]"
    Private TABLE_TREASURE_A As String = "[7-3: Type A Treasure, Coins]"
    Private TABLE_TREASURE_B As String = "[7-4: Type B Treasure, Coins and Gems]"
    Private TABLE_TREASURE_C As String = "[7-5: Type C Treasure, Art Objects]"
    Private TABLE_TREASURE_D As String = "[7-6: Type D Treasure, Coins and Small Objects]"
    Private TABLE_TREASURE_E As String = "[7-7: Type E Treasure, Armor and Weapons]"
    Private TABLE_TREASURE_F As String = "[7-8: Type F Treasure, Combatant Gear]"
    Private TABLE_TREASURE_G As String = "[7-9: Type G Treasure, Spellcaster Gear]"
    Private TABLE_TREASURE_H As String = "[7-10: Type H Treasure, Lair Treasure]"
    Private TABLE_TREASURE_I As String = "[7-11: Type I Treasure, Treasure Hoard]"

    Private ELEMENT_MINOR As Integer = 0
    Private ELEMENT_MEDIUM As Integer = 1
    Private ELEMENT_MAJOR As Integer = 2
    Private ELEMENT_ITEM As Integer = 3
    Private ELEMENT_PRICES As Integer = 4
    Private ELEMENT_COIN As Integer = 5
    Private ELEMENT_TABLE_LINK As Integer = 6
    Private TOTAL_ELEMENTS As Integer = 7

    Private CAT_MINOR As Integer = 0
    Private CAT_MEDIUM As Integer = 1
    Private CAT_MAJOR As Integer = 2
    Private CAT_MUNDANE_MINOR As Integer = 3
    Private CAT_MUNDANE_MEDIUM As Integer = 4

    Private TREASURE_SETTLEMENT As Integer = 0
    Private TREASURE_BLACK_MARKET As Integer = 1
    Private TREASURE_NPC As Integer = 2
    Private TREASURE_UNIQUE As Integer = 3

    Private EVOLUTION_SLOW As Integer = 0
    Private EVOLUTION_MEDIUM As Integer = 1
    Private EVOLUTION_FAST As Integer = 2

    Private TYPE_MIN As Integer = 0
    Private TYPE_COINS As Integer = 0
    Private TYPE_MUNDANE As Integer = 1
    Private TYPE_GEM As Integer = 2
    Private TYPE_ART As Integer = 3
    Private TYPE_ARMOR As Integer = 4
    Private TYPE_ARMOR_MAGIC As Integer = 5
    Private TYPE_SHIELD As Integer = 6
    Private TYPE_SHIELD_MAGIC As Integer = 7
    Private TYPE_WEAPON_MELEE As Integer = 8
    Private TYPE_WEAPON_MELEE_MAGIC As Integer = 9
    Private TYPE_WEAPON_RANGED As Integer = 10
    Private TYPE_WEAPON_RANGED_MAGIC As Integer = 11
    Private TYPE_POTION As Integer = 12
    Private TYPE_SCROLL_ARCANE As Integer = 12
    Private TYPE_SCROLL_DIVINE As Integer = 13
    Private TYPE_WAND As Integer = 14
    Private TYPE_RING As Integer = 15
    Private TYPE_ROD As Integer = 16
    Private TYPE_STAFF As Integer = 17
    Private TYPE_WONDROUS As Integer = 18
    Private TYPE_MAX As Integer = 19

    Dim m_oRandom As New Random(System.DateTime.Now.Millisecond)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        m_sSourceFile = "TreasureRoll.dat"
        m_bDebugMode = False

        m_nTreasureType = 0
        m_nMagicMinor = 0
        m_nMagicMedium = 0
        m_nMagicMajor = 0

        If (m_bDebugMode = False) Then
            txtHistoric.Visible = False
            Me.Width = 566
        Else
            txtHistoric.Visible = True
            Me.Width = 998
        End If

        Me.LoadAllTables()
    End Sub

    Private Function GetTableByName(ByVal a_sTableName As String, ByRef a_bOnlyOneCategory As Boolean, Optional ByVal a_nLevel As Integer = -1) As ArrayList
        Dim t_oTableArray As ArrayList
        Dim t_nTableIndex As Integer

        t_nTableIndex = m_oTableListIndexMap.IndexOf(a_sTableName)

        If (t_nTableIndex > -1) Then
            t_oTableArray = m_oTableList.Item(t_nTableIndex)

            Select Case a_sTableName
                Case TABLE_5_2_RANDOM_ITEMS
                    a_bOnlyOneCategory = False
                Case TABLE_5_19_POTIONS, TABLE_15_14_RODS, TABLE_15_13_RINGS, TABLE_15_16_STAVES
                    a_bOnlyOneCategory = False
                Case TABLE_5_8_MAGIC_ARMOR, TABLE_5_8_MAGIC_SHIELDS, TABLE_5_9_MAGIC_ARMOR_SPECIAL, TABLE_15_6_SPECIFIC_ARMORS
                    a_bOnlyOneCategory = False
                    'Case TABLE_COINS
                    'a_bOnlyOneCategory = False
                Case TABLE_NUM_SPELL_ARCANE, TABLE_NUM_SPELL_DIVINE
                    a_bOnlyOneCategory = True
                Case TABLE_SCROLL_LEVEL_ARCANE, TABLE_SCROLL_LEVEL_DIVINE, TABLE_5_47_WANDS
                    a_bOnlyOneCategory = False
                Case TABLE_5_16_MAGIC_MELEE, TABLE_5_16_MAGIC_RANGED, TABLE_5_17_MELEE_MAGIC, TABLE_5_18_RANGED_MAGIC, TABLE_15_11_SPECIFIC_WEAPON
                    a_bOnlyOneCategory = False
                Case Else
                    a_bOnlyOneCategory = True
            End Select

            ' Get Table by Level - Some tables are sorted by level, need to take the specific level
            If (a_nLevel > 0) Then
                t_oTableArray = Me.GetTableByLevel(t_oTableArray, a_nLevel)
            End If
        Else
            t_oTableArray = Nothing
        End If

        Return t_oTableArray
    End Function

    Private Function GetTableByLevel(ByVal a_oFullTable As ArrayList, ByVal a_nLevel As Integer) As ArrayList
        Dim t_oNewList As New ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT
        Dim i As Integer

        If (a_oFullTable.Count = 0) Then
            Return Nothing
        End If

        For i = 0 To a_oFullTable.Count - 1
            t_oItem = a_oFullTable.Item(i)
            If (t_oItem.m_nMinor = a_nLevel) Then
                t_oItem.m_nMinor = t_oItem.m_nMedium
                t_oItem.m_nMedium = 0
                t_oNewList.Add(t_oItem)
            End If
        Next i

        Return t_oNewList
    End Function

    Private Sub LoadAllTables()
        If (Not File.Exists(m_sSourceFile)) Then
            MsgBox("File <" & m_sSourceFile & "> not found! The application will not work properly.", MsgBoxStyle.Critical, Me.Text)
            Exit Sub
        End If

        Dim t_oSourceFile As StreamReader = File.OpenText(m_sSourceFile)
        Dim t_sLine As String
        Dim t_sTableName As String = ""
        Dim i As Integer
        'Dim t_bNewTable As Boolean = False

        m_oFileClone.Clear()

        Do
            t_sLine = t_oSourceFile.ReadLine()
            m_oFileClone.Add(t_sLine)
        Loop Until t_sLine Is Nothing

        t_oSourceFile.Close()

        ' Initialize the lists
        Me.m_oTableList.Clear()
        Me.m_oTableListIndexMap.Clear()

        Dim t_oSingleTable As ArrayList = Nothing

        '/////////////
        Dim t_sSplitedLine As String()
        Dim t_sSplitedPrice As String()
        Dim t_oStruct_Item As STRUCTURE_ELEMENT
        '/////////////

        For i = 0 To m_oFileClone.Count - 1
            t_sLine = m_oFileClone.Item(i)

            ' Ignore blank lines
            If (t_sLine Is Nothing) Then
                If (i = m_oFileClone.Count - 1) Then
                    If (t_oSingleTable IsNot Nothing) Then
                        If ((t_sTableName <> "") And (t_oSingleTable.Count > 0)) Then
                            m_oTableList.Add(t_oSingleTable)
                            m_oTableListIndexMap.Add(t_sTableName)
                        End If
                    End If
                End If
                Continue For
            End If

            If (t_sLine.Trim(" ") = "") Then
                If (i = m_oFileClone.Count - 1) Then
                    If (t_oSingleTable IsNot Nothing) Then
                        If ((t_sTableName <> "") And (t_oSingleTable.Count > 0)) Then
                            m_oTableList.Add(t_oSingleTable)
                            m_oTableListIndexMap.Add(t_sTableName)
                        End If
                    End If
                End If
                Continue For
            End If

            If ((t_sLine.StartsWith("[") = True) Or (i = m_oFileClone.Count - 1)) Then
                If (t_oSingleTable IsNot Nothing) Then
                    If ((t_sTableName <> "") And (t_oSingleTable.Count > 0)) Then
                        m_oTableList.Add(t_oSingleTable)
                        m_oTableListIndexMap.Add(t_sTableName)
                    End If
                End If

                If (i = m_oFileClone.Count - 1) Then
                    Continue For
                End If

                t_sTableName = t_sLine
                t_oSingleTable = New ArrayList
                t_oSingleTable.Clear()

                If ((m_bOnlyMagic = True) And (t_sTableName = TABLE_5_2_RANDOM_ITEMS)) Then
                    't_bCheckForMagical = True
                    m_nMinorMagic = 0
                    m_nMediumMagic = 0
                    m_nMajorMagic = 0
                End If
                't_bNewTable = True
            Else
                If ((t_sTableName <> "") And (t_oSingleTable IsNot Nothing)) Then
                    t_sSplitedLine = t_sLine.Split("|")

                    If (t_sSplitedLine.Count() = TOTAL_ELEMENTS) Then
                        t_oStruct_Item = New STRUCTURE_ELEMENT

                        Me.InitializeStructure(t_oStruct_Item)

                        ' Load Minor chance
                        Try
                            If (t_sSplitedLine(ELEMENT_MINOR) = "") Then
                                t_oStruct_Item.m_nMinor = -1
                            Else
                                t_oStruct_Item.m_nMinor = Convert.ToInt32(t_sSplitedLine(ELEMENT_MINOR))
                            End If
                        Catch ex As Exception
                            t_oStruct_Item.m_nMinor = -1
                        End Try

                        ' Load Medium chance
                        Try
                            If (t_sSplitedLine(ELEMENT_MEDIUM) = "") Then
                                t_oStruct_Item.m_nMedium = -1
                            Else
                                t_oStruct_Item.m_nMedium = Convert.ToInt32(t_sSplitedLine(ELEMENT_MEDIUM))
                            End If
                        Catch ex As Exception
                            t_oStruct_Item.m_nMedium = -1
                        End Try

                        Try
                            ' Load Major chance
                            If (t_sSplitedLine(ELEMENT_MAJOR) = "") Then
                                t_oStruct_Item.m_nMajor = -1
                            Else
                                t_oStruct_Item.m_nMajor = Convert.ToInt32(t_sSplitedLine(ELEMENT_MAJOR))
                            End If
                        Catch ex As Exception
                            t_oStruct_Item.m_nMajor = -1
                        End Try

                        ' Load item name
                        t_oStruct_Item.m_sItem = t_sSplitedLine(ELEMENT_ITEM)
                        If (t_oStruct_Item.m_sItem IsNot Nothing) Then
                            ' Define the minimal value for a magic item
                            If ((t_oStruct_Item.m_sItem.IndexOf("non-magical") = -1) And (t_oStruct_Item.m_sItem.IndexOf("Mundane") = -1)) Then
                                If (m_nMinorMagic = 0) Then
                                    m_nMinorMagic = t_oStruct_Item.m_nMinor
                                End If

                                If (m_nMediumMagic = 0) Then
                                    m_nMediumMagic = t_oStruct_Item.m_nMedium
                                End If

                                If (m_nMajorMagic = 0) Then
                                    m_nMajorMagic = t_oStruct_Item.m_nMajor
                                End If
                            End If
                        End If

                        Try
                            ' Load Prices
                            If (t_sSplitedLine(ELEMENT_PRICES) = "") Then
                                t_oStruct_Item.m_nPrice1 = 0
                                t_oStruct_Item.m_nPrice2 = 0
                                t_oStruct_Item.m_nPrice3 = 0
                            ElseIf (t_sSplitedLine(ELEMENT_PRICES) = "x2") Then
                                t_oStruct_Item.m_nPrice1 = -2
                                t_oStruct_Item.m_nPrice2 = -2
                                t_oStruct_Item.m_nPrice3 = -2
                            Else
                                t_sSplitedPrice = t_sSplitedLine(ELEMENT_PRICES).Split(",")
                                ' Load Price 1
                                If (t_sSplitedPrice.Count > 0) Then
                                    If (t_sSplitedPrice(0) = "") Then
                                        t_oStruct_Item.m_nPrice1 = 0
                                    ElseIf (t_sSplitedPrice(0) = "X") Then
                                        t_oStruct_Item.m_nPrice1 = -1000
                                    Else
                                        t_oStruct_Item.m_nPrice1 = Convert.ToInt32(t_sSplitedPrice(0))
                                    End If

                                    ' Load Price 2
                                    If (t_sSplitedPrice.Count > 1) Then
                                        If (t_sSplitedPrice(1) = "") Then
                                            t_oStruct_Item.m_nPrice2 = 0
                                        ElseIf (t_sSplitedPrice(1) = "X") Then
                                            t_oStruct_Item.m_nPrice2 = -1000
                                        Else
                                            t_oStruct_Item.m_nPrice2 = Convert.ToInt32(t_sSplitedPrice(1))
                                        End If

                                        ' Load Price 3
                                        If (t_sSplitedPrice.Count > 2) Then
                                            If (t_sSplitedPrice(2) = "") Then
                                                t_oStruct_Item.m_nPrice3 = 0
                                            ElseIf (t_sSplitedPrice(2) = "X") Then
                                                t_oStruct_Item.m_nPrice3 = -1000
                                            Else
                                                t_oStruct_Item.m_nPrice3 = Convert.ToInt32(t_sSplitedPrice(2))
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            t_oStruct_Item.m_nPrice1 = 0
                            t_oStruct_Item.m_nPrice2 = 0
                            t_oStruct_Item.m_nPrice3 = 0
                        End Try

                        ' Load Coin type
                        t_oStruct_Item.m_sCoin = t_sSplitedLine(ELEMENT_COIN)

                        ' Load Table Link
                        t_oStruct_Item.m_sTableLink = t_sSplitedLine(ELEMENT_TABLE_LINK)

                        ' Add Structure to List
                        t_oSingleTable.Add(t_oStruct_Item)
                    End If
                End If
            End If
        Next i
    End Sub

    Public Sub InitializeStructure(ByRef a_oStruct As STRUCTURE_ELEMENT)
        a_oStruct.m_sCoin = ""
        a_oStruct.m_sItem = ""
        a_oStruct.m_sTableLink = ""
    End Sub

    Private Function GetMaximumValidRoll(ByVal a_oTableArray As ArrayList, Optional ByVal a_nCategory As Integer = 0) As Integer ' CAT_MINOR = 0
        Dim t_nMaximum As Integer = -1
        Dim t_oStruct_Item As STRUCTURE_ELEMENT
        Dim i As Integer

        For i = 0 To a_oTableArray.Count - 1
            t_oStruct_Item = a_oTableArray.Item(i)

            Select Case a_nCategory
                Case CAT_MINOR
                    If (t_nMaximum < t_oStruct_Item.m_nMinor) Then
                        t_nMaximum = t_oStruct_Item.m_nMinor
                    End If
                Case CAT_MEDIUM
                    If (t_nMaximum < t_oStruct_Item.m_nMedium) Then
                        t_nMaximum = t_oStruct_Item.m_nMedium
                    End If
                Case CAT_MAJOR
                    If (t_nMaximum < t_oStruct_Item.m_nMajor) Then
                        t_nMaximum = t_oStruct_Item.m_nMajor
                    End If
                Case CAT_MUNDANE_MINOR
                    If ((t_oStruct_Item.m_sItem.IndexOf("Mundane") > -1) Or (t_oStruct_Item.m_sItem.IndexOf("non-magical") > -1)) Then
                        If (t_nMaximum < t_oStruct_Item.m_nMinor) Then
                            t_nMaximum = t_oStruct_Item.m_nMinor
                        End If
                    End If
                Case CAT_MUNDANE_MEDIUM
                    If ((t_oStruct_Item.m_sItem.IndexOf("Mundane") > -1) Or (t_oStruct_Item.m_sItem.IndexOf("non-magical") > -1)) Then
                        If (t_nMaximum < t_oStruct_Item.m_nMedium) Then
                            t_nMaximum = t_oStruct_Item.m_nMedium
                        End If
                    End If
                Case Else
                    Return -1
            End Select
        Next i

        Return t_nMaximum
    End Function

    Private Sub btnRoll_Click(sender As Object, e As EventArgs) Handles btnRoll.Click
        txtHistoric.Text = ""
        txtResult.Text = ""
        Dim i As Integer = 0
        Dim t_oResult As New ArrayList
        Dim t_sItem As String = ""

        Select Case m_nTreasureType
            Case TREASURE_SETTLEMENT
                t_oResult = Me.RollSettlement()
            Case TREASURE_BLACK_MARKET
                t_oResult = Me.RollBlackMarket()
            Case TREASURE_NPC
                t_oResult = Me.RollNPC()
            Case TREASURE_UNIQUE
        End Select

        If (t_oResult.Count > 0) Then
            For i = 0 To t_oResult.Count - 1
                t_sItem = t_oResult.Item(i) & vbCrLf
                txtResult.Text = txtResult.Text & t_sItem
            Next i
        End If
    End Sub

    Private Function RollNPC() As ArrayList
        Dim t_oResult As New ArrayList

        Dim t_oItem As STRUCTURE_ELEMENT = Nothing
        Dim t_sLevel As String = Me.cmbNPC.Text
        Dim t_sCreature As String = Me.cmbNPCType.Text
        Dim t_nLevel As String
        'Dim t_nLowLevelFactor As Integer = 1

        ' Getting Creature Table to see the loot options
        Dim t_bOnlyOneCategory As Boolean
        Dim t_oTableArray As ArrayList = Me.GetTableByName(TABLE_CREATURE_TYPE, t_bOnlyOneCategory)

        If (t_oTableArray Is Nothing) Then
            Return t_oResult
        End If

        Dim i As Integer
        Dim t_nLimit As Integer
        Dim t_nRateLimit As Integer
        Dim t_sLootLimit As String

        ' Get Limit
        Try
            t_sLootLimit = txtNPCLoot.Text.Replace(".", "")
            t_sLootLimit = t_sLootLimit.Replace(",", "")
            t_sLootLimit = t_sLootLimit.Replace(" ", "")

            t_nLimit = Convert.ToInt32(t_sLootLimit) * 1.5
        Catch ex As Exception
            t_nLimit = 0
        End Try

        Dim t_nTotalGp As Integer = 0

        t_oResult.Add(t_sCreature & " treasure - CR level (" & t_sLevel & ")")

        Select Case t_sLevel
            Case ""
                Return t_oResult
            Case "1/8", "1/6", "1/4", "1/3", "1/2"
                t_nLevel = 1
                'Try
                '    t_nLowLevelFactor = Convert.ToInt32(t_sLevel.Replace("1/", ""))
                'Catch ex As Exception
                '    t_nLowLevelFactor = 2
                'End Try
            Case Else
                't_nLowLevelFactor = 1
                Try
                    t_nLevel = Convert.ToInt32(t_sLevel)
                Catch ex As Exception
                    t_nLevel = 1
                End Try
        End Select

        ' Getting the creature type data
        For i = 0 To t_oTableArray.Count - 1
            t_oItem = t_oTableArray.Item(i)
            If (t_oItem.m_sItem = t_sCreature) Then
                Exit For
            End If
        Next i

        If (t_oItem.m_sItem = "") Then
            t_oResult.Clear()
            Return t_oResult
        End If

        ' Add or removing the extras loot depending on creature improvements...
        'Dim t_sTreasureList As String()
        'Dim t_nTreasureTotal As Integer = 0
        't_sTreasureList = t_oItem.m_sCoin.Split(",")
        'If ((t_oItem.m_sTableLink <> "") And (Me.chkNPCAddExtra.Checked = True)) Then
        '    For i = 0 To t_sTreasureList.Count - 1
        '        If (t_sTreasureList(i).IndexOf("*") > -1) Then
        '            t_sTreasureList(i) = t_sTreasureList(i).Replace("*", "")
        '        End If
        '        t_nTreasureTotal = t_nTreasureTotal + 1
        '    Next i
        'Else
        '    For i = 0 To t_sTreasureList.Count - 1
        '        If (t_sTreasureList(i).IndexOf("*") > -1) Then
        '            t_sTreasureList(i) = "*"
        '        Else
        '            t_nTreasureTotal = t_nTreasureTotal + 1
        '        End If
        '    Next i
        'End If
        Dim t_oTreasures As New ArrayList
        If (Me.chk_TreasureA.Checked = True) Then
            t_oTreasures.Add("A")
        End If
        If (Me.chk_TreasureB.Checked = True) Then
            t_oTreasures.Add("B")
        End If
        If (Me.chk_TreasureC.Checked = True) Then
            t_oTreasures.Add("C")
        End If
        If (Me.chk_TreasureD.Checked = True) Then
            t_oTreasures.Add("D")
        End If
        If (Me.chk_TreasureE.Checked = True) Then
            t_oTreasures.Add("E")
        End If
        If (Me.chk_TreasureF.Checked = True) Then
            t_oTreasures.Add("F")
        End If
        If (Me.chk_TreasureG.Checked = True) Then
            t_oTreasures.Add("G")
        End If
        If (Me.chk_TreasureH.Checked = True) Then
            t_oTreasures.Add("H")
        End If
        If (Me.chk_TreasureI.Checked = True) Then
            t_oTreasures.Add("I")
        End If

        If (t_oTreasures.Count = 0) Then
            t_oResult.Clear()
            Return t_oResult
        End If

        ' Building Treasure list used for user.
        Dim t_sTreasureLine As String = ""
        ' Taking how much of each treasure type
        t_nRateLimit = t_nLimit / t_oTreasures.Count

        Dim t_oTreasure As New ArrayList
        Dim t_oTreasureList As New ArrayList
        Dim j As Integer

        For i = 0 To t_oTreasures.Count - 1
            Select Case t_oTreasures.Item(i)
                Case "A" ' Type A Treasure, Coins
                    t_oTreasure = Me.PickTreasureA(t_nRateLimit)
                Case "B"
                    t_oTreasure = Me.PickTreasureB(t_nRateLimit)
                Case "C"
                    t_oTreasure = Me.PickTreasureC(t_nRateLimit)
                Case "D"
                    t_oTreasure = Me.PickTreasureD(t_nRateLimit)
                Case "E"
                    t_oTreasure = Me.PickTreasureE(t_nRateLimit)
                Case "F"
                    t_oTreasure = Me.PickTreasureF(t_nRateLimit)
                Case "G"
                    t_oTreasure = Me.PickTreasureG(t_nRateLimit)
                Case "H"
                    t_oTreasure = Me.PickTreasureH(t_nRateLimit)
                Case "I"
                    t_oTreasure = Me.PickTreasureI(t_nRateLimit)
            End Select

            ' Add the new Treasure to the full list
            If (t_oTreasure.Count > 0) Then
                If (t_sTreasureLine = "") Then
                    t_sTreasureLine = t_oTreasures.Item(i)
                Else
                    t_sTreasureLine = t_sTreasureLine & ", " & t_oTreasures.Item(i)
                End If

                For j = 0 To t_oTreasure.Count - 1
                    t_oTreasureList.Add(t_oTreasure.Item(j))
                Next j
                t_oTreasure.Clear()
            End If
        Next i

        t_oResult.Add("Treasure Lists: " & t_sTreasureLine)

        Dim t_nCoins As Integer
        Dim t_oMarkedForRemovalList As New ArrayList

        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)
            t_nCoins = t_oItem.m_nPrice1

            Select Case t_oItem.m_sCoin
                Case "gp"
                    t_nTotalGp = t_nTotalGp + t_nCoins
                Case "pp"
                    t_nCoins = t_nCoins * 10
                    t_nTotalGp = t_nTotalGp + t_nCoins
                Case "sp"
                    t_nCoins = t_nCoins / 10
                    t_nTotalGp = t_nTotalGp + t_nCoins
                Case "cp"
                    t_nCoins = t_nCoins / 100
                    t_nTotalGp = t_nTotalGp + t_nCoins
            End Select

            If (t_nTotalGp > t_nLimit) Then
                t_oMarkedForRemovalList.Add(i)
                t_nTotalGp = t_nTotalGp - t_nCoins
            End If
        Next i

        If (t_oMarkedForRemovalList.Count > 0) Then
            Dim t_nIndex As Integer
            For i = t_oMarkedForRemovalList.Count - 1 To 0 Step -1
                t_nIndex = t_oMarkedForRemovalList.Item(i)
                t_oTreasureList.RemoveAt(t_nIndex)
            Next i
        End If

        't_oResult.Add("------ Value Total ------")
        Dim t_sLine As String = ""
        t_sLine = "Treasure value total: " & FormatNumber(t_nTotalGp, 0, , TriState.True) & " gp"
        t_oResult.Add(t_sLine)
        t_sLine = ""
        t_oResult.Add("")

        ' Sort Treasure List
        Me.SortItems(t_oTreasureList)

        ' Get all coins
        Dim t_sCoinsType(4) As String
        t_sCoinsType(0) = "pp"
        t_sCoinsType(1) = "gp"
        t_sCoinsType(2) = "sp"
        t_sCoinsType(3) = "cp"

        For j = 0 To t_sCoinsType.Count - 1
            For i = 0 To t_oTreasureList.Count - 1
                t_oItem = t_oTreasureList.Item(i)

                If ((t_oItem.m_nType = TYPE_COINS) And (t_oItem.m_sCoin = t_sCoinsType(j))) Then
                    If (t_sLine = "") Then
                        t_sLine = FormatNumber(t_oItem.m_nPrice1, 0, , TriState.True) & " " & t_oItem.m_sCoin
                    Else
                        t_sLine = t_sLine & ", " & FormatNumber(t_oItem.m_nPrice1, 0, , TriState.True) & " " & t_oItem.m_sCoin
                    End If
                End If
            Next i
        Next j

        If (t_sLine <> "") Then
            t_oResult.Add("------ Coins ------")
            t_oResult.Add(t_sLine)
            t_oResult.Add("")
            t_sLine = ""
        End If

        ' Getting Gems
        Dim t_bHaveThis As Boolean = False
        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)

            If (t_oItem.m_nType = TYPE_GEM) Then
                If (t_bHaveThis = False) Then
                    t_oResult.Add("------ Gemstones ------")
                    t_bHaveThis = True
                End If

                t_sLine = Me.GetItemText(t_oItem)
                t_oResult.Add(t_sLine)
            End If
        Next i

        If (t_bHaveThis = True) Then
            t_oResult.Add("")
            t_sLine = ""
            t_bHaveThis = False
        End If


        ' Getting Arts
        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)

            If (t_oItem.m_nType = TYPE_ART) Then
                If (t_bHaveThis = False) Then
                    t_oResult.Add("------ Art Objects ------")
                    t_bHaveThis = True
                End If

                t_sLine = Me.GetItemText(t_oItem)
                t_oResult.Add(t_sLine)
            End If
        Next i

        If (t_bHaveThis = True) Then
            t_oResult.Add("")
            t_sLine = ""
            t_bHaveThis = False
        End If


        ' Getting small magical items
        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)

            If ((t_oItem.m_nType = TYPE_WAND) Or (t_oItem.m_nType = TYPE_POTION) Or (t_oItem.m_nType = TYPE_SCROLL_ARCANE) Or (t_oItem.m_nType = TYPE_SCROLL_DIVINE)) Then
                If (t_bHaveThis = False) Then
                    t_oResult.Add("------ Small Magical Items ------")
                    t_bHaveThis = True
                End If

                t_sLine = Me.GetItemText(t_oItem)
                t_oResult.Add(t_sLine)
            End If
        Next i

        If (t_bHaveThis = True) Then
            t_oResult.Add("")
            t_sLine = ""
            t_bHaveThis = False
        End If

        ' Getting armors and weapons
        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)

            If ((t_oItem.m_nType = TYPE_ARMOR) Or (t_oItem.m_nType = TYPE_SHIELD) Or (t_oItem.m_nType = TYPE_WEAPON_MELEE) Or (t_oItem.m_nType = TYPE_WEAPON_RANGED)) Then
                If (t_bHaveThis = False) Then
                    t_oResult.Add("------ Armors and Weapons ------")
                    t_bHaveThis = True
                End If

                t_sLine = Me.GetItemText(t_oItem)
                t_oResult.Add(t_sLine)
            End If
        Next i

        If (t_bHaveThis = True) Then
            t_oResult.Add("")
            t_sLine = ""
            t_bHaveThis = False
        End If

        ' Getting magic armors and weapons
        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)

            If ((t_oItem.m_nType = TYPE_ARMOR_MAGIC) Or (t_oItem.m_nType = TYPE_SHIELD_MAGIC) Or (t_oItem.m_nType = TYPE_WEAPON_MELEE_MAGIC) Or (t_oItem.m_nType = TYPE_WEAPON_RANGED_MAGIC)) Then
                If (t_bHaveThis = False) Then
                    t_oResult.Add("------ Magical Armors and Weapons ------")
                    t_bHaveThis = True
                End If

                t_sLine = Me.GetItemText(t_oItem)
                t_oResult.Add(t_sLine)
            End If
        Next i

        If (t_bHaveThis = True) Then
            t_oResult.Add("")
            t_sLine = ""
            t_bHaveThis = False
        End If

        ' Other magical objects
        For i = 0 To t_oTreasureList.Count - 1
            t_oItem = t_oTreasureList.Item(i)

            If ((t_oItem.m_nType = TYPE_WONDROUS) Or (t_oItem.m_nType = TYPE_RING) Or (t_oItem.m_nType = TYPE_ROD) Or (t_oItem.m_nType = TYPE_STAFF)) Then
                If (t_bHaveThis = False) Then
                    t_oResult.Add("------ Magical Items ------")
                    t_bHaveThis = True
                End If

                t_sLine = Me.GetItemText(t_oItem)
                t_oResult.Add(t_sLine)
            End If
        Next i

        If (t_bHaveThis = True) Then
            t_oResult.Add("")
            t_sLine = ""
            t_bHaveThis = False
        End If

        Return t_oResult
    End Function

    Private Function GetItemInATreasureTable(ByVal a_nValue As Integer, ByVal a_sTable As String) As STRUCTURE_ELEMENT
        Dim t_oLastItem As STRUCTURE_ELEMENT
        Dim t_oCurrItem As STRUCTURE_ELEMENT = Nothing
        Dim t_oItem As STRUCTURE_ELEMENT = Nothing
        'Dim t_oNewItem As STRUCTURE_ELEMENT = Nothing
        'Dim t_oItemList As New ArrayList

        Dim t_bOnlyOneCategory As Boolean
        Dim t_oTableArray As ArrayList = Me.GetTableByName(a_sTable, t_bOnlyOneCategory)
        Dim t_nVeryLast As Integer = 0
        Dim t_nLastValue As Integer = 0
        Dim t_nCurrValue As Integer = 0
        Dim t_nThreshold As Integer = 0
        Dim i As Integer

        ' Using threshold...
        For i = 0 To t_oTableArray.Count - 1
            t_oLastItem = t_oCurrItem
            t_oCurrItem = t_oTableArray.Item(i)
            t_oItem = t_oCurrItem
            t_nVeryLast = t_nLastValue
            t_nLastValue = t_nCurrValue
            t_nCurrValue = t_oCurrItem.m_nMinor

            If (i > 0) Then
                If (t_nLastValue < t_nCurrValue) Then ' Usual case, when last value is lower than current value
                    If (a_nValue <= t_nCurrValue) Then ' Got it
                        t_oItem = t_oLastItem
                        Exit For
                    End If

                    'If ((a_nValue >= t_nLastValue) And (a_nValue <= t_nCurrValue)) Then ' Got it
                    '    t_oItem = t_oLastItem
                    '    Exit For
                    'End If
                Else ' Unusual case, when last value and current value are the same
                    If (i < t_oTableArray.Count - 1) Then
                        Dim t_oFutureItem As STRUCTURE_ELEMENT = t_oTableArray.Item(i + 1)
                        Dim t_nFutureValue As Integer = t_oFutureItem.m_nMinor

                        If (a_nValue <= t_nFutureValue) Then ' Got it
                            t_nThreshold = ((t_nFutureValue - t_nCurrValue) / 2) + t_nCurrValue
                            If (a_nValue <= t_nThreshold) Then
                                t_oItem = t_oLastItem
                            Else
                                t_oItem = t_oCurrItem
                            End If
                            Exit For
                        End If

                        'If ((a_nValue >= t_nCurrValue) And (a_nValue <= t_nFutureValue)) Then ' Got it
                        '    t_nThreshold = ((t_nFutureValue - t_nCurrValue) / 2) + t_nCurrValue
                        '    If (a_nValue <= t_nThreshold) Then
                        '        t_oItem = t_oLastItem
                        '    Else
                        '        t_oItem = t_oCurrItem
                        '    End If
                        '    Exit For
                        'End If
                    Else
                        If (a_nValue <= t_nLastValue) Then
                            t_nThreshold = ((t_nLastValue - t_nVeryLast) / 2) + t_nVeryLast
                            If (a_nValue <= t_nThreshold) Then
                                t_oItem = t_oLastItem
                            Else
                                t_oItem = t_oCurrItem
                            End If
                            Exit For
                        End If
                    End If
                End If
                'Else
                '    If (a_nValue * 2 < t_nCurrValue) Then
                '        t_oItem = Nothing
                '        Exit For
                '    End If
            End If
        Next i

        Return t_oItem
    End Function

    Private Function PickTreasureA(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_A)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureB(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_B)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureC(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_C)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureD(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_D)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureE(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_E)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureF(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_F)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureG(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_G)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureH(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_H)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickTreasureI(ByVal a_nValue As Integer) As ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT = Me.GetItemInATreasureTable(a_nValue, TABLE_TREASURE_I)
        Dim t_oItemList As ArrayList = Me.PickItemListByCode(t_oItem)

        Return t_oItemList
    End Function

    Private Function PickItemListByCode(ByRef a_oItem As STRUCTURE_ELEMENT) As ArrayList
        Dim t_oItemList As New ArrayList

        If (a_oItem.m_sItem = "") Then
            Return t_oItemList
        End If

        Dim t_sQtys As String() = a_oItem.m_sItem.Split(",")
        Dim t_sItems As String() = a_oItem.m_sCoin.Split(",")
        Dim t_nQty As Integer
        Dim t_nCategory As Integer
        Dim t_nGrade As Integer

        Dim t_oNewItem As STRUCTURE_ELEMENT = Nothing

        If (t_sQtys.Count <> t_sItems.Count) Then
            t_oItemList.Clear()
        Else
            For i = 0 To t_sQtys.Count - 1
                ' Getting the category, if there is any
                If (t_sItems(i).Length > 2) Then
                    If (t_sItems(i).IndexOf("mi") > -1) Then
                        t_nCategory = CAT_MINOR
                    ElseIf (t_sItems(i).IndexOf("me") > -1) Then
                        t_nCategory = CAT_MEDIUM
                    ElseIf ((t_sItems(i).IndexOf("ma") > -1) And (t_sItems(i) <> "marmor")) Then
                        t_nCategory = CAT_MAJOR
                    Else
                        t_nCategory = 0
                    End If
                Else
                    t_nCategory = 0
                End If

                ' Getting loot type
                Select Case t_sItems(i)
                    Case "cp", "sp", "gp", "pp" ' Coins
                        Dim t_nCoins As Integer
                        t_oNewItem = New STRUCTURE_ELEMENT
                        t_oNewItem.m_sItem = "coins"
                        t_oNewItem.m_nType = TYPE_COINS
                        t_oNewItem.m_sCoin = t_sItems(i)

                        Select Case i
                            Case 0
                                t_nCoins = RollDices(t_sQtys(i)) * a_oItem.m_nPrice1
                            Case 1
                                t_nCoins = RollDices(t_sQtys(i)) * a_oItem.m_nPrice2
                            Case 2
                                t_nCoins = RollDices(t_sQtys(i)) * a_oItem.m_nPrice3
                            Case 3
                                Try
                                    t_nCoins = RollDices(t_sQtys(i)) * Convert.ToInt32(a_oItem.m_sTableLink)
                                Catch ex As Exception
                                    t_nCoins = RollDices(t_sQtys(i))
                                End Try
                        End Select

                        t_oNewItem.m_nPrice1 = t_nCoins
                        t_oItemList.Add(t_oNewItem)

                    Case "art1", "art2", "art3", "art4", "art5", "art6" ' Art objects
                        Try
                            t_nGrade = Convert.ToInt32(t_sItems(i).Replace("art", ""))
                        Catch ex As Exception
                            t_nGrade = 1
                        End Try

                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickArtObject(t_nGrade)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "gem1", "gem2", "gem3", "gem4", "gem5", "gem6" ' Gemstones
                        Try
                            t_nGrade = Convert.ToInt32(t_sItems(i).Replace("gem", ""))
                        Catch ex As Exception
                            t_nGrade = 1
                        End Try

                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickGem(t_nGrade)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "larmorshield", "marmor", "harmor", "shield" ' Ordinary Armor or Shield
                        If (t_sItems(i) = "larmorshield") Then
                            t_nCategory = ARMOR_TYPE_LIGHT_OR_SHIELD
                        ElseIf (t_sItems(i) = "marmor") Then
                            t_nCategory = ARMOR_TYPE_MEDIUM
                        ElseIf (t_sItems(i) = "harmor") Then
                            t_nCategory = ARMOR_TYPE_HEAVY
                        Else
                            t_nCategory = ARMOR_TYPE_SHIELD
                        End If

                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickArmorAndShields(False, t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "weapon" ' Ordinary Weapon
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickWeapon()
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "lmiarmor", "gmiarmor", "lmearmor", "gmearmor", "lmaarmor", "gmaarmor" ' Magical Armor
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickArmorAndShieldsMagical(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "lmiweapon", "gmiweapon", "lmeweapon", "gmeweapon", "lmaweapon", "gmaweapon" ' Magical Weapons
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickWeaponMagical(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "lmiscroll", "gmiscroll", "lmescroll", "gmescroll", "lmascroll", "gmascroll" ' Scrolls
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickScroll(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "lmipotion", "gmipotion", "lmepotion", "gmepotion", "lmapotion", "gmapotion" ' Potions
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickPotion(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "lmiwand", "gmiwand", "lmewand", "gmewand", "lmawand", "gmawand" ' Wands
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickWand(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j
                    Case "lmiwondrous", "gmiwondrous", "lmewondrous", "gmewondrous", "lmawondrous", "gmawondrous"
                        Dim t_sTable As String
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        If (t_nCategory = CAT_MAJOR) Then
                            t_sTable = TABLE_15_20_MAJOR_WONDROUS_ITEMS
                        ElseIf (t_nCategory = CAT_MEDIUM) Then
                            t_sTable = TABLE_15_19_MEDIUM_WONDROUS_ITEMS
                        Else
                            t_sTable = TABLE_15_18_MINOR_WONDROUS_ITEMS
                        End If

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickWondrousItem(t_sTable)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j

                    Case "lmiring", "gmiring", "lmering", "gmering", "lmaring", "gmaring"
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickRing(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j
                    Case "lmerod", "gmerod", "lmarod", "gmarod"
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickRod(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j
                    Case "lmestaff", "gmestaff", "lmastaff", "gmastaff"
                        Try
                            t_nQty = Convert.ToInt32(t_sQtys(i))
                        Catch ex As Exception
                            t_nQty = 1
                        End Try

                        For j = 0 To t_nQty - 1
                            t_oNewItem = Me.PickStaff(t_nCategory)
                            If (t_oNewItem.m_sItem <> "") Then
                                t_oItemList.Add(t_oNewItem)
                            End If
                        Next j
                End Select
            Next i
        End If


        Return t_oItemList
    End Function

    Private Function RollSettlement() As ArrayList
        Dim t_oResult As New ArrayList
        Dim i As Integer = 0
        Dim t_sItem As String = ""

        Dim t_oItemList As New ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT

        Me.RollSettlementQty()
        If (m_nMagicMinor > 0) Then
            t_oResult.Add("Settlement's Treasure (" & cmbSettlement.Text & ")")
            t_oResult.Add("")
            t_oResult.Add("------ Minor Magic Items: " & m_nMagicMinor & " ------")

            ' Get Items
            For i = 0 To m_nMagicMinor - 1
                't_sItem = ""
                Do
                    t_oItem = Me.PickAnItem(CAT_MINOR)
                    't_sItem = GetItemText(Me.PickAnItem(CAT_MINOR))
                    'Threading.Thread.Sleep(4)
                Loop While t_oItem.m_sItem = ""

                t_oItemList.Add(t_oItem)
                't_oResult.Add(t_sItem)
            Next i

            ' Sort them
            Me.SortItems(t_oItemList)

            ' Add them to the view
            For i = 0 To t_oItemList.Count - 1
                t_oItem = t_oItemList.Item(i)
                t_sItem = GetItemText(t_oItem)
                t_oResult.Add(t_sItem)
            Next i

            t_oItemList.Clear()
        End If

        If (m_nMagicMedium > 0) Then
            t_oResult.Add("")
            t_oResult.Add("------ Medium Magic Items: " & m_nMagicMedium & " ------")

            ' Get Items
            For i = 0 To m_nMagicMedium - 1
                't_sItem = ""
                Do
                    t_oItem = Me.PickAnItem(CAT_MEDIUM)
                    't_sItem = GetItemText(Me.PickAnItem(CAT_MINOR))
                    'Threading.Thread.Sleep(4)
                Loop While t_oItem.m_sItem = ""

                t_oItemList.Add(t_oItem)
                't_oResult.Add(t_sItem)
            Next i

            ' Sort them
            Me.SortItems(t_oItemList)

            ' Add them to the view
            For i = 0 To t_oItemList.Count - 1
                t_oItem = t_oItemList.Item(i)
                t_sItem = GetItemText(t_oItem)
                t_oResult.Add(t_sItem)
            Next i

            t_oItemList.Clear()
        End If

        If (m_nMagicMajor > 0) Then
            t_oResult.Add("")
            t_oResult.Add("------ Major Magic Items: " & m_nMagicMajor & " ------")

            ' Get Items
            For i = 0 To m_nMagicMajor - 1
                't_sItem = ""
                Do
                    t_oItem = Me.PickAnItem(CAT_MAJOR)
                    't_sItem = GetItemText(Me.PickAnItem(CAT_MINOR))
                    'Threading.Thread.Sleep(4)
                Loop While t_oItem.m_sItem = ""

                t_oItemList.Add(t_oItem)
                't_oResult.Add(t_sItem)
            Next i

            ' Sort them
            Me.SortItems(t_oItemList)

            ' Add them to the view
            For i = 0 To t_oItemList.Count - 1
                t_oItem = t_oItemList.Item(i)
                t_sItem = GetItemText(t_oItem)
                t_oResult.Add(t_sItem)
            Next i

            t_oItemList.Clear()
        End If

        Return t_oResult
    End Function

    Private Function RollBlackMarket() As ArrayList
        Dim t_oResult As New ArrayList
        Dim i As Integer = 0
        Dim t_sItem As String = ""

        Dim t_oItemList As New ArrayList
        Dim t_oItem As STRUCTURE_ELEMENT

        Me.RollBlackMarketQty()

        If (m_nMagicMinor > 0) Then
            t_oResult.Add("Black Market's Treasure (" & cmbBlackMarket.Text & ")")
            t_oResult.Add("")
            t_oResult.Add("------ Minor Magic Items: " & m_nMagicMinor & " ------")

            ' Get Items
            For i = 0 To m_nMagicMinor - 1
                Do
                    t_oItem = Me.PickAnItem(CAT_MINOR)
                Loop While t_oItem.m_sItem = ""

                t_oItemList.Add(t_oItem)
            Next i

            ' Sort them
            Me.SortItems(t_oItemList)

            ' Add them to the view
            For i = 0 To t_oItemList.Count - 1
                t_oItem = t_oItemList.Item(i)
                t_sItem = GetItemText(t_oItem)
                t_oResult.Add(t_sItem)
            Next i

            t_oItemList.Clear()
        End If

        If (m_nMagicMedium > 0) Then
            t_oResult.Add("")
            t_oResult.Add("------ Medium Magic Items: " & m_nMagicMedium & " ------")

            ' Get Items
            For i = 0 To m_nMagicMedium - 1
                Do
                    t_oItem = Me.PickAnItem(CAT_MEDIUM)
                Loop While t_oItem.m_sItem = ""

                t_oItemList.Add(t_oItem)
            Next i

            ' Sort them
            Me.SortItems(t_oItemList)

            ' Add them to the view
            For i = 0 To t_oItemList.Count - 1
                t_oItem = t_oItemList.Item(i)
                t_sItem = GetItemText(t_oItem)
                t_oResult.Add(t_sItem)
            Next i

            t_oItemList.Clear()
        End If

        If (m_nMagicMajor > 0) Then
            t_oResult.Add("")
            t_oResult.Add("------ Major Magic Items: " & m_nMagicMajor & " ------")

            ' Get Items
            For i = 0 To m_nMagicMajor - 1
                Do
                    t_oItem = Me.PickAnItem(CAT_MAJOR)
                Loop While t_oItem.m_sItem = ""

                t_oItemList.Add(t_oItem)
            Next i

            ' Sort them
            Me.SortItems(t_oItemList)

            ' Add them to the view
            For i = 0 To t_oItemList.Count - 1
                t_oItem = t_oItemList.Item(i)
                t_sItem = GetItemText(t_oItem)
                t_oResult.Add(t_sItem)
            Next i

            t_oItemList.Clear()
        End If

        Return t_oResult
    End Function

    Private Sub SortItems(ByRef a_oItemList As ArrayList)
        Dim t_oItem As STRUCTURE_ELEMENT
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim t_oTempList As New ArrayList
        Dim t_sCoinsType(4) As String
        t_sCoinsType(0) = "pp"
        t_sCoinsType(1) = "gp"
        t_sCoinsType(2) = "sp"
        t_sCoinsType(3) = "cp"

        Dim t_oCoins As STRUCTURE_ELEMENT

        For j = TYPE_MIN To TYPE_MAX - 1
            If (j = TYPE_COINS) Then ' For coins match together all duplicate coins in one, and remove the excess...
                For k = 0 To t_sCoinsType.Count - 1
                    t_oCoins = New STRUCTURE_ELEMENT
                    t_oCoins.m_nType = TYPE_COINS
                    t_oCoins.m_sCoin = t_sCoinsType(k)
                    t_oCoins.m_nPrice1 = 0

                    For i = 0 To a_oItemList.Count - 1
                        t_oItem = a_oItemList.Item(i)

                        If ((t_oItem.m_nType = j) And (t_oItem.m_sCoin = t_sCoinsType(k))) Then
                            t_oCoins.m_nPrice1 = t_oCoins.m_nPrice1 + t_oItem.m_nPrice1
                        End If
                    Next i

                    If (t_oCoins.m_nPrice1 > 0) Then
                        t_oTempList.Add(t_oCoins)
                    End If
                Next k
            Else
                For i = 0 To a_oItemList.Count - 1
                    t_oItem = a_oItemList.Item(i)

                    If (t_oItem.m_nType = j) Then
                        t_oTempList.Add(t_oItem)
                    End If
                Next i
            End If
        Next j

        a_oItemList = t_oTempList
    End Sub

    Private Function GetItemText(ByRef a_oItem As STRUCTURE_ELEMENT) As String
        If (a_oItem.m_sItem = "") Then
            Return ""
        End If

        Dim t_sText As String = ""
        Dim t_nPrice As Integer

        If (a_oItem.m_nPrice1 > 0) Then
            t_nPrice = a_oItem.m_nPrice1
        ElseIf (a_oItem.m_nPrice2 > 0) Then
            t_nPrice = a_oItem.m_nPrice2
        ElseIf (a_oItem.m_nPrice3 > 0) Then
            t_nPrice = a_oItem.m_nPrice3
        End If

        a_oItem.m_nPrice1 = t_nPrice
        a_oItem.m_sItem = a_oItem.m_sItem.Replace("<ROLL AGAIN>", "")

        t_sText = a_oItem.m_sItem & ", " & FormatNumber(t_nPrice, 0, , TriState.True) & " " & a_oItem.m_sCoin

        Return t_sText
    End Function

    Private Function PickAnItem(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = Nothing

        If (a_nCategory = -1) Then
            Return Nothing
        End If

        Dim t_bOnlyOneCategory As Boolean
        Dim a_oTableArray As ArrayList = Me.GetTableByName(TABLE_5_2_RANDOM_ITEMS, t_bOnlyOneCategory)
        If (a_oTableArray Is Nothing) Then
            Return Nothing
        End If

        Dim t_nMaximum As Integer
        Dim t_nCurPos As Integer = -1
        Dim t_nRand As Integer
        Dim i As Integer

        t_nMaximum = Me.GetMaximumValidRoll(a_oTableArray, a_nCategory)

        ' /////////////
        Dim t_sCategory As String = ""
        Select Case a_nCategory
            Case CAT_MINOR
                t_sCategory = "Minor"
            Case CAT_MEDIUM
                t_sCategory = "Medium"
            Case CAT_MAJOR
                t_sCategory = "Major"
            Case CAT_MUNDANE_MINOR
                t_sCategory = "Mundane Minor"
            Case CAT_MUNDANE_MEDIUM
                t_sCategory = "Mundane Medium"
        End Select

        Me.LogData("Rolling " & t_sCategory & " Items at Table " & TABLE_5_2_RANDOM_ITEMS)
        Me.LogData("The maximum roll can be: <" & t_nMaximum & ">")

        ' Coins Table
        'Dim t_bCoins As Boolean = False

        ' Set the minal rand value, if it is required only magic item, set a minimal
        Dim t_nMinimalRand As Integer = 1
        If (m_bOnlyMagic = True) Then
            If (a_nCategory = CAT_MINOR) Then
                t_nMinimalRand = m_nMinorMagic
            ElseIf (a_nCategory = CAT_MEDIUM) Then
                t_nMinimalRand = m_nMediumMagic
            ElseIf (a_nCategory = CAT_MAJOR) Then
                t_nMinimalRand = m_nMajorMagic
            End If
        End If

        ' Allow only the minimal
        t_nRand = Me.GetRandom(t_nMaximum + 1, t_nMinimalRand)

        ' /////////////
        Me.LogData("Roled a <" & t_nRand & ">")
        ' /////////////

        For i = 0 To a_oTableArray.Count - 1
            t_oItem = a_oTableArray.Item(i)

            If ((a_nCategory = CAT_MINOR) Or (a_nCategory = CAT_MUNDANE_MINOR)) Then
                t_nCurPos = t_oItem.m_nMinor
            ElseIf ((a_nCategory = CAT_MEDIUM) Or (a_nCategory = CAT_MUNDANE_MEDIUM)) Then
                t_nCurPos = t_oItem.m_nMedium
            ElseIf (a_nCategory = CAT_MAJOR) Then
                t_nCurPos = t_oItem.m_nMajor
            End If

            If (t_nRand <= t_nCurPos) Then
                Dim t_sTableSel As String = "[" & t_oItem.m_sTableLink & "]"

                Select Case t_sTableSel
                    Case TABLE_6_9_GOODS_SERVICES_1, TABLE_6_9_GOODS_SERVICES_2, TABLE_6_9_GOODS_SERVICES_3, TABLE_6_9_GOODS_SERVICES_4 ' Mundanes Items
                        Return Me.PickMundaneItem(t_sTableSel)
                    Case TABLE_5_4_ARMOR_SHIELDS ' Armor and Shields
                        Return Me.PickArmorAndShields()
                    Case TABLE_5_19_POTIONS ' Potions
                        Return Me.PickPotion(a_nCategory)
                    Case TABLE_5_24_SCROLLS ' Scrolls
                        Return Me.PickScroll(a_nCategory)
                    Case TABLE_5_4_ARMOR_SHIELDS_MAGICAL ' Magical Armor and Shields
                        Return Me.PickArmorAndShieldsMagical(a_nCategory)
                    Case TABLE_15_13_RINGS ' Rings
                        Return Me.PickRing(a_nCategory)
                    Case TABLE_15_14_RODS ' Rods
                        Return Me.PickRod(a_nCategory)
                    Case TABLE_15_16_STAVES ' Staves
                        Return Me.PickStaff(a_nCategory)
                    Case TABLE_15_18_MINOR_WONDROUS_ITEMS, TABLE_15_19_MEDIUM_WONDROUS_ITEMS, TABLE_15_20_MAJOR_WONDROUS_ITEMS ' Wondrous items
                        Return Me.PickWondrousItem(t_sTableSel)
                    Case TABLE_5_47_WANDS ' Wands
                        Return Me.PickWand(a_nCategory)
                    Case TABLE_5_11_WEAPONS ' Weapon
                        Return Me.PickWeapon()
                    Case TABLE_5_11_WEAPONS_MAGICAL ' Magical Weapon
                        Return Me.PickWeaponMagical(a_nCategory)
                End Select
            End If
        Next i

        Return t_oItem
    End Function

    Private Function PickCoins(ByVal a_nLevel As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = Nothing '= PickAnItemFromTable(TABLE_COINS, , a_nLevel)
        'Dim t_nCoins As Integer
        't_oItem.m_nType = TYPE_COINS

        'If (t_oItem.m_sItem <> "") Then
        '    t_nCoins = Me.RollDices(t_oItem.m_sItem) * t_oItem.m_nPrice1
        '    t_oItem.m_sItem = "Coins"
        '    t_oItem.m_nPrice1 = t_nCoins
        'End If

        Return t_oItem
    End Function

    Private Function PickGoods(ByVal a_nLevel As Integer) As ArrayList
        Dim t_oGoods As New ArrayList
        'Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_GOODS, , a_nLevel)
        'Dim t_nQty As Integer = 0
        'Dim i As Integer

        'If (t_oItem.m_sItem <> "") Then
        '    If ((t_oItem.m_nPrice1 <= 0) Or (t_oItem.m_nPrice2 < 0)) Then
        '        Return t_oGoods
        '    End If

        '    If (t_oItem.m_nPrice2 > t_oItem.m_nPrice1) Then
        '        t_nQty = GetRandom(t_oItem.m_nPrice2 + 1, t_oItem.m_nPrice1)
        '    Else
        '        t_nQty = t_oItem.m_nPrice1
        '    End If
        'End If

        'Dim t_oObj As STRUCTURE_ELEMENT
        'If ("[" & t_oItem.m_sItem & "]" = TABLE_GEMS) Then
        '    For i = 0 To t_nQty
        '        t_oObj = PickGem()
        '        If (t_oObj.m_sItem <> "") Then
        '            t_oGoods.Add(t_oObj)
        '        End If
        '    Next i
        'ElseIf ("[" & t_oItem.m_sItem & "]" = TABLE_ART_OBJECTS) Then
        '    For i = 0 To t_nQty
        '        t_oObj = PickArtObject()
        '        If (t_oObj.m_sItem <> "") Then
        '            t_oGoods.Add(t_oObj)
        '        End If
        '    Next i
        'End If

        Return t_oGoods
    End Function

    Private Function PickGem(ByVal a_nGrade As Integer) As STRUCTURE_ELEMENT
        Dim t_sTable As String = ""

        Select Case a_nGrade
            Case 1
                t_sTable = TABLE_GEM_1
            Case 2
                t_sTable = TABLE_GEM_2
            Case 3
                t_sTable = TABLE_GEM_3
            Case 4
                t_sTable = TABLE_GEM_4
            Case 5
                t_sTable = TABLE_GEM_5
            Case 6
                t_sTable = TABLE_GEM_6
        End Select

        If (t_sTable = "") Then
            Return Nothing
        End If

        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(t_sTable)
        Dim t_nValue As Integer

        ' Compute gem price
        t_nValue = t_oItem.m_nPrice1 + (Me.RollDices(t_oItem.m_sCoin) * t_oItem.m_nPrice2)
        t_oItem.m_sCoin = "gp"
        t_oItem.m_nPrice1 = t_nValue
        t_oItem.m_nPrice2 = 0
        t_oItem.m_sItem = "gemstone (" & t_oItem.m_sItem & ")"
        t_oItem.m_nType = TYPE_GEM

        Return t_oItem
    End Function

    Private Function PickArtObject(ByVal a_nGrade As Integer) As STRUCTURE_ELEMENT
        Dim t_sTable As String = ""

        Select Case a_nGrade
            Case 1
                t_sTable = TABLE_ART_1
            Case 2
                t_sTable = TABLE_ART_2
            Case 3
                t_sTable = TABLE_ART_3
            Case 4
                t_sTable = TABLE_ART_4
            Case 5
                t_sTable = TABLE_ART_5
            Case 6
                t_sTable = TABLE_ART_6
        End Select

        If (t_sTable = "") Then
            Return Nothing
        End If

        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(t_sTable)

        t_oItem.m_nType = TYPE_ART

        Return t_oItem
    End Function

    Private Function PickMundaneItem(ByVal a_sTable As String) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(a_sTable)
        t_oItem.m_nType = TYPE_MUNDANE

        Return t_oItem
    End Function

    Private Function PickWondrousItem(ByVal a_sTable As String) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(a_sTable)
        t_oItem.m_nType = TYPE_WONDROUS

        Return t_oItem
    End Function

    Private Function PickRing(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_15_13_RINGS, a_nCategory)

        t_oItem.m_sItem = "ring of " & t_oItem.m_sItem
        t_oItem.m_nType = TYPE_RING


        Return t_oItem
    End Function

    Private Function PickStaff(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_15_16_STAVES, a_nCategory)

        t_oItem.m_sItem = "staff of " & t_oItem.m_sItem
        t_oItem.m_nType = TYPE_STAFF

        Return t_oItem
    End Function

    ' Armor Type
    Private ARMOR_TYPE_NO_SELECTION As Integer = -1
    Private ARMOR_TYPE_SHIELD As Integer = 0
    Private ARMOR_TYPE_LIGHT As Integer = 1
    Private ARMOR_TYPE_MEDIUM As Integer = 2
    Private ARMOR_TYPE_HEAVY As Integer = 3
    Private ARMOR_TYPE_LIGHT_OR_SHIELD As Integer = 4

    Private Function PickArmorAndShields(Optional ByVal a_bMagical As Boolean = False, Optional ByVal a_nType As Integer = -1) As STRUCTURE_ELEMENT
        Dim t_sTable As String

        ' Is it magical Armor or not?
        If (a_bMagical = True) Then
            t_sTable = TABLE_5_4_ARMOR_SHIELDS_MAGICAL
        Else
            t_sTable = TABLE_5_4_ARMOR_SHIELDS
        End If

        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(t_sTable)

        ' Getting treasure type
        Select Case "[" & t_oItem.m_sTableLink & "]"
            Case TABLE_5_3_ARMOR
                t_oItem.m_nType = TYPE_ARMOR
            Case TABLE_5_3_ARMOR_MAGICAL
                t_oItem.m_nType = TYPE_ARMOR_MAGIC
            Case TABLE_5_5_SHIELDS
                t_oItem.m_nType = TYPE_SHIELD
            Case TABLE_5_5_SHIELDS_MAGICAL
                t_oItem.m_nType = TYPE_SHIELD_MAGIC
        End Select

        ' Taking shield or armor
        Dim t_oAddon As STRUCTURE_ELEMENT = Nothing
        Dim t_oMaterial As STRUCTURE_ELEMENT = Nothing
        Dim t_oArmor As STRUCTURE_ELEMENT = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]")

        ' There are some addons to the armor and it should roll again to take the armor that support those addons
        ' Getting the Addon if there is any
        If (t_oArmor.m_sItem.IndexOf("<ROLL AGAIN>") > -1) Then
            t_oAddon = t_oArmor

            While (t_oArmor.m_sItem = t_oAddon.m_sItem)
                t_oArmor = PickAnItemFromTable("[" & t_oAddon.m_sTableLink & "]")
            End While

            ' It is possible to have at least two addons, need to support both
            If (t_oArmor.m_sItem.IndexOf("<ROLL AGAIN>") > -1) Then
                t_oArmor.m_sItem = t_oArmor.m_sItem.Replace("with ", " and ")
                t_oArmor.m_sItem = t_oArmor.m_sItem.Replace("<ROLL AGAIN>", "")
                t_oAddon.m_sItem = t_oAddon.m_sItem.Replace("<ROLL AGAIN>", t_oArmor.m_sItem)
                t_oAddon.m_nPrice1 = t_oAddon.m_nPrice1 + t_oArmor.m_nPrice1

                Do
                    t_oArmor = PickAnItemFromTable("[" & t_oAddon.m_sTableLink & "]")
                Loop While (t_oArmor.m_sItem.IndexOf("<ROLL AGAIN>") = -1)
            Else
                t_oArmor.m_sItem = t_oArmor.m_sItem.Replace("<ROLL AGAIN>", "")
            End If
        End If

        Dim t_nPrice As Integer = 0
        Dim t_nCategory As Integer
        If (t_oArmor.m_nPrice1 > 0) Then ' Only shields and light armor have m_nPrice1 > 0
            t_nPrice = t_oArmor.m_nPrice1
            If ((t_oItem.m_nType = TYPE_SHIELD) Or (t_oItem.m_nType = TYPE_SHIELD_MAGIC)) Then
                t_nCategory = ARMOR_TYPE_SHIELD
            Else
                t_nCategory = ARMOR_TYPE_LIGHT
            End If
        ElseIf (t_oArmor.m_nPrice2 > 0) Then ' Only medium armor have m_nPrice2 > 0
            t_nPrice = t_oArmor.m_nPrice2
            t_nCategory = ARMOR_TYPE_MEDIUM
        ElseIf (t_oArmor.m_nPrice3 > 0) Then ' Only heavy armor have m_nPrice3 > 0
            t_nPrice = t_oArmor.m_nPrice3
            t_nCategory = ARMOR_TYPE_HEAVY
        Else
            t_nPrice = 0
            t_nCategory = ARMOR_TYPE_NO_SELECTION
        End If

        ' Reroll if the armor type is required and doesn't match the current one!
        If ((a_bMagical = False) And (a_nType <> ARMOR_TYPE_NO_SELECTION)) Then
            If (a_nType = ARMOR_TYPE_LIGHT_OR_SHIELD) Then
                If ((t_nCategory <> ARMOR_TYPE_LIGHT) And (t_nCategory <> ARMOR_TYPE_SHIELD)) Then
                    Return Me.PickArmorAndShields(a_bMagical, a_nType)
                End If
            ElseIf (a_nType <> t_nCategory) Then
                Return Me.PickArmorAndShields(a_bMagical, a_nType)
            End If
        End If

        't_oArmor.m_nPrice1 = t_nPrice
        ' Getting the material if there is any
        If ((t_oArmor.m_sTableLink <> "") And (TABLE_5_8_MAGIC_ARMOR.IndexOf(t_oArmor.m_sTableLink) = -1) And (TABLE_5_8_MAGIC_SHIELDS.IndexOf(t_oArmor.m_sTableLink) = -1)) Then
            t_oMaterial = PickAnItemFromTable("[" & t_oArmor.m_sTableLink & "]")
        End If

        ' Adding Material and Addons names, if there is any.
        If ((t_oMaterial.m_sItem <> "") And (t_oMaterial.m_sItem <> "normal")) Then
            t_oArmor.m_sItem = t_oMaterial.m_sItem & " " & t_oArmor.m_sItem

            If (t_oMaterial.m_nPrice1 = -2) Then ' dragonhide have price x2
                t_nPrice = t_nPrice * 2
            ElseIf (t_oMaterial.m_nPrice1 = -3) Then ' darkwood have price equal to pounds x 10 (pounds in this case is m_nPrice2 x -1)
                t_nPrice = t_oArmor.m_nPrice2 * t_oMaterial.m_nPrice2
            Else
                Select Case t_nCategory
                    Case ARMOR_TYPE_LIGHT, ARMOR_TYPE_SHIELD ' Light armor or shield
                        t_nPrice = t_nPrice + t_oMaterial.m_nPrice1
                    Case ARMOR_TYPE_MEDIUM ' Medium armor
                        t_nPrice = t_nPrice + t_oMaterial.m_nPrice2
                    Case ARMOR_TYPE_HEAVY ' Heavy armor
                        t_nPrice = t_nPrice + t_oMaterial.m_nPrice3
                    Case Else ' Error
                        t_nPrice = 0
                End Select
            End If
        End If

        t_oArmor.m_nPrice1 = t_nPrice
        t_oArmor.m_nPrice2 = 0
        t_oArmor.m_nPrice3 = 0

        If (t_oAddon.m_sItem <> "") Then
            t_oArmor.m_sItem = t_oArmor.m_sItem & " " & t_oAddon.m_sItem
            t_oArmor.m_nPrice1 = t_oArmor.m_nPrice1 + t_oAddon.m_nPrice1
        End If

        ' For magical armor
        If (a_bMagical = True) Then
            If (TABLE_5_8_MAGIC_ARMOR.IndexOf(t_oArmor.m_sTableLink) = -1) And (TABLE_5_8_MAGIC_SHIELDS.IndexOf(t_oArmor.m_sTableLink) = -1) Then
                t_oArmor.m_sTableLink = t_oMaterial.m_sTableLink
            End If
        End If

        ' Set treasure type, this data was set in the begin of this function
        t_oArmor.m_nType = t_oItem.m_nType
        ' Now set item
        t_oItem = t_oArmor

        Return t_oItem
    End Function

    Private Function PickWeapon(Optional ByVal a_bMagical As Boolean = False) As STRUCTURE_ELEMENT
        Dim t_sTable As String

        If (a_bMagical = True) Then
            t_sTable = TABLE_5_11_WEAPONS_MAGICAL
        Else
            t_sTable = TABLE_5_11_WEAPONS
        End If

        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(t_sTable)


        ' Taking shield or armor
        Dim t_oMaterial As STRUCTURE_ELEMENT = Nothing
        Dim t_oWeapon As STRUCTURE_ELEMENT = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]")

        Dim t_nPrice As Integer = 0
        Dim t_nWeight As Integer = 0
        Dim t_nCategory As Integer = 0
        t_nPrice = t_oWeapon.m_nPrice1
        t_nWeight = t_oWeapon.m_nPrice2
        t_nCategory = t_oWeapon.m_nPrice3

        't_oArmor.m_nPrice1 = t_nPrice

        ' Getting the material if there is any
        If ((t_oWeapon.m_sTableLink <> "")) Then ' And (TABLE_5_8_MAGIC_ARMOR.IndexOf(t_oArmor.m_sTableLink) = -1) And (TABLE_5_8_MAGIC_SHIELDS.IndexOf(t_oArmor.m_sTableLink) = -1)) Then
            t_oMaterial = PickAnItemFromTable("[" & t_oWeapon.m_sTableLink & "]")
        End If

        ' Adding Material and Addons names, if there is any.
        If ((t_oMaterial.m_sItem <> "") And (t_oMaterial.m_sItem <> "normal")) Then
            't_oWeapon.m_sItem = t_oWeapon.m_sItem & " of " & t_oMaterial.m_sItem
            t_oWeapon.m_sItem = t_oMaterial.m_sItem & " " & t_oWeapon.m_sItem

            If (t_oMaterial.m_nPrice1 = -2) Then ' cold iron have price x2
                t_nPrice = t_nPrice * 2
            ElseIf (t_oMaterial.m_nPrice1 = -3) Then ' darkwood and mithral have price equal to pounds x Y (pounds in this case is m_nPrice2 x -1)
                t_nPrice = t_oWeapon.m_nPrice2 * t_oMaterial.m_nPrice2
            Else
                Select Case t_nCategory
                    Case -1, -6 ' Light weapon or Light throwing weapon
                        t_nPrice = t_nPrice + t_oMaterial.m_nPrice1
                    Case -2 ' One handed weapon
                        t_nPrice = t_nPrice + t_oMaterial.m_nPrice2
                    Case -3, -4 ' Two handed weapon or ranged weapon
                        t_nPrice = t_nPrice + t_oMaterial.m_nPrice3
                    Case -5 ' ammo
                        Dim t_nAmmoPrice As Integer
                        If (t_oMaterial.m_sCoin.IndexOf("Ammo") > -1) Then
                            Try
                                t_nAmmoPrice = Convert.ToInt32(t_oMaterial.m_sCoin.Replace("Ammo", ""))
                            Catch ex As Exception
                                t_nAmmoPrice = 0
                            End Try
                        Else
                            t_nAmmoPrice = 0
                        End If

                        t_nPrice = t_nPrice + t_nAmmoPrice

                    Case Else
                        t_nPrice = 0
                End Select
            End If
        End If

        t_oWeapon.m_nPrice1 = t_nPrice

        ' For magical armor
        If (a_bMagical = False) Then
            ' Removing weapon damage type flags
            t_oWeapon.m_sCoin = t_oWeapon.m_sCoin.Replace("-P", "")
            t_oWeapon.m_sCoin = t_oWeapon.m_sCoin.Replace("-S", "")
            t_oWeapon.m_sCoin = t_oWeapon.m_sCoin.Replace("-B", "")

            If (t_oWeapon.m_sItem.IndexOf("masterwork") = -1) Then
                t_oWeapon.m_sItem = "mwk " & t_oWeapon.m_sItem
            End If

            ' Define treasure type
            If ((t_nCategory = -4) Or (t_nCategory = -5)) Then ' Ranged weapon or ammuniton
                t_oWeapon.m_nType = TYPE_WEAPON_RANGED
            Else
                t_oWeapon.m_nType = TYPE_WEAPON_MELEE
            End If
        Else
            ' Define treasure type
            If ((t_nCategory = -4) Or (t_nCategory = -5)) Then ' Ranged weapon or ammuniton
                t_oWeapon.m_nType = TYPE_WEAPON_RANGED_MAGIC
            Else
                t_oWeapon.m_nType = TYPE_WEAPON_MELEE_MAGIC
            End If
        End If

        t_oItem = t_oWeapon

        Return t_oItem
    End Function

    Private Function PickWeaponMagical(ByVal a_nCategory As Integer, Optional ByVal t_oBaseItem As STRUCTURE_ELEMENT = Nothing) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT ' = Me.PickArmorAndShields(True)

        ' Skip this step if there is already a base item
        If (t_oBaseItem.m_sItem <> "") Then
            t_oItem = t_oBaseItem
        Else
            t_oItem = Me.PickWeapon(True)
        End If

        Dim t_oBonus As STRUCTURE_ELEMENT
        Dim t_oAux As STRUCTURE_ELEMENT

        Dim t_nBonusTotal As Integer = 0

        ' Getting the magic table by category
        Dim t_nCategory As Integer = t_oItem.m_nPrice3
        Dim t_sTableLink As String = ""

        Select Case t_nCategory
            Case -1, -2, -3
                t_sTableLink = TABLE_5_16_MAGIC_MELEE
            Case -4, -5
                t_sTableLink = TABLE_5_16_MAGIC_RANGED
            Case -6
                Dim t_nRand As Integer = GetRandom(100 + 1, 1)
                If (t_nRand <= 50) Then
                    t_sTableLink = TABLE_5_16_MAGIC_MELEE
                Else
                    t_sTableLink = TABLE_5_16_MAGIC_RANGED
                End If
        End Select

        ' Removing the [ and ] from the t_sTableLink
        t_sTableLink = t_sTableLink.Replace("[", "")
        t_sTableLink = t_sTableLink.Replace("]", "")
        t_oItem.m_sTableLink = t_sTableLink

        Do
            t_oBonus = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)
        Loop While (t_oBonus.m_sTableLink = "<ROLL AGAIN>")

        Select Case ("[" & t_oBonus.m_sTableLink & "]")
            Case TABLE_15_11_SPECIFIC_WEAPON
                t_oItem = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)
                ' Define treasure tyep
                If ((t_oItem.m_nPrice3 = -4) Or (t_oItem.m_nPrice3 = -5)) Then ' Ranged or ammunition
                    t_oItem.m_nType = TYPE_WEAPON_RANGED_MAGIC
                Else
                    t_oItem.m_nType = TYPE_WEAPON_MELEE_MAGIC
                End If

            Case TABLE_5_17_MELEE_MAGIC, TABLE_5_18_RANGED_MAGIC
                ' Getting the main bonus
                Do
                    t_oAux = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)
                Loop While (t_oAux.m_sTableLink <> "") ' Accept only +1, +2, +3, +4, or +5

                ' Converting it to integer
                Try
                    t_nBonusTotal = Convert.ToInt32(t_oAux.m_sItem.Replace("+", ""))
                Catch ex As Exception
                    t_nBonusTotal = 0
                End Try

                ' Getting the special ability(ies)
                Dim t_bRerun As Boolean = False
                Dim t_sTempTableLink As String = t_oBonus.m_sTableLink
                Do
                    t_oBonus = PickAnItemFromTable("[" & t_sTempTableLink & "]", a_nCategory)

                    ' Verify the exceptions
                    Select Case t_oBonus.m_nPrice2
                        Case -1 ' keen ability, works only for P and S weapon
                            If (t_oItem.m_sCoin.IndexOf("-S") = -1) And (t_oItem.m_sCoin.IndexOf("-P") = -1) Then
                                t_bRerun = True
                            Else
                                t_bRerun = False
                            End If
                        Case -2 ' disruption abilitym works only for B weapon
                            If (t_oItem.m_sCoin.IndexOf("-B") = -1) Then
                                t_bRerun = True
                            Else
                                t_bRerun = False
                            End If
                        Case -3 ' vorpal ability, works only for S weapon
                            If (t_oItem.m_sCoin.IndexOf("-S") = -1) Then
                                t_bRerun = True
                            Else
                                t_bRerun = False
                            End If
                        Case Else
                            t_bRerun = False
                    End Select
                Loop While (t_bRerun = True)


                If (t_oBonus.m_sItem = "<ROLL AGAIN TWICE>") Then ' it has two special abilities
                    Dim t_oBonus2 As STRUCTURE_ELEMENT
                    Dim t_nBonusAux As Integer = 0
                    Dim t_nBonus2Aux As Integer = 0

                    ' Getting twice the special abilities
                    Do
                        t_oBonus2 = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)

                        ' Verify the exceptions
                        Select Case t_oBonus2.m_nPrice2
                            Case -1 ' keen ability, works only for P and S weapon
                                If (t_oItem.m_sCoin.IndexOf("-S") = -1) And (t_oItem.m_sCoin.IndexOf("-P") = -1) Then
                                    t_bRerun = True
                                Else
                                    t_bRerun = False
                                End If
                            Case -2 ' disruption abilitym works only for B weapon
                                If (t_oItem.m_sCoin.IndexOf("-B") = -1) Then
                                    t_bRerun = True
                                Else
                                    t_bRerun = False
                                End If
                            Case -3 ' vorpal ability, works only for S weapon
                                If (t_oItem.m_sCoin.IndexOf("-S") = -1) Then
                                    t_bRerun = True
                                Else
                                    t_bRerun = False
                                End If
                            Case Else
                                t_bRerun = False
                        End Select
                    Loop While ((t_oBonus2.m_sItem = "<ROLL AGAIN TWICE>") Or (t_bRerun = True))

                    Dim t_sTableLinkBak As String = t_oBonus.m_sTableLink
                    Do
                        't_oBonus = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)
                        t_oBonus = PickAnItemFromTable("[" & t_sTableLinkBak & "]", a_nCategory)
                        ' Verify the exceptions
                        Select Case t_oBonus.m_nPrice2
                            Case -1 ' keen ability, works only for P and S weapon
                                If (t_oItem.m_sCoin.IndexOf("-S") = -1) And (t_oItem.m_sCoin.IndexOf("-P") = -1) Then
                                    't_oBonus.m_sTableLink = t_sTableLinkBak
                                    t_bRerun = True
                                Else
                                    t_bRerun = False
                                End If
                            Case -2 ' disruption abilitym works only for B weapon
                                If (t_oItem.m_sCoin.IndexOf("-B") = -1) Then
                                    't_oBonus.m_sTableLink = t_sTableLinkBak
                                    t_bRerun = True
                                Else
                                    t_bRerun = False
                                End If
                            Case -3 ' vorpal ability, works only for S weapon
                                If (t_oItem.m_sCoin.IndexOf("-S") = -1) Then
                                    't_oBonus.m_sTableLink = t_sTableLinkBak
                                    t_bRerun = True
                                Else
                                    t_bRerun = False
                                End If
                            Case Else
                                t_bRerun = False
                        End Select
                    Loop While ((t_oBonus.m_sItem = "<ROLL AGAIN TWICE>") Or (t_oBonus.m_sItem = t_oBonus2.m_sItem) Or (t_bRerun = True))

                    ' Setting the bonus name
                    t_oBonus.m_sItem = t_oBonus.m_sItem & " and " & t_oBonus2.m_sItem
                    ' Computing the bonus
                    t_oBonus.m_nPrice1 = t_oBonus2.m_nPrice1
                    If (t_oBonus.m_sCoin.IndexOf("+") = 0) Then
                        Try
                            t_nBonusAux = Convert.ToInt32(t_oBonus.m_sCoin.Replace("+", ""))
                        Catch ex As Exception
                            t_nBonusAux = 0
                        End Try
                    End If

                    If (t_oBonus2.m_sCoin.IndexOf("+") = 0) Then
                        Try
                            t_nBonus2Aux = Convert.ToInt32(t_oBonus2.m_sCoin.Replace("+", ""))
                        Catch ex As Exception
                            t_nBonus2Aux = 0
                        End Try
                    End If

                    t_nBonusTotal = t_nBonusTotal + t_nBonusAux + t_nBonus2Aux
                Else ' only one special ability
                    ' Computing the bonus
                    Dim t_nBonusAux As Integer = 0

                    If (t_oBonus.m_sCoin.IndexOf("+") = 0) Then
                        Try
                            t_nBonusAux = Convert.ToInt32(t_oBonus.m_sCoin.Replace("+", ""))
                        Catch ex As Exception
                            t_nBonusAux = 0
                        End Try
                    End If

                    t_nBonusTotal = t_nBonusTotal + t_nBonusAux
                End If

                ' Try again if the t_bBonusTotal get bigger than 10
                If (t_nBonusTotal > 10) Then
                    t_oItem = Me.PickWeaponMagical(a_nCategory, t_oItem)
                    Return t_oItem
                End If

                ' Bulding item name
                t_oItem.m_sItem = t_oAux.m_sItem & " " & t_oItem.m_sItem & " of " & t_oBonus.m_sItem
                ' Computing item price
                t_oItem.m_nPrice1 = t_oItem.m_nPrice1 + t_oBonus.m_nPrice1 + Me.GetValueFromTableByBonus("[" & t_oItem.m_sTableLink & "]", "+" & t_nBonusTotal)
            Case Else
                ' Bulding item name
                t_oItem.m_sItem = t_oBonus.m_sItem & " " & t_oItem.m_sItem
                ' Computing item price
                t_oItem.m_nPrice1 = t_oItem.m_nPrice1 + t_oBonus.m_nPrice1
        End Select

        t_oItem.m_sItem = t_oItem.m_sItem.Replace("mwk ", "")
        ' Removing weapon damage type flags
        t_oItem.m_sCoin = t_oItem.m_sCoin.Replace("-P", "")
        t_oItem.m_sCoin = t_oItem.m_sCoin.Replace("-S", "")
        t_oItem.m_sCoin = t_oItem.m_sCoin.Replace("-B", "")

        Return t_oItem
    End Function


    'ByVal a_nCategory As Integer
    Private Function PickPotion(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_5_19_POTIONS, a_nCategory)

        ' Get the Potion spell depending on t_oItem level
        Dim t_oPotion As STRUCTURE_ELEMENT = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)

        t_oItem.m_sItem = t_oItem.m_sItem.Replace("{0}", t_oPotion.m_sItem)
        t_oItem.m_nPrice1 = t_oPotion.m_nPrice1
        t_oItem.m_sCoin = t_oPotion.m_sCoin
        t_oItem.m_nType = TYPE_POTION

        Return t_oItem
    End Function

    Private Function PickRod(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_15_14_RODS, a_nCategory)

        ' Get the Potion spell depending on t_oItem level
        t_oItem.m_sItem = "rod of " & t_oItem.m_sItem
        t_oItem.m_nType = TYPE_ROD

        Return t_oItem
    End Function

    Private Function PickScroll(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_5_24_SCROLLS, a_nCategory)

        ' Get the scroll type (arcane or divine)
        Dim t_oScroll As STRUCTURE_ELEMENT = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)
        Dim t_oSpellLevel As STRUCTURE_ELEMENT
        Dim t_oSpell As STRUCTURE_ELEMENT

        ' Define scroll type
        If (t_oScroll.m_sItem.IndexOf("arcane") > -1) Then ' Arcane
            t_oScroll.m_nType = TYPE_SCROLL_ARCANE
        Else ' divine
            t_oScroll.m_nType = TYPE_SCROLL_DIVINE
        End If

        ' Now get the number of spells
        Dim t_nSpells As Integer
        Dim i As Integer
        't_oScroll = PickAnItemFromTable("[" & t_oScroll.m_sTableLink & "]", t_bFinal, a_nCategory)
        t_nSpells = t_oScroll.m_nPrice2

        If (t_nSpells > 0) Then
            For i = 0 To t_nSpells - 1
                t_oSpellLevel = PickAnItemFromTable("[" & t_oScroll.m_sTableLink & "]", a_nCategory)
                t_oSpell = PickAnItemFromTable("[" & t_oSpellLevel.m_sTableLink & "]", a_nCategory)

                t_oSpellLevel.m_sItem = t_oSpellLevel.m_sItem.Replace("{0}", t_oSpell.m_sItem)
                t_oSpellLevel.m_nPrice1 = t_oSpell.m_nPrice1
                t_oSpellLevel.m_sCoin = t_oSpell.m_sCoin

                t_oScroll.m_sItem = t_oScroll.m_sItem.Replace("{" & i + 1 & "}", t_oSpellLevel.m_sItem)
                t_oScroll.m_nPrice1 = t_oScroll.m_nPrice1 + t_oSpellLevel.m_nPrice1
                t_oScroll.m_sCoin = t_oSpellLevel.m_sCoin
            Next i
        End If

        t_oItem = t_oScroll

        Return t_oItem
    End Function

    Private Function PickArmorAndShieldsMagical(ByVal a_nCategory As Integer, Optional ByVal t_oBaseItem As STRUCTURE_ELEMENT = Nothing) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT ' = Me.PickArmorAndShields(True)

        ' Skip this step if there is already a base item
        If (t_oBaseItem.m_sItem <> "") Then
            t_oItem = t_oBaseItem
        Else
            t_oItem = Me.PickArmorAndShields(True)
        End If

        Dim t_oBonus As STRUCTURE_ELEMENT
        Dim t_oAux As STRUCTURE_ELEMENT

        Dim t_nBonusTotal As Integer = 0

        Do
            t_oBonus = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)
        Loop While (t_oBonus.m_sTableLink = "<ROLL AGAIN>")

        Select Case ("[" & t_oBonus.m_sTableLink & "]")
            Case TABLE_15_6_SPECIFIC_ARMORS, TABLE_15_7_SPECIFIC_SHIELDS
                t_oItem = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)
                ' Define the treasure type for specific item
                If ("[" & t_oBonus.m_sTableLink & "]" = TABLE_15_6_SPECIFIC_ARMORS) Then ' Armor
                    t_oItem.m_nType = TYPE_ARMOR_MAGIC
                Else ' Shield
                    t_oItem.m_nType = TYPE_SHIELD_MAGIC
                End If
            Case TABLE_5_9_MAGIC_ARMOR_SPECIAL, TABLE_5_10_MAGIC_SHIELD_SPECIAL
                ' Getting the main bonus
                Do
                    t_oAux = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)
                Loop While (t_oAux.m_sTableLink <> "") ' Accept only +1, +2, +3, +4, or +5

                ' Converting it to integer
                Try
                    t_nBonusTotal = Convert.ToInt32(t_oAux.m_sItem.Replace("+", ""))
                Catch ex As Exception
                    t_nBonusTotal = 0
                End Try

                ' Getting the special ability(ies)
                t_oBonus = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)
                If (t_oBonus.m_sItem = "<ROLL AGAIN TWICE>") Then ' it has two special abilities
                    Dim t_oBonus2 As STRUCTURE_ELEMENT
                    Dim t_nBonusAux As Integer = 0
                    Dim t_nBonus2Aux As Integer = 0

                    ' Getting twice the special abilities
                    Do
                        t_oBonus2 = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)
                    Loop While (t_oBonus2.m_sItem = "<ROLL AGAIN TWICE>")

                    Do
                        t_oBonus = PickAnItemFromTable("[" & t_oBonus.m_sTableLink & "]", a_nCategory)
                    Loop While ((t_oBonus.m_sItem = "<ROLL AGAIN TWICE>") Or (t_oBonus.m_sItem = t_oBonus2.m_sItem))

                    ' Setting the bonus name
                    t_oBonus.m_sItem = t_oBonus.m_sItem & " and " & t_oBonus2.m_sItem
                    ' Computing the bonus
                    t_oBonus.m_nPrice1 = t_oBonus2.m_nPrice1
                    If (t_oBonus.m_sCoin.IndexOf("+") = 0) Then
                        Try
                            t_nBonusAux = Convert.ToInt32(t_oBonus.m_sCoin.Replace("+", ""))
                        Catch ex As Exception
                            t_nBonusAux = 0
                        End Try
                    End If

                    If (t_oBonus2.m_sCoin.IndexOf("+") = 0) Then
                        Try
                            t_nBonus2Aux = Convert.ToInt32(t_oBonus2.m_sCoin.Replace("+", ""))
                        Catch ex As Exception
                            t_nBonus2Aux = 0
                        End Try
                    End If

                    t_nBonusTotal = t_nBonusTotal + t_nBonusAux + t_nBonus2Aux
                Else ' only one special ability
                    ' Computing the bonus
                    Dim t_nBonusAux As Integer = 0

                    If (t_oBonus.m_sCoin.IndexOf("+") = 0) Then
                        Try
                            t_nBonusAux = Convert.ToInt32(t_oBonus.m_sCoin.Replace("+", ""))
                        Catch ex As Exception
                            t_nBonusAux = 0
                        End Try
                    End If

                    t_nBonusTotal = t_nBonusTotal + t_nBonusAux
                End If

                ' Try again if the t_bBonusTotal get bigger than 10
                If (t_nBonusTotal > 10) Then
                    t_oItem = Me.PickArmorAndShieldsMagical(a_nCategory, t_oItem)
                    Return t_oItem
                End If

                ' Bulding item name
                t_oItem.m_sItem = t_oAux.m_sItem & " " & t_oItem.m_sItem & " of " & t_oBonus.m_sItem
                ' Computing item price
                t_oItem.m_nPrice1 = t_oItem.m_nPrice1 + t_oBonus.m_nPrice1 + Me.GetValueFromTableByBonus("[" & t_oItem.m_sTableLink & "]", "+" & t_nBonusTotal)
            Case Else
                ' Bulding item name
                t_oItem.m_sItem = t_oBonus.m_sItem & " " & t_oItem.m_sItem
                ' Computing item price
                t_oItem.m_nPrice1 = t_oItem.m_nPrice1 + t_oBonus.m_nPrice1
        End Select

        t_oItem.m_sItem = t_oItem.m_sItem.Replace("mwk ", "")

        Return t_oItem
    End Function

    Private Function GetValueFromTableByBonus(ByVal a_sTable As String, ByVal a_sBonus As String) As Integer
        Dim t_nValue As Integer = 0
        Dim t_oItem As STRUCTURE_ELEMENT = Nothing
        Dim i As Integer

        Dim t_bOnlyOneCategory As Boolean
        Dim a_oTableArray As ArrayList = Me.GetTableByName(a_sTable, t_bOnlyOneCategory)

        For i = 0 To a_oTableArray.Count - 1
            t_oItem = a_oTableArray.Item(i)

            If (t_oItem.m_sItem = a_sBonus) Then
                t_nValue = t_oItem.m_nPrice1
                Exit For
            End If
        Next i

        Return t_nValue
    End Function

    Private Function PickAnItemFromTable(ByVal a_sTable As String, Optional ByVal a_nCategory As Integer = 0, Optional ByVal a_nLevel As Integer = -1) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = Nothing

        Dim t_bOnlyOneCategory As Boolean
        Dim t_oTableArray As ArrayList = Me.GetTableByName(a_sTable, t_bOnlyOneCategory, a_nLevel)
        If (t_oTableArray Is Nothing) Then
            Return Nothing
        End If

        Dim t_nMaximum As Integer
        Dim t_nCurPos As Integer = -1
        Dim t_nRand As Integer
        Dim i As Integer
        'Dim t_nNewCategory As Integer

        If (t_bOnlyOneCategory = True) Then
            a_nCategory = CAT_MINOR
        End If
        t_nMaximum = Me.GetMaximumValidRoll(t_oTableArray, a_nCategory)

        ' /////////////
        Dim t_sCategory As String = ""
        If (t_bOnlyOneCategory = False) Then
            If (a_nCategory = CAT_MINOR) Then
                t_sCategory = "Minor"
            ElseIf (a_nCategory = CAT_MEDIUM) Then
                t_sCategory = "Medium"
            ElseIf (a_nCategory = CAT_MAJOR) Then
                t_sCategory = "Major"
            End If
            Me.LogData("Rolling " & t_sCategory & " Items at Table " & a_sTable)
        Else
            Me.LogData("Rolling items at Table " & a_sTable)
        End If
        Me.LogData("The maximum roll can be: <" & t_nMaximum & ">")

        ' Allow only the minimal
        t_nRand = Me.GetRandom(t_nMaximum + 1, 1)

        ' /////////////
        Me.LogData("Rolled a <" & t_nRand & ">")

        For i = 0 To t_oTableArray.Count - 1
            t_oItem = t_oTableArray.Item(i)

            If (a_nCategory = CAT_MINOR) Then
                t_nCurPos = t_oItem.m_nMinor
            ElseIf (a_nCategory = CAT_MEDIUM) Then
                t_nCurPos = t_oItem.m_nMedium
            ElseIf (a_nCategory = CAT_MAJOR) Then
                t_nCurPos = t_oItem.m_nMajor
            End If

            If (t_nRand <= t_nCurPos) Then
                Exit For
            End If
        Next i

        Return t_oItem
    End Function

    Private Function PickWand(ByVal a_nCategory As Integer) As STRUCTURE_ELEMENT
        Dim t_oItem As STRUCTURE_ELEMENT = PickAnItemFromTable(TABLE_5_47_WANDS, a_nCategory)
        Dim t_nCharges As Integer

        ' Get the Wand spell depending on t_oItem level
        Dim t_oWand As STRUCTURE_ELEMENT = PickAnItemFromTable("[" & t_oItem.m_sTableLink & "]", a_nCategory)

        t_oItem.m_sItem = t_oItem.m_sItem.Replace("{0}", t_oWand.m_sItem)
        t_nCharges = GetRandom(50 + 1, 1)
        t_oItem.m_sItem = t_oItem.m_sItem.Replace("{1}", t_nCharges)
        If (t_nCharges = 1) Then
            t_oItem.m_sItem = t_oItem.m_sItem.Replace("charges", "charge")
        End If

        t_oItem.m_nPrice1 = t_oWand.m_nPrice1
        t_oItem.m_sCoin = t_oWand.m_sCoin
        t_oItem.m_nType = TYPE_WAND

        Return t_oItem
    End Function


    Private Function GetRandom(ByVal a_nMax As Integer, Optional ByVal a_nMin As Integer = 1) As Integer
        'Threading.Thread.Sleep(2)
        'Dim r As New Random(System.DateTime.Now.Millisecond)
        Dim t_Rand As Integer

        Try
            t_Rand = m_oRandom.Next(a_nMin, a_nMax)
        Catch ex As Exception
            t_Rand = -1
        End Try

        Return t_Rand
    End Function

    Private Sub LogData(ByVal a_sLine As String)
        If (m_bDebugMode = True) Then
            txtHistoric.Text = a_sLine & vbCrLf & txtHistoric.Text
        End If
    End Sub

    Private Sub cmbSettlement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSettlement.SelectedIndexChanged
        Select Case cmbSettlement.Text
            Case "Thorp"
                lblSet_PopRange.Text = "Fewer than 20"
                txtSetMinor.Text = "1d4"
                txtSetMedium.Text = "-"
                txtSetMajor.Text = "-"
                lbl_SetNote.Visible = False
            Case "Hamlet"
                lblSet_PopRange.Text = "21-60"
                txtSetMinor.Text = "1d6"
                txtSetMedium.Text = "-"
                txtSetMajor.Text = "-"
                lbl_SetNote.Visible = False
            Case "Village"
                lblSet_PopRange.Text = "61-200"
                txtSetMinor.Text = "2d4"
                txtSetMedium.Text = "1d4"
                txtSetMajor.Text = "-"
                lbl_SetNote.Visible = False
            Case "Small town"
                lblSet_PopRange.Text = "201-2,000"
                txtSetMinor.Text = "3d4"
                txtSetMedium.Text = "1d6"
                txtSetMajor.Text = "-"
                lbl_SetNote.Visible = False
            Case "Large town"
                lblSet_PopRange.Text = "2,001-5,000"
                txtSetMinor.Text = "3d4"
                txtSetMedium.Text = "2d4"
                txtSetMajor.Text = "1d4"
                lbl_SetNote.Visible = False
            Case "Small city"
                lblSet_PopRange.Text = "5,001-10,000"
                txtSetMinor.Text = "4d4"
                txtSetMedium.Text = "3d4"
                txtSetMajor.Text = "1d6"
                lbl_SetNote.Visible = False
            Case "Large city"
                lblSet_PopRange.Text = "10,001-25,000"
                txtSetMinor.Text = "4d4"
                txtSetMedium.Text = "3d4"
                txtSetMajor.Text = "2d4"
                lbl_SetNote.Visible = False
            Case "Metropolis"
                lblSet_PopRange.Text = "More than 25,000"
                txtSetMinor.Text = "*"
                txtSetMedium.Text = "4d4"
                txtSetMajor.Text = "3d4"
                lbl_SetNote.Visible = True
            Case Else
                lblSet_PopRange.Text = "0"
                txtSetMinor.Text = ""
                txtSetMedium.Text = ""
                txtSetMajor.Text = ""
                lbl_SetNote.Visible = False
        End Select

        Me.Invalidate_Roll_Button()
    End Sub

    Private Sub cmbBlackMarket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBlackMarket.SelectedIndexChanged
        Select Case cmbBlackMarket.Text
            Case "Hideout"
                lblSet_BMPopRange.Text = "Fewer than 30"
                txtSetBMMinor.Text = "3d4"
                txtSetBMMedium.Text = "1d6"
                txtSetBMMajor.Text = "-"
                lbl_SetBMNote.Visible = False
            Case "Den"
                lblSet_BMPopRange.Text = "31-120"
                txtSetBMMinor.Text = "3d4"
                txtSetBMMedium.Text = "2d4"
                txtSetBMMajor.Text = "1d4"
                lbl_SetBMNote.Visible = False
            Case "Hotbed"
                lblSet_BMPopRange.Text = "121-400"
                txtSetBMMinor.Text = "4d4"
                txtSetBMMedium.Text = "3d4"
                txtSetBMMajor.Text = "1d6"
                lbl_SetBMNote.Visible = False
            Case "Underbelly"
                lblSet_BMPopRange.Text = "401-1,200"
                txtSetBMMinor.Text = "4d4"
                txtSetBMMedium.Text = "3d4"
                txtSetBMMajor.Text = "2d4"
                lbl_SetBMNote.Visible = False
            Case "Underground"
                lblSet_BMPopRange.Text = "1,201-4,000"
                txtSetBMMinor.Text = "*"
                txtSetBMMedium.Text = "4d4"
                txtSetBMMajor.Text = "3d4"
                lbl_SetBMNote.Visible = True
            Case "Underworld"
                lblSet_BMPopRange.Text = "More than 4,000"
                txtSetBMMinor.Text = "*"
                txtSetBMMedium.Text = "*"
                txtSetBMMajor.Text = "4d4"
                lbl_SetBMNote.Visible = True
            Case Else
                lblSet_BMPopRange.Text = "0"
                txtSetBMMinor.Text = ""
                txtSetBMMedium.Text = ""
                txtSetBMMajor.Text = ""
                lbl_SetBMNote.Visible = False
        End Select

        Me.Invalidate_Roll_Button()
    End Sub

    Private Sub radSettlement_CheckedChanged(sender As Object, e As EventArgs) Handles radSettlement.CheckedChanged
        Me.SetTreasure()
    End Sub

    Private Sub radBlackMarket_CheckedChanged(sender As Object, e As EventArgs) Handles radBlackMarket.CheckedChanged
        Me.SetTreasure()
    End Sub

    Private Sub radNPC_CheckedChanged(sender As Object, e As EventArgs) Handles radNPC.CheckedChanged
        Me.SetTreasure()
    End Sub

    Private Sub radUnique_CheckedChanged(sender As Object, e As EventArgs) Handles radUnique.CheckedChanged
        Me.SetTreasure()
    End Sub

    Private Sub SetTreasure()
        If (radSettlement.Checked = True) Then
            m_nTreasureType = TREASURE_SETTLEMENT
            m_bOnlyMagic = True
            grpSettlement.Visible = True
            grpBlackMarket.Visible = False
            grpNPC.Visible = False
            m_sTreasureTypeCreature = ""
        ElseIf (radBlackMarket.Checked = True) Then
            m_nTreasureType = TREASURE_BLACK_MARKET
            m_bOnlyMagic = True
            grpSettlement.Visible = False
            grpBlackMarket.Visible = True
            grpNPC.Visible = False
            m_sTreasureTypeCreature = ""
        ElseIf (radNPC.Checked = True) Then
            m_nTreasureType = TREASURE_NPC
            m_bOnlyMagic = False
            grpSettlement.Visible = False
            grpBlackMarket.Visible = False
            grpNPC.Visible = True
        ElseIf (radUnique.Checked = True) Then
            m_nTreasureType = TREASURE_UNIQUE
            m_bOnlyMagic = False
            m_sTreasureTypeCreature = ""
        End If

        chk_TreasureA.Visible = radNPC.Checked
        chk_TreasureB.Visible = radNPC.Checked
        chk_TreasureC.Visible = radNPC.Checked
        chk_TreasureD.Visible = radNPC.Checked
        chk_TreasureE.Visible = radNPC.Checked
        chk_TreasureF.Visible = radNPC.Checked
        chk_TreasureG.Visible = radNPC.Checked
        chk_TreasureH.Visible = radNPC.Checked
        chk_TreasureI.Visible = radNPC.Checked

        Me.Invalidate_Roll_Button()
    End Sub

    Private Sub RollSettlementQty()
        m_nMagicMinor = RollDices(txtSetMinor.Text)
        m_nMagicMedium = RollDices(txtSetMedium.Text)
        m_nMagicMajor = RollDices(txtSetMajor.Text)
    End Sub

    Private Sub RollBlackMarketQty()
        m_nMagicMinor = RollDices(txtSetBMMinor.Text)
        m_nMagicMedium = RollDices(txtSetBMMedium.Text)
        m_nMagicMajor = RollDices(txtSetBMMajor.Text)
    End Sub


    Private Function RollDices(ByVal a_sDices As String) As Integer
        Dim t_nRand As Integer = 0

        Dim t_sDiceType As String = ""
        Dim t_nDices As Integer = 0
        Dim t_nMaxPerDice As Integer = 0
        Dim t_nMaxTotal As Integer = 0

        ' Take 16 items when haveing *
        If (a_sDices = "*") Then
            Return 16
        End If

        If (a_sDices.IndexOf("d3") > -1) Then
            t_sDiceType = "d3"
            t_nMaxPerDice = 3
        ElseIf (a_sDices.IndexOf("d4") > -1) Then
            t_sDiceType = "d4"
            t_nMaxPerDice = 4
        ElseIf (a_sDices.IndexOf("d6") > -1) Then
            t_sDiceType = "d6"
            t_nMaxPerDice = 6
        ElseIf (a_sDices.IndexOf("d8") > -1) Then
            t_sDiceType = "d8"
            t_nMaxPerDice = 8
        ElseIf (a_sDices.IndexOf("d10") > -1) Then
            t_sDiceType = "d10"
            t_nMaxPerDice = 10
        ElseIf (a_sDices.IndexOf("d12") > -1) Then
            t_sDiceType = "d12"
            t_nMaxPerDice = 12
        ElseIf (a_sDices.IndexOf("d20") > -1) Then
            t_sDiceType = "d20"
            t_nMaxPerDice = 20
        ElseIf (a_sDices.IndexOf("d100") > -1) Then
            t_sDiceType = "d100"
            t_nMaxPerDice = 100
        End If

        ' No dice found
        If (t_nMaxPerDice = 0) Then
            Return t_nRand
        End If

        Try
            t_nDices = Convert.ToInt32(a_sDices.Replace(t_sDiceType, ""))
        Catch ex As Exception
            t_nDices = 1
        End Try

        ' Get maximum value allowed
        t_nMaxTotal = t_nMaxPerDice * t_nDices

        ' Roll the dices...
        t_nRand = GetRandom(t_nMaxTotal + 1, t_nDices)

        Return t_nRand
    End Function

    Private Sub cmbNPC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNPC.SelectedIndexChanged
        Me.SelectNPCLoot()
    End Sub

    Private Sub radEvoSlow_CheckedChanged(sender As Object, e As EventArgs) Handles radEvoSlow.CheckedChanged
        Me.SetEvolution()
    End Sub

    Private Sub radEvoMedium_CheckedChanged(sender As Object, e As EventArgs) Handles radEvoMedium.CheckedChanged
        Me.SetEvolution()
    End Sub

    Private Sub radEvoFast_CheckedChanged(sender As Object, e As EventArgs) Handles radEvoFast.CheckedChanged
        Me.SetEvolution()
    End Sub

    Private Sub SelectNPCLoot()
        Dim t_bOnlyOneCategory As Boolean
        Dim t_oTableArray As ArrayList = Me.GetTableByName(TABLE_1_7_GP, t_bOnlyOneCategory)
        Dim i As Integer
        Dim t_oItem As STRUCTURE_ELEMENT

        If (t_oTableArray Is Nothing) Then
            Exit Sub
        End If

        For i = 0 To t_oTableArray.Count - 1
            t_oItem = t_oTableArray.Item(i)
            If (t_oItem.m_sItem = cmbNPC.Text) Then
                Select Case m_nEvolution
                    Case EVOLUTION_SLOW
                        m_nLoot = t_oItem.m_nPrice1
                    Case EVOLUTION_MEDIUM
                        m_nLoot = t_oItem.m_nPrice2
                    Case EVOLUTION_FAST
                        m_nLoot = t_oItem.m_nPrice3
                End Select
            End If
        Next i

        m_nLoot = m_nLoot * m_dLootFactor

        txtNPCLoot.Text = FormatNumber(m_nLoot, 0, , TriState.True)

        Me.Invalidate_Roll_Button()
    End Sub

    Private Sub SetEvolution()
        If (radEvoSlow.Checked = True) Then
            m_nEvolution = EVOLUTION_SLOW
        ElseIf (radEvoMedium.Checked = True) Then
            m_nEvolution = EVOLUTION_MEDIUM
        ElseIf (radEvoFast.Checked = True) Then
            m_nEvolution = EVOLUTION_FAST
        End If

        Me.SelectNPCLoot()
    End Sub

    Private Sub cmbNPCType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNPCType.SelectedIndexChanged
        Me.SelectNPCType()
    End Sub

    Private Sub SelectNPCType()
        Dim t_bOnlyOneCategory As Boolean
        Dim t_oTableArray As ArrayList = Me.GetTableByName(TABLE_CREATURE_TYPE, t_bOnlyOneCategory)
        Dim i As Integer
        Dim t_oItem As STRUCTURE_ELEMENT

        If (t_oTableArray Is Nothing) Then
            Exit Sub
        End If

        Me.chkNPCAddExtra.Checked = False
        For i = 0 To t_oTableArray.Count - 1
            t_oItem = t_oTableArray.Item(i)
            If (t_oItem.m_sItem = cmbNPCType.Text) Then
                m_sTreasureTypeCreature = t_oItem.m_sCoin

                If (t_oItem.m_sTableLink <> "") Then
                    Me.chkNPCAddExtra.Text = t_oItem.m_sTableLink
                    Me.chkNPCAddExtra.Visible = True
                Else
                    Me.chkNPCAddExtra.Visible = False
                End If

                Me.ActiveTreasureCheckBoxes(True)

                Exit For
            End If
        Next i

        Me.Invalidate_Roll_Button()
    End Sub

    Private Sub ActiveTreasureCheckBoxes(Optional ByVal a_bForceCheck As Boolean = False)
        Dim t_sTemp As String = Me.GetTreasureType()
        If (t_sTemp.IndexOf("A") > -1) Then
            If (Me.chk_TreasureA.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureA.Checked = True
            End If
            Me.chk_TreasureA.Enabled = True
        Else
            Me.chk_TreasureA.Enabled = False
            Me.chk_TreasureA.Checked = False
        End If

        If (t_sTemp.IndexOf("B") > -1) Then
            If (Me.chk_TreasureB.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureB.Checked = True
            End If
            Me.chk_TreasureB.Enabled = True
        Else
            Me.chk_TreasureB.Enabled = False
            Me.chk_TreasureB.Checked = False
        End If

        If (t_sTemp.IndexOf("C") > -1) Then
            If (Me.chk_TreasureC.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureC.Checked = True
            End If
            Me.chk_TreasureC.Enabled = True
        Else
            Me.chk_TreasureC.Enabled = False
            Me.chk_TreasureC.Checked = False
        End If

        If (t_sTemp.IndexOf("D") > -1) Then
            If (Me.chk_TreasureD.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureD.Checked = True
            End If
            Me.chk_TreasureD.Enabled = True
        Else
            Me.chk_TreasureD.Enabled = False
            Me.chk_TreasureD.Checked = False
        End If

        If (t_sTemp.IndexOf("E") > -1) Then
            If (Me.chk_TreasureE.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureE.Checked = True
            End If
            Me.chk_TreasureE.Enabled = True
        Else
            Me.chk_TreasureE.Enabled = False
            Me.chk_TreasureE.Checked = False
        End If

        If (t_sTemp.IndexOf("F") > -1) Then
            If (Me.chk_TreasureF.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureF.Checked = True
            End If
            Me.chk_TreasureF.Enabled = True
        Else
            Me.chk_TreasureF.Enabled = False
            Me.chk_TreasureF.Checked = False
        End If

        If (t_sTemp.IndexOf("G") > -1) Then
            If (Me.chk_TreasureG.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureG.Checked = True
            End If
            Me.chk_TreasureG.Enabled = True
        Else
            Me.chk_TreasureG.Enabled = False
            Me.chk_TreasureG.Checked = False
        End If

        If (t_sTemp.IndexOf("H") > -1) Then
            If (Me.chk_TreasureH.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureH.Checked = True
            End If
            Me.chk_TreasureH.Enabled = True
        Else
            Me.chk_TreasureH.Enabled = False
            Me.chk_TreasureH.Checked = False
        End If

        If (t_sTemp.IndexOf("I") > -1) Then
            If (Me.chk_TreasureI.Enabled = False) Or (a_bForceCheck = True) Then
                Me.chk_TreasureI.Checked = True
            End If
            Me.chk_TreasureI.Enabled = True
        Else
            Me.chk_TreasureI.Enabled = False
            Me.chk_TreasureI.Checked = False
        End If
    End Sub

    Private Function GetTreasureType() As String
        Dim t_sType As String = ""

        If (Me.chkNPCAddExtra.Checked = True) Then
            t_sType = m_sTreasureTypeCreature.Replace("*", "")
        Else
            Dim t_nIndex As Integer = m_sTreasureTypeCreature.IndexOf("*")
            If (t_nIndex > -1) Then
                t_sType = m_sTreasureTypeCreature.Substring(0, t_nIndex - 1)
            Else
                t_sType = m_sTreasureTypeCreature
            End If
        End If

        t_sType = t_sType.Replace(",", ", ")

        Return t_sType
    End Function

    Private Sub Invalidate_Roll_Button()
        Select Case m_nTreasureType
            Case TREASURE_SETTLEMENT
                If (cmbSettlement.Text <> "") Then
                    Me.btnRoll.Enabled = True
                Else
                    Me.btnRoll.Enabled = False
                End If
            Case TREASURE_BLACK_MARKET
                If (cmbBlackMarket.Text <> "") Then
                    Me.btnRoll.Enabled = True
                Else
                    Me.btnRoll.Enabled = False
                End If
            Case TREASURE_NPC
                If ((cmbNPC.Text <> "") And (cmbNPCType.Text <> "")) Then
                    Me.btnRoll.Enabled = True
                Else
                    Me.btnRoll.Enabled = False
                End If
            Case TREASURE_UNIQUE
                Me.btnRoll.Enabled = False
        End Select

    End Sub

    Private Sub radLTypeIncidental_CheckedChanged(sender As Object, e As EventArgs) Handles radLTypeIncidental.CheckedChanged
        Me.SetLootType()
    End Sub

    Private Sub radLTypeStandard_CheckedChanged(sender As Object, e As EventArgs) Handles radLTypeStandard.CheckedChanged
        Me.SetLootType()
    End Sub

    Private Sub radLTypeDouble_CheckedChanged(sender As Object, e As EventArgs) Handles radLTypeDouble.CheckedChanged
        Me.SetLootType()
    End Sub

    Private Sub radLTypeTriple_CheckedChanged(sender As Object, e As EventArgs) Handles radLTypeTriple.CheckedChanged
        Me.SetLootType()
    End Sub

    Private Sub SetLootType()
        If (radLTypeIncidental.Checked = True) Then
            m_dLootFactor = 0.5
        ElseIf (radLTypeStandard.Checked = True) Then
            m_dLootFactor = 1
        ElseIf (radLTypeDouble.Checked = True) Then
            m_dLootFactor = 2
        ElseIf (radLTypeTriple.Checked = True) Then
            m_dLootFactor = 3
        End If

        Me.SelectNPCLoot()
    End Sub

    Private Sub chkNPCAddExtra_CheckedChanged(sender As Object, e As EventArgs) Handles chkNPCAddExtra.CheckedChanged
        Me.ActiveTreasureCheckBoxes()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ttip.SetToolTip(chk_TreasureA, "Type A Treasure, Coins")
        ttip.SetToolTip(chk_TreasureB, "Type B Treasure, Coins and Gems")
        ttip.SetToolTip(chk_TreasureC, "Type C Treasure, Art Objects")
        ttip.SetToolTip(chk_TreasureD, "Type D Treasure, Coins and Small Objects")
        ttip.SetToolTip(chk_TreasureE, "Type E Treasure, Armor and Weapons")
        ttip.SetToolTip(chk_TreasureF, "Type F Treasure, Combatant Gear")
        ttip.SetToolTip(chk_TreasureG, "Type G Treasure, Spellcaster Gear")
        ttip.SetToolTip(chk_TreasureH, "Type H Treasure, Lair Treasure")
        ttip.SetToolTip(chk_TreasureI, "Type I Treasure, Treasure Hoard")

        chk_TreasureA.Enabled = False
        chk_TreasureB.Enabled = False
        chk_TreasureC.Enabled = False
        chk_TreasureD.Enabled = False
        chk_TreasureE.Enabled = False
        chk_TreasureF.Enabled = False
        chk_TreasureG.Enabled = False
        chk_TreasureH.Enabled = False
        chk_TreasureI.Enabled = False
    End Sub
End Class
