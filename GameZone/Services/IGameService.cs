namespace GameZone.Services
{
    public interface IGameService
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateFormViewModel game);
        Task<Game?> Update(EditGameViewModelForm model); 
        bool Delete(int id);
    }
}
