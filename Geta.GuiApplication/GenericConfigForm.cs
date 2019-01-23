namespace NeosIT.Exchange.GenericExchangeTransportAgent.GuiApplication
{
    public interface IGenericConfigForm<T> where T : IHandler
    {
        T Handler { get; }

        void Init(T handler);

        void Show();
    }
}