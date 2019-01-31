using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supershop.Modifiers
{
    class ModBuilderTemplate
    {
        private int _modBuilderDetailID;
        private int _modBuilderTemplateID;
        private string _modBuilderType;
        private int _menuModifierID;
        private double _additionalCost;
        private int _noTypeModifierID;
        private double _noTypeCost;
        private int _addTypeModifierID;
        private int _addTypeCost;
        private double _extraTypeModifierID;
        private double _extraTypeCost;
        private int _lightTypeModifierID;
        private double _lightTypeCost;
        private int _exchgTypeModifierID;
        private double _exchgTypeCost;
        private int _doubleTypeModifierID;
        private double _doubleTypeCost;
        private int _tripleTypeModifierID;
        private double _tripleTypeCost;
        private int _halfTypeModifierID;
        private double _halfTypeCost;
        private string _displayIndex;

        public int ModBuilderDetailID { get => _modBuilderDetailID; set => _modBuilderDetailID = value; }
        public int ModBuilderTemplateID { get => _modBuilderTemplateID; set => _modBuilderTemplateID = value; }
        public string ModBuilderType { get => _modBuilderType; set => _modBuilderType = value; }
        public int MenuModifierID { get => _menuModifierID; set => _menuModifierID = value; }
        public double AdditionalCost { get => _additionalCost; set => _additionalCost = value; }
        public int NoTypeModifierID { get => _noTypeModifierID; set => _noTypeModifierID = value; }
        public double NoTypeCost { get => _noTypeCost; set => _noTypeCost = value; }
        public int AddTypeModifierID { get => _addTypeModifierID; set => _addTypeModifierID = value; }
        public int AddTypeCost { get => _addTypeCost; set => _addTypeCost = value; }
        public double ExtraTypeModifierID { get => _extraTypeModifierID; set => _extraTypeModifierID = value; }
        public double ExtraTypeCost { get => _extraTypeCost; set => _extraTypeCost = value; }
        public int LightTypeModifierID { get => _lightTypeModifierID; set => _lightTypeModifierID = value; }
        public double LightTypeCost { get => _lightTypeCost; set => _lightTypeCost = value; }
        public int ExchgTypeModifierID { get => _exchgTypeModifierID; set => _exchgTypeModifierID = value; }
        public double ExchgTypeCost { get => _exchgTypeCost; set => _exchgTypeCost = value; }
        public int DoubleTypeModifierID { get => _doubleTypeModifierID; set => _doubleTypeModifierID = value; }
        public double DoubleTypeCost { get => _doubleTypeCost; set => _doubleTypeCost = value; }
        public int TripleTypeModifierID { get => _tripleTypeModifierID; set => _tripleTypeModifierID = value; }
        public double TripleTypeCost { get => _tripleTypeCost; set => _tripleTypeCost = value; }
        public int HalfTypeModifierID { get => _halfTypeModifierID; set => _halfTypeModifierID = value; }
        public double HalfTypeCost { get => _halfTypeCost; set => _halfTypeCost = value; }
        public string DisplayIndex { get => _displayIndex; set => _displayIndex = value; }
    }
}
