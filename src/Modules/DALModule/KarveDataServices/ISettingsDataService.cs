using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<IMagnifierSettings> GetMagnifierSettings(long idValue);
        /// <summary>
        /// Save all magnifer settings.
        /// </summary>
        /// <param name="value">This value of the magnifier.</param>
        Task<bool> SaveMagnifierSettings(IMagnifierSettings value);
        /// <summary>
        ///  Save the setting of a collection of magnifier
        /// </summary>
        /// <param name="magnifier">Save the setting of a collection of magnifier</param>
        /// <returns></returns>
        Task<bool> SaveAllMagnifierSettings(IList<IMagnifierSettings> magnifier);
        /// <summary>
        ///  This returns the all magnifier settings.
        /// </summary>
        /// <returns></returns>
        Task<IList<IMagnifierSettings>> GetAllMagnifiersSettings();
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        IMagnifierColumns NewMagnifierColumn();
        /// <summary>
        ///  Create a new magnifier column in the data base
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        Task<int> CreateMagnifierColumn(IMagnifierColumns col);
        /// <summary>
        ///  Delete a new magnifier setting from the ID 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        Task DeleteMagnifier(int i);
        /// <summary>
        ///  Create a new magnifier setting
        /// </summary>
        /// <returns></returns>
        IMagnifierSettings NewMagnifierSettings();
    }
}