using Grpc.Core;
using GrpcServer.Web.Data;
using GrpcServer.Web.Protos;

namespace GrpcServer.Web.Services
{
    public class MyEmployeeService:EmployeeService.EmployeeServiceBase
    {
        private readonly ILogger<MyEmployeeService> _logger;

        public MyEmployeeService(ILogger<MyEmployeeService> logger)
        {
            _logger = logger;
        }

        public override Task<EmployeeResponse> GetByNo(GetByNoRequest request, ServerCallContext context)
        {
            var md = context.RequestHeaders;
            foreach (var pair in md)
            {
                _logger.LogInformation($"Key:{pair.Key},value:{pair.Value}");
            }

            var employee = InMemoryData.Employees.SingleOrDefault(x => x.No == request.No);

            if (employee != null)
            {
                var response = new EmployeeResponse
                {
                    Employee = employee
                };
                return Task.FromResult(response);
            }

            throw new Exception($"Employee not found with no:{request.No}");
        }

        public override async Task GetAll(GetAllRequest request, IServerStreamWriter<EmployeeResponse> responseStream, ServerCallContext context)
        {
            foreach (var employee in InMemoryData.Employees)
            {
                await responseStream.WriteAsync(new EmployeeResponse()
                {
                    Employee = employee
                });
            } 
        }

        public override async Task<AddPhotoResponse> AddPhoto(IAsyncStreamReader<AddPhotoRequest> requestStream, ServerCallContext context)
        {
            var md = context.RequestHeaders;
            foreach (var pair in md)
            {
                _logger.LogInformation($"Key:{pair.Key},value:{pair.Value}");
            }

            var data = new List<byte>();

            while (await requestStream.MoveNext())
            {
                _logger.LogInformation($"Received {requestStream.Current.Data.Length} bytes");

                data.AddRange(requestStream.Current.Data);
            }

            _logger.LogInformation($"Received file with {data.Count} bytes");

            return new AddPhotoResponse()
            {
                IsOk = true
            };
        }

        public override async Task SaveAll(IAsyncStreamReader<EmployeeRequest> requestStream, IServerStreamWriter<EmployeeResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var employee = requestStream.Current.Employee;
                lock (this)
                {
                    employee.Id = InMemoryData.Employees.Max(x => x.Id) + 1;

                    InMemoryData.Employees.Add(employee);
                    
                }
                await responseStream.WriteAsync(new EmployeeResponse()
                {
                    Employee = employee
                });
            }

            _logger.LogInformation($"Employees:");
            foreach (var employee in InMemoryData.Employees)
            {
                _logger.LogInformation($"{employee}");
            }
        }
    }
}
