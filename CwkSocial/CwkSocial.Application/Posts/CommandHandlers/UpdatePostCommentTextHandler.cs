﻿using Cwk.Domain.Aggregates.PostAggregate;
using Cwk.Domain.Exceptions;
using CwkSocial.Application.Enums;
using CwkSocial.Application.Models;
using CwkSocial.Application.Posts.Commands;
using CwkSocial.Dal;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CwkSocial.Application.Posts.CommandHandlers;

public class UpdatePostCommentTextHandler : IRequestHandler<UpdatePostCommentText, OperationResult<PostComment>>
{
    private readonly DataContext _ctx;

    public UpdatePostCommentTextHandler(DataContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<OperationResult<PostComment>> Handle(UpdatePostCommentText request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<PostComment>();

        try
        {
            var post = await _ctx.Posts
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == request.PostId);

            if (post is null)
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"No post found with ID {request.PostId}"
                };
                result.Errors.Add(error);
                return result;
            }

            var comment = post.Comments.FirstOrDefault(c => c.CommentId == request.PostCommentId);

            if (comment is null)
            {
                result.IsError = true;
                var error = new Error
                {
                    Code = ErrorCode.NotFound,
                    Message = $"Post doesn't include any comment with the specified ID {request.PostCommentId}"
                };
                result.Errors.Add(error);
                return result;
            }

            comment.UpdateCommentText(request.NewText);

            await _ctx.SaveChangesAsync();

            result.Payload = comment;
        }
        catch (PostCommentNotValidException e)
        {
            result.IsError = true;
            e.ValidationErrors.ForEach(err =>
            {
                var error = new Error
                {
                    Code = ErrorCode.ValidationError,
                    Message = $"{e.Message}",
                };
                result.Errors.Add(error);
            });
        }
        catch(Exception e)
        {
            var error = new Error
            {
                Code = ErrorCode.UnknownError,
                Message = $"{e.Message}"
            };
            result.Errors.Add(error);
        }

        return result;
    }
}
