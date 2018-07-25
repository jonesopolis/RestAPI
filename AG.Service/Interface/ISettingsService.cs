using System.Threading.Tasks;
using AG.Dto;
using AG.Utilities;

namespace AG.Service.Interface
{
    public interface ISettingsService
    {
        Task<ResponseMeta<SettingsDto>> GetSettings();
    }
}