using AsyncProduct.Data;
using AsyncProduct.DTOs;
using AsyncProduct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt 
    => opt.UseSqlite("Data Source=RequestDb.db"));

var app = builder.Build();

app.UseHttpsRedirection();

//start endpoint
app.MapPost("api/v1/products", async (AppDbContext context, ListingRequest listingRequest) =>
{
    if (listingRequest == null)
    {
        return Results.BadRequest();
    }

    listingRequest.RequestStatus = "ACCEPT";
    listingRequest.EstimatedCompetionTime = "2023-02-15:23:59:00"; // any methode calculate how many prodyct to calculate

    await context.ListingRequests.AddAsync(listingRequest);
    await context.SaveChangesAsync();

    return Results.Accepted($"api/v1/products/{listingRequest.RquestId}", listingRequest);
});

//Status  endpoint
app.MapGet("api/v1/productstatus/{requestId}", (AppDbContext context, string requestId) =>
{
    var listingRequest = context.ListingRequests.FirstOrDefault(r => r.RquestId == requestId);
    if (listingRequest == null)
        return Results.NotFound();
    
    ListingStatus listingStatus = new ListingStatus()
    {
        RequestStatus = listingRequest.RequestStatus,
        EstimatedCompetionTime = listingRequest.EstimatedCompetionTime,
        ResourceURL = string.Empty
    };

    if (listingRequest.RequestStatus!.ToUpper() == "COMPLETED")
    {
        listingStatus.ResourceURL = $"api/v1/products/{Guid.NewGuid().ToString()}";
        //return Results.Ok(listingStatus);

        return Results.Redirect("https://localhost:7285/" + listingStatus.ResourceURL);
    }

    listingStatus.EstimatedCompetionTime = "2023-02-16:01:59:00";
    return Results.Ok(listingStatus);
});

app.MapGet("api/v1/products/{requestId}", (string requestId) =>
{
    //validate requestID
    return Results.Ok("This is end od work, and here is result of job");
});


app.Run();  