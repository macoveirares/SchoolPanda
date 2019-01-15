using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagement.Api.Filters
{
    public class FileCreationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if(operation.OperationId.ToLower() == "apifileuploadpost")
            {
                operation.Parameters.Clear();
                operation.Parameters.Add(new NonBodyParameter()
                {
                    Name = "File",
                    In = "formData",
                    Description = "Upload file",
                    Required = true,
                    Type = "file"
                });
                operation.Consumes.Add("operation/form-data");
            }
        }
    }
}
