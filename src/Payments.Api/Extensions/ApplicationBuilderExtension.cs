namespace Microsoft.AspNetCore.Builder;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder Configure(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        return app;
    }
}
