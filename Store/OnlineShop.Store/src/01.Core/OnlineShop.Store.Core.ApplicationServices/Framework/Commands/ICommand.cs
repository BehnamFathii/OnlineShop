namespace OnlineShop.Store.Core.ApplicationServices.Framework.Commands;
public interface ICommand : IBaseCommand
{
}

public interface ICommand<TReponse> : IBaseCommand
{
}

public interface IBaseCommand
{
}