﻿global using CwkSocial.Api.Extensions;
global using AutoMapper;
global using Cwk.Domain.Aggregates.UserProfileAggregate;
global using CwkSocial.Api.Contracts.UserProfile.Requests;
global using CwkSocial.Api.Contracts.UserProfile.Responses;
global using CwkSocial.Application.UserProfiles.Commands;
global using System.ComponentModel.DataAnnotations;
global using CwkSocial.Api.Contracts.Common;
global using CwkSocial.Application.Enums;
global using CwkSocial.Application.Models;
global using Microsoft.AspNetCore.Mvc;
global using CwkSocial.Api.Contracts.Posts.Requests;
global using CwkSocial.Api.Contracts.Posts.Responses;
global using CwkSocial.Api.Filters;
global using CwkSocial.Application.Posts.Commands;
global using CwkSocial.Application.Posts.Queries;
global using MediatR;
global using CwkSocial.Application.UserProfiles.Queries;
global using CwkSocial.Api.Registrars;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Cwk.Domain.Aggregates.PostAggregate;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.SwaggerGen;
global using CwkSocial.Dal;
global using Microsoft.EntityFrameworkCore;
global using CwkSocial.Api.Options;
global using System.Text;
global using CwkSocial.Application.Options;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using CwkSocial.Api.Contracts.Identity;
global using CwkSocial.Application.Identity.Commands;
