using TestSegurarseCore.Models;

namespace TestSegurarseCore.Services.Interfaces
{
    public interface ITestEncriptService
    {
        Task<string> Test(Persona persona);
    }
}
