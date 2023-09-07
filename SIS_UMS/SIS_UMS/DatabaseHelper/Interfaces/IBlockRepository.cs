using SIS_UMS.Models;
using SIS_UMS.Models.ViewModels;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IBlockRepository
    {

        Task<IEnumerable<BlockViewModel>> GetAllBlocks();
        Task<block> GetBlockById(int blockId);



        Task CreateBlock(block c);

        Task UpdateBlock(block c);


        Task DeleteBlock(block c);
    }
}