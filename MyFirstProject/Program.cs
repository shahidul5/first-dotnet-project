using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", async (HttpContext context) =>
//{
//    if (query["operation"] == "add")
//    {
//        if (query.TryGetValue("firstNumber", out var firstNumber) && query.TryGetValue("secondNumber", out var secondNumber))
//        {
//            if (int.TryParse(firstNumber, out int first) && int.TryParse(secondNumber, out int second))
//            {
//                return Results.Ok((first + second));
//            }
//            return Results.BadRequest("Invalid numbers provided.");
//        }
//        return Results.BadRequest("Missing query parameters.");
//    }
//    else if (query["operation"] == "subtract")
//    {
//        if (query.TryGetValue("firstNumber", out var firstNumber) && query.TryGetValue("secondNumber", out var secondNumber))
//        {
//            if (int.TryParse(firstNumber, out int first) && int.TryParse(secondNumber, out int second))
//            {
//                return Results.Ok((first - second));
//            }
//            return Results.BadRequest("Invalid numbers provided.");
//        }
//        return Results.BadRequest("Missing query parameters.");
//    }
//    else if (query["operation"] == "multiply")
//    {
//        if (query.TryGetValue("firstNumber", out var firstNumber) && query.TryGetValue("secondNumber", out var secondNumber))
//        {
//            if (int.TryParse(firstNumber, out int first) && int.TryParse(secondNumber, out int second))
//            {
//                return Results.Ok((first * second));
//            }
//            return Results.BadRequest("Invalid numbers provided.");
//        }
//        return Results.BadRequest("Missing query parameters.");
//    }
//    else if (query["operation"] == "divide")
//    {
//        if (query.TryGetValue("firstNumber", out var firstNumber) && query.TryGetValue("secondNumber", out var secondNumber))
//        {
//            if (int.TryParse(firstNumber, out int first) && int.TryParse(secondNumber, out int second))
//            {
//                if (second == 0)
//                {
//                    return Results.BadRequest("Cannot divide by zero.");
//                }
//                return Results.Ok((first / second));
//            }
//            return Results.BadRequest("Invalid numbers provided.");
//        }
//        return Results.BadRequest("Missing query parameters.");
//    }
//    else
//    {
//        return Results.BadRequest("Invalid input for operation.");
//    }
//});

// another solution
app.MapGet("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html";

    if(context.Request.Query.ContainsKey("firstNumber") && context.Request.Query.ContainsKey("secondNumber") && context.Request.Query.ContainsKey("operation"))
    {
        int firstNumber = int.Parse(context.Request.Query["firstNumber"]);
        int secondNumber = int.Parse(context.Request.Query["secondNumber"]);

        int result;

        switch (context.Request.Query["operation"])
        {
            case "add":
                result = firstNumber + secondNumber;
                return Results.Ok(result);
            case "subtract":
                result = firstNumber - secondNumber;
                return Results.Ok(result);
            case "multiply":
                result = firstNumber - secondNumber;
                return Results.Ok(result);
            case "divide":
                if (secondNumber == 0)
                {
                    return Results.BadRequest("Cannot divide by zero.");
                }
                result = firstNumber / secondNumber;
                return Results.Ok(result);
            case "remainder":
                if (secondNumber == 0)
                {
                    return Results.BadRequest("Cannot divide by zero.");
                }
                result = firstNumber % secondNumber;
                return Results.Ok(result);
            default:
                return Results.BadRequest("Invalid operation.");
        }
    }
    else
    {
        return Results.BadRequest("Missing query parameters.");
    }
});

app.Run();
