using MySocialMedia.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GetPostsDto> posts = [
    new(
        1,
        "Preqsy",
        "How To Code",
        "This is a random Post that teaches how to code",
        new DateTime()
    )
];

app.MapGet("/", () => "Hello World!");

app.MapGet("/posts", () => posts);

app.MapPost("/posts", (CreatePostsDto newPost) =>
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

app.MapPut("/posts/{id}", (int id, UpdatePostsDto updatedPost) =>
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

app.MapDelete("/posts/{id}", (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if (post == null)
    {
        return Results.NotFound($"Post with ID: {id} doesn't exist");
    }

    posts.RemoveAll(p => p.Id == id);
    return Results.NoContent();
});


app.Run();
