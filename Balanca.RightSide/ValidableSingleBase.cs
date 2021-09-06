namespace Balanca.RightSide
{
    public abstract class ValidableSingleBase<T> : SingleBase<T>, IValidable<T>
    {
        public ValidableSingleBase() : base()
        {

        }

        public ValidableSingleBase(T value) : base(value)
        {

        }

        public abstract void Validate(T value);

        public override void SetValue(T value)
        {
            Validate(value);
            base.SetValue(value);
        }
    }
}
