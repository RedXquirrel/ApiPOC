using System.Threading.Tasks;
using MyApi.ResponseTypes;

namespace MyApi.Interfaces
{
    public interface IMyApiService
    {
        Task<PersonsResponse> GetPersonsAsync();
    }
}