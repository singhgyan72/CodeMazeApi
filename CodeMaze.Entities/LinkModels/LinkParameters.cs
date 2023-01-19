using Microsoft.AspNetCore.Http;
using CodeMaze.Shared;

namespace CodeMaze.Entities
{
    public record LinkParameters(EmployeeParameters EmployeeParameters, HttpContext Context);
}
