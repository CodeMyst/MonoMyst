namespace MonoMyst.Engine.UI
{
    public class GridLength
    {
        private GridUnitType _gridUnitType;
        public GridUnitType GridUnitType => _gridUnitType;

        private float _value;
        public float Value => _value;

        public GridLength (float value, GridUnitType gridUnitType)
        {
            _value = value;
            _gridUnitType = gridUnitType;
        }
    }
}
