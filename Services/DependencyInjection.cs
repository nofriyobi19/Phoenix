using Phoenix.Data;
using Phoenix.Data.Implementations;
using Phoenix.Data.Interfaces;

namespace Phoenix.Services;

public static class DependencyInjection {
    public static void AddServices(IServiceCollection services) {
        services.AddDbContext<PhoenixContext>();

        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

        services.AddScoped<RoomService>();
    }
}