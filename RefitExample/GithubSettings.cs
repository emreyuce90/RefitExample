using System.ComponentModel.DataAnnotations;

namespace RefitExample {
    public sealed class GithubSettings {
        public const string GithubConfiguration = "Github";
        [Required,Url] public string BaseUrl { get; set; } = string.Empty!;
        [Required] public string AccessToken { get; set; } = string.Empty!;
        [Required] public string UserAgent { get; set; } = string.Empty!;

    }
}
