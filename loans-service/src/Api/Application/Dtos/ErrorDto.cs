using System;
using System.Collections.Generic;
using LoanService.Api.Domain.LoanAggregate;

namespace LoanService.Api.Application.Dtos
{
    public class ErrorDto
    {
        public ErrorDto(string code, string message)
        {
            this.ErrorCode = code;
            this.Message = message;
        }
        public string ErrorCode { get; set;}
        public string Message { get; set; }
    }
}