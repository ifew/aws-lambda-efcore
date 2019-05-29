using System;
using System.Collections.Generic;
using System.Net;

using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace aws_lambda_efcore
{
    public class Function
    {
        private ServiceProvider _service;

        public Function() : this (Bootstrap.CreateInstance()) {}

        public Function(ServiceProvider service)
        {
            _service = service;
        }
        
        public List<Member> FunctionHandler(ILambdaContext context)
        {
            var service = _service.GetService<Services>();
            List<Member> members = service.List_member();

            Console.WriteLine("Log: Count: " + members.Count);

            return members;
        }
        
    }
}
