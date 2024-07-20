namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IControllerServiceEditable<TModel>
    {
        Task<TModel> Create(TModel model);
        Task<TModel> Update(TModel model);
    }
}
