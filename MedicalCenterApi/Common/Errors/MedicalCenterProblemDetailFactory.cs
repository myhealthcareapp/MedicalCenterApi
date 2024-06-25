﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System;

namespace MedicalCenterApi.Common.Errors
{

    public class MedicalCenterProblemDetailFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public MedicalCenterProblemDetailFactory(IOptions<ApiBehaviorOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string title = null,
            string type = null,
            string detail = null,
            string instance = null)
        {
            statusCode ??= 500;

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title ?? GetDefaultTitleForStatusCode(statusCode.Value),
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

            return problemDetails;
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(
            HttpContext httpContext,
            ModelStateDictionary modelStateDictionary,
            int? statusCode = null,
            string title = null,
            string type = null,
            string detail = null,
            string instance = null)
        {
            if (modelStateDictionary == null)
            {
                throw new ArgumentNullException(nameof(modelStateDictionary));
            }

            statusCode ??= 400;

            var validationProblemDetails = new ValidationProblemDetails(modelStateDictionary)
            {
                Status = statusCode,
                Title = title ?? GetDefaultTitleForStatusCode(statusCode.Value),
                Type = type,
                Detail = detail,
                Instance = instance
            };

            ApplyProblemDetailsDefaults(httpContext, validationProblemDetails, statusCode.Value);

            return validationProblemDetails;
        }

        private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
        {
            problemDetails.Status ??= statusCode;

            if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
            {
                problemDetails.Title ??= clientErrorData.Title;
                problemDetails.Type ??= clientErrorData.Link;
            }

            problemDetails.Extensions["traceId"] = httpContext?.TraceIdentifier;
            problemDetails.Extensions.Add("customProperty", "customvalue");
            // Add more custom fields as needed
        }

        private static string GetDefaultTitleForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "An error occurred"
            };
        }
    }

}

