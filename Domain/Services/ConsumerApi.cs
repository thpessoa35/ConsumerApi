using System.Dynamic;
using System.Text.Json;
using ApiServiceDto;
using iConsumerApi;
using employeeModel;
using System.Text;

namespace IntegrationApi
{
    public class ConsumerApi : IConsumerApi
    {
        public async Task<ResponseGeneric<List<Employee>>> GetEmployee()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080/employees");

            var response = new ResponseGeneric<List<Employee>>();
            using (var client = new HttpClient())
            {
                var responseApi = await client.SendAsync(request);
                var contentRes = await responseApi.Content.ReadAsStringAsync();
                if (responseApi.IsSuccessStatusCode)
                {
                    var ObjResponse = JsonSerializer.Deserialize<List<Employee>>(contentRes);
                    response.CodigoHttp = responseApi.StatusCode;
                    response.GetValue = ObjResponse;
                }
                else
                {
                    response.CodigoHttp = responseApi.StatusCode;
                    response.ErrorResponse = JsonSerializer.Deserialize<ExpandoObject>(contentRes);
                }
                return response;
            }
        }

        public async Task<ResponseGeneric<List<Employee>>> GetEmployeUnique(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:8080/employees/{id}");

            var response = new ResponseGeneric<List<Employee>>();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseApi = await client.SendAsync(request);
                    var contentRes = await responseApi.Content.ReadAsStringAsync();

                    Console.WriteLine($"HTTP Status Code: {responseApi.StatusCode}");
                    Console.WriteLine($"Response Content: {contentRes}");

                    if (responseApi.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        var ObjResponse = JsonSerializer.Deserialize<List<Employee>>(contentRes, options);
                        response.CodigoHttp = responseApi.StatusCode;
                        response.GetValue = ObjResponse;
                    }
                    else
                    {
                        response.CodigoHttp = responseApi.StatusCode;
                        response.ErrorResponse = JsonSerializer.Deserialize<ExpandoObject>(contentRes);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro na desserialização do JSON: {ex.Message}");
                // Lide com isso conforme necessário (lançar exceção, atribuir um valor padrão, etc.)
            }

            return response;
        }
        public async Task<ResponseGeneric<List<Employee>>> AddCommission(string id, decimal newSalary, decimal newCommission)
        {
            var apiUrl = $"http://localhost:8080/employees/{id}";

            var request = new HttpRequestMessage(HttpMethod.Put, apiUrl);

            var requestBody = new
            {
                salary = newSalary,
                commission = newCommission
            };

            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = new ResponseGeneric<List<Employee>>();

            try
            {
                using (var client = new HttpClient())
                {
                    var responseApi = await client.SendAsync(request);
                    var contentRes = await responseApi.Content.ReadAsStringAsync();

                    Console.WriteLine($"HTTP Status Code: {responseApi.StatusCode}");
                    Console.WriteLine($"Response Content: {contentRes}");

                    if (responseApi.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        var ObjResponse = JsonSerializer.Deserialize<List<Employee>>(contentRes, options);
                        response.CodigoHttp = responseApi.StatusCode;
                        response.GetValue = ObjResponse;
                    }
                    else
                    {
                        response.CodigoHttp = responseApi.StatusCode;
                        response.ErrorResponse = JsonSerializer.Deserialize<ExpandoObject>(contentRes);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro na desserialização do JSON: {ex.Message}");
                // Lide com isso conforme necessário (lançar exceção, atribuir um valor padrão, etc.)
            }

            return response;
        }


    }
}
