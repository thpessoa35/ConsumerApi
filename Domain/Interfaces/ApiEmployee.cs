using ApiServiceDto;
using employeeModel;

namespace iConsumerApi
{
    public interface IConsumerApi
    {
        Task<ResponseGeneric<List<Employee>>> GetEmployeUnique(string id);
        Task<ResponseGeneric<List<Employee>>> GetEmployee();
        Task<ResponseGeneric<List<Employee>>> AddCommission(string id, decimal salary, decimal commission);
    }
}