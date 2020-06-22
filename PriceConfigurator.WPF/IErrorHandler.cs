using System;

namespace PriceConfigurator.WPF
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
