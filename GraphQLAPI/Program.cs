using GraphQLAPI.Schema.Mutation;
using GraphQLAPI.Schema.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
