// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace MailinatorProxy.API.Common.Extensions;

internal static class OpenApiExtensions
{
    private static readonly JsonSerializerOptions s_jsonSerializerOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static RouteHandlerBuilder WithRequestExample<T>(this RouteHandlerBuilder builder, T example)
    {
        builder.WithOpenApi(
            config =>
            {
                config.RequestBody = new OpenApiRequestBody
                {
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = typeof(T).Name,
                                    Type = ReferenceType.Schema
                                }
                            },
                            Example = new OpenApiString(JsonSerializer.Serialize(example, s_jsonSerializerOptions))
                        }
                    }
                };
                return config;
            }
        );
        return builder;
    }

    public static RouteHandlerBuilder WithResponseExample<T>(this RouteHandlerBuilder builder, int statusCode, string description, T example)
    {
        builder.WithOpenApi(
            config =>
            {
                config.Responses[statusCode.ToString()] = new OpenApiResponse
                {
                    Description = description,
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = typeof(T).Name,
                                    Type = ReferenceType.Schema
                                }
                            },
                            Example = new OpenApiString(JsonSerializer.Serialize(example, s_jsonSerializerOptions))
                        }
                    }
                };
                return config;
            }
        );
        return builder;
    }

    public static void SetOpenApiDocumentation(this OpenApiOptions options)
    {
        const string filePath = "Documentations/ApiDocumentation.md";
        if (!File.Exists(filePath))
        {
            return;
        }

        string markdownContent = File.ReadAllText(filePath);
        options.AddDocumentTransformer((document, context, cancellationToken) =>
        {
            document.Info.Description = markdownContent;
            return Task.CompletedTask;
        });
    }
}
