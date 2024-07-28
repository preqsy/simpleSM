using System.ComponentModel.DataAnnotations;

namespace MySocialMedia.Api.Dtos;

public record class CreatePostsDto(

    [Required][StringLength(maximumLength: 10)] string Username,
    [Required][StringLength(maximumLength: 20)] string Title,
    [Required] string Content,
    DateTime CreatedAt

);
public record class UpdatePostsDto(

    string Title,
    string Content


);

public record class GetPostsDto(
    int Id,
    string Username,
    string Title,
    string Content,
    DateTime CreatedAt

);

