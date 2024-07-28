using MySocialMedia.Api.Dtos;

namespace MySocialMedia.Api.Endpoints;

public static class Post
{
    private static readonly List<GetPostsDto> posts = [
        new(
        1,
        "Preqsy",
        "How To Code",
        "This is a random Post that teaches how to code",
        new DateTime()
    )
    ];

    public static RouteGroupBuilder MapPostEndpoint(this WebApplication app)
    {
        var router = app.MapGroup("/posts").WithParameterValidation();
        router.MapGet("/", () => posts);

        router.MapPost("/", (CreatePostsDto newPost) =>
        {
            GetPostsDto post = new GetPostsDto(
                Id: Random.Shared.Next(1, 10),
                Username: newPost.Username,
                Title: newPost.Title,
                Content: newPost.Content,
                CreatedAt: new DateTime()

            );
            posts.Add(post);
            return Results.Created();

        });

        router.MapPut("/{id}", (int id, UpdatePostsDto updatedPost) =>
        {
            var index = posts.FindIndex(post => post.Id == id);
            if (index == -1)
            {
                return Results.NotFound($"Post with ID: {id} Doesn't Exist");
            }
            posts[index] = new GetPostsDto(
                Id: posts[index].Id,
                Username: posts[index].Username,
                Title: updatedPost.Title,
                Content: updatedPost.Content,
                CreatedAt: posts[index].CreatedAt
            );
            return Results.NoContent();

        });

        router.MapDelete("/{id}", (int id) =>
        {
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return Results.NotFound($"Post with ID: {id} doesn't exist");
            }

            posts.RemoveAll(p => p.Id == id);
            return Results.NoContent();
        });

        return router;
    }
}
