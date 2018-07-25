using AG.Data;
using AG.Dto;
using AG.Service.Interface;
using AG.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Service
{
    public class SettingsService : ISettingsService
    {
        private readonly AsyncFactory<AgContext> _contextFactory;

        public SettingsService(AsyncFactory<AgContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ResponseMeta<SettingsDto>> GetSettings()
        {
            using (var context = await _contextFactory)
            {
                var list = context.Settings.ToList();

                var settings = new SettingsDto();
                settings.CourseImageUrl = list.FirstOrDefault(s => s.Key == "CourseImageUrl")?.Value;

                return ResponseMeta<SettingsDto>.CreateSuccess(settings);
            }
        }
    }
}
