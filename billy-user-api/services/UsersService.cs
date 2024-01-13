using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BillyUserApi.Models;

namespace BillyUserApi.Services;

public class UsersService
{
  private readonly IMongoCollection<User> _usersCollection;

  public UsersService(IOptions<BillyDatabaseSettings> userDbSettings)
  {
    var mongoClient = new MongoClient(userDbSettings.Value.ConnectionString);
    var mongoDB = mongoClient.GetDatabase(userDbSettings.Value.DatabaseName);
    _usersCollection = mongoDB.GetCollection<User>(userDbSettings.Value.CollectionName);
  }

  public async Task<List<User>> Get() => await _usersCollection.Find(_ => true).ToListAsync();
  public async Task<User?> Get(string id) => await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
  public async Task Create(User newUser) => await _usersCollection.InsertOneAsync(newUser);
  public async Task Update(User updatedUser) =>
    await _usersCollection.ReplaceOneAsync(x => x.Id == updatedUser.Id, updatedUser);
  public async Task Remove(string id) => await _usersCollection.DeleteOneAsync(x => x.Id == id);
  public async Task<User?> GetByEmail(string email) => await _usersCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
}