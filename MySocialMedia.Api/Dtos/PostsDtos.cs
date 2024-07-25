namespace MySocialMedia.Api.Dtos;

public record class CreatePostsDto(

    string Username,
    string Title,
    string Content,
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

