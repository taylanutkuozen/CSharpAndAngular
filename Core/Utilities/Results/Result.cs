using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success1)
        {
            Success = success1;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public bool Success { get; } //=> throw new NotImplementedException(); sadece return
        public string Message { get; } // => throw new NotImplementedException();
    }
}