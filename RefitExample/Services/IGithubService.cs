using Refit;
using RefitExample.Models;

namespace RefitExample.Services {
    public interface IGithubService {
        [Get("/users/{username}")]
        public Task<UserViewModel> GetUserByUsernameAsync(string username);
    }
}
