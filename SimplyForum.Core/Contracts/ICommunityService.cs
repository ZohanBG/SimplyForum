using SimplyForum.Core.Models.Community;

namespace SimplyForum.Core.Contracts
{
    public interface ICommunityService
    {
        Task<bool> IsCommunityNameUniqueAsync(string name);

        Task AddCommunityAsync(AddCommunityModel model, string authorId);

        Task<IEnumerable<CommunityModel>> GetAllCommunitiesAsync();

        Task<CommunityModel> GetCommunityDetailsAsync(Guid communityId);
    }
}
