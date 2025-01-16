using Phoenix.Data.Interfaces;
using Phoenix.Data.Models;

namespace Phoenix.Data.Implementations;

public class RoomTypeRepository(PhoenixContext phoenixContext) : CrudRepository<RoomType, long>(phoenixContext), IRoomTypeRepository {

}