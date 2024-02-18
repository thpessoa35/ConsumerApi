using employeeModel;
using iConsumerApi;

namespace consumerApiUseCase
{
    public class ConsumerApiGetIdUseCase
    {
        private readonly IConsumerApi _iConsumerApi;

        public ConsumerApiGetIdUseCase(IConsumerApi iConsumerApi)
        {
            _iConsumerApi = iConsumerApi;
        }

        public async Task<List<Employee>> FindById(string id)
        {
            try
            {
                var findAllResponse = await _iConsumerApi.GetEmployeUnique(id);

                if (findAllResponse.GetValue != null)
                {
                    var employee = findAllResponse.GetValue;

                    return employee;
                }

                return new List<Employee>();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Erro ao obter funcionário por ID: {ex.Message}");
                throw;
            }
        }
    }
}


