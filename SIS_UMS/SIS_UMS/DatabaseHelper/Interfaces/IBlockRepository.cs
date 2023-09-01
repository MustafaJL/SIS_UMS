using SIS_UMS.Models;

namespace SIS_UMS.DatabaseHelper.Interfaces
{
    public interface IBlockRepository
    {

        Task<IEnumerable<block>> GetAllBlocks();
        Task<block> GetBlockById(int blockId);


      
        Task CreateBlock(block c);

        Task UpdateBlock(block c);


        Task DeleteBlock(block c);
    }
}
