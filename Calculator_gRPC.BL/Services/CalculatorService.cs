using Calculator_gRPC.BL.Classes;
using Calculator_gRPC.BL.Models;
using Calculator_gRPC.Models;
using Grpc.Core;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator_gRPC.BL
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        public override Task<CalcReply> Calculate(CalcRequest request, ServerCallContext context)
        {
            var serializedRequest = JsonConvert.DeserializeObject<Request>(request.JsonData);
            var numberOfOperations = serializedRequest.type.Count();
            var serializedReply = new Reply(numberOfOperations);

            if (numberOfOperations == 0)
                return CreateErrorJson("Zero operations inputed");

            for (int currentOperationNumber = 0; currentOperationNumber < numberOfOperations; currentOperationNumber++)
            {
                try
                {
                    var currentOperationResult = CalculatorOperation.Execute(serializedRequest.type[currentOperationNumber], serializedRequest.parameters);
                    serializedReply.Results[currentOperationNumber] = currentOperationResult;
                }
                catch(Exception ex)
                {
                    return CreateErrorJson(ex.Message);
                }

            }
            return CreateSuccessReply(serializedReply);
        }

        private Task<CalcReply> CreateErrorJson(string errorMessage)
        {
            var serializedReplyWithErrors = new ReplyWithErrors();
            serializedReplyWithErrors.Error = errorMessage;
            return Task.FromResult(new CalcReply
            {
                JsonData = JsonConvert.SerializeObject(serializedReplyWithErrors)
            });
        }

        private Task<CalcReply> CreateSuccessReply(Reply reply)
        {
            reply.Success = true;
            return Task.FromResult(new CalcReply
            {
                JsonData = JsonConvert.SerializeObject(reply)
            });
        }
    }
}
