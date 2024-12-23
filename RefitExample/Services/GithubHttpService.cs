using RefitExample.Models;

namespace RefitExample.Services {
    public class GithubHttpService(HttpClient httpClient) {
        public async Task<UserViewModel?> GetUserByUsernameAsync(string username) {
           return await httpClient.GetFromJsonAsync<UserViewModel>(requestUri: $"users/{username}", cancellationToken: default);

        }
    }
}
