﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FFXIVTool.Utility
{
    [XmlRoot]
    public class Settings
    {
        #region Singleton
        [XmlIgnore]
        private static Settings instance;
        [XmlIgnore]
        public static Settings Instance
        {
            get
            {
                if (instance == null)
                    instance = new Settings();
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        #endregion
        public string AoBOffset { get; set; }
        public string GposeOffset { get; set; }
        public string GposeEmoteOffset { get; set; }
        public string CameraOffset { get; set; }
        public string TimeOffset { get; set; }
        public string WeatherOffset { get; set; }
        public string HousingOffset { get; set; }
        public string TerritoryOffset { get; set; }
        public bool VersionCheck { get; set; }
        public CharacterOffsets Character { get; set; }
    }

    [Serializable]
    public struct CharacterOffsets
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string RenderDistance { get; set; }
        public string TimeControl { get; set; }
        public string Weather { get; set; }
        public string Gender { get; set; }
        public string EyeBrowType { get; set; }
        public string Clan { get; set; }
        public string BodyType { get; set; }
        public string EntityType { get; set; }
        public string FreezeFacial { get; set; }
        public string Territory { get; set; }
        public BodyOffsets Body { get; set; }
        public string TailorMuscle { get; set; }
        public string NameHeight { get; set; }
        public string TailType { get; set; }
        public string ModelType { get; set; }
        public string Transparency { get; set; }
        public string Head { get; set; }
        public string Hair { get; set; }
        public string Jaw { get; set; }
        public string LimbalR { get; set; }
        public string LimbalG { get; set; }
        public string LimbalB { get; set; }
        public string RenderToggle { get; set; }
        public string RHeight { get; set; }
        public string RBust { get; set; }
        public string Highlights { get; set; }
        public string HighlightTone { get; set; }
        public string Skintone { get; set; }
        public string FOV2 { get; set; }
        public string HairTone { get; set; }
        public string RightEye { get; set; }
        public string LeftEye { get; set; }
        public string Eye { get; set; }
        public string Nose { get; set; }
        public string Lips { get; set; }
        public string LipsTone { get; set; }
        public string FacePaint { get; set; }
        public string FacePaintColor { get; set; }
        public string FacialFeatures { get; set; }
        public string Emote { get; set; }
        public string EmoteSpeed1 { get; set; }
        public string EmoteSpeed2 { get; set; }
        public string CameraHeight { get; set; }
        public string CameraYAMin { get; set; }
        public string CameraYAMax { get; set; }
        public string Voices { get; set; }
        public string CamX { get; set; }
        public string CamY { get; set; }
        public string CamZ { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
        public string CZoom { get; set; }
        public string FOVC { get; set; }
        public string FOVMAX { get; set; }
        public string HeadPiece { get; set; }
        public string HeadV { get; set; }
        public string HeadDye { get; set; }
        public string Chest { get; set; }
        public string ChestV { get; set; }
        public string ChestDye { get; set; }
        public string Arms { get; set; }
        public string ArmsV { get; set; }
        public string ArmsDye { get; set; }
        public string Legs { get; set; }
        public string LegsV { get; set; }
        public string LegsDye { get; set; }
        public string Feet { get; set; }
        public string FeetVa { get; set; }
        public string FeetDye { get; set; }
        public string Ear { get; set; }
        public string EarVa { get; set; }
        public string Neck { get; set; }
        public string NeckVa { get; set; }
        public string Wrist { get; set; }
        public string WristVa { get; set; }
        public string RFinger { get; set; }
        public string RFingerVa { get; set; }
        public string LFinger { get; set; }
        public string LFingerVa { get; set; }
        public string Job { get; set; }
        public string WeaponBase { get; set; }
        public string WeaponV { get; set; }
        public string WeaponDye { get; set; }
        public string WeaponX { get; set; }
        public string WeaponY { get; set; }
        public string WeaponZ { get; set; }
        public string Offhand { get; set; }
        public string OffhandBase { get; set; }
        public string OffhandV { get; set; }
        public string OffhandDye { get; set; }
        public string OffhandX { get; set; }
        public string OffhandY { get; set; }
        public string OffhandZ { get; set; }
        public string OffhandRed { get; set; }
        public string OffhandGreen { get; set; }
        public string OffhandBlue { get; set; }
        public string WeaponRed { get; set; }
        public string WeaponBlue { get; set; }
        public string WeaponGreen { get; set; }
        public string SkinRedPigment { get; set; }
        public string SkinGreenPigment { get; set; }
        public string SkinBluePigment { get; set; }
        public string SkinRedGloss { get; set; }
        public string SkinGreenGloss { get; set; }
        public string SkinBlueGloss { get; set; }
        public string HairRedPigment { get; set; }
        public string HairGreenPigment { get; set; }
        public string HairBluePigment { get; set; }
        public string HairGlowRed { get; set; }
        public string HairGlowGreen { get; set; }
        public string HairGlowBlue { get; set; }
        public string HighlightRedPigment { get; set; }
        public string HighlightGreenPigment { get; set; }
        public string HighlightBluePigment { get; set; }
        public string LeftEyeRed { get; set; }
        public string LeftEyeGreen { get; set; }
        public string LeftEyeBlue { get; set; }
        public string RightEyeRed { get; set; }
        public string RightEyeGreen { get; set; }
        public string RightEyeBlue { get; set; }
        public string LipsBrightness { get; set; }
        public string LipsR { get; set; }
        public string LipsG { get; set; }
        public string LipsB { get; set; }
        public string CameraUpDown { get; set; }
    }

    [Serializable]
    public struct BodyOffsets
    {
        [XmlAttribute("Base")]
        public string Base { get; set; }

        public PositionOffsets Position { get; set; }
        public Vector3Offsets Bust { get; set; }
        public string Height { get; set; }
        public string Wetness { get; set; }
        public string SWetness { get; set; }
        public Vector3Offsets Scale { get; set; }
        public string MuscleTone { get; set; }
        public string TailSize { get; set; }
    }

    [Serializable]
    public struct PositionOffsets
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
        public string Rotation { get; set; }
        public string Rotation2 { get; set; }
        public string Rotation3 { get; set; }
        public string Rotation4 { get; set; }
    }

    [Serializable]
    public struct Vector3Offsets
    {
        [XmlAttribute("Base")]
        public string Base { get; set; }

        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }
}
