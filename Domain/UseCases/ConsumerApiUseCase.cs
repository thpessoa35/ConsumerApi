
using employeeModel;
using iConsumerApi;

namespace consumerApiUseCase
{
    public class ConsumerApiUseCase
    {
        private readonly IConsumerApi _iConsumerApi;

        public ConsumerApiUseCase(IConsumerApi iConsumerApi)
        {
            _iConsumerApi = iConsumerApi;
        }

        public async Task<List<Employee>> FindAll()
        {
            var findAllResponse = await _iConsumerApi.GetEmployee();

            if (findAllResponse?.GetValue != null)
            {
                var employeeList = findAllResponse.GetValue;

                return employeeList;
            }
            return new List<Employee>();
        }
    };
};

