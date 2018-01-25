using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices
{
    /// <summary>
    ///  ISettingsDataService.
    /// </summary>
    public interface ISettingsDataService
    {
        /// <summary>
        ///  Get all magnifier settings
        /// </summary>
        /// <returns></returns>
        Task<GridSettingsDto> GetMagnifierSettings(long idValue);
        /// <summary>
        ///  Save the magnifier settings.
        /// </summary>
        /// <param name="settingsDto"></param>
        Task<bool> SaveMagnifierSettings(GridSettingsDto settingsDto);

        /// <summary>
        /// Thois gets the magnifier settings using a list of registered identifier.
        /// </summary>
        /// <param name="registeredGridIds"></param>
        /// <returns></returns>
        Task<ObservableCollection<GridSettingsDto>> GetMagnifierSettingByIds(List<long> registeredGridIds);
    }
}