namespace Server.Services.Interfaces {
    public interface IProductService {
        Task<bool> ExistsProduct(int id);
    }
}
