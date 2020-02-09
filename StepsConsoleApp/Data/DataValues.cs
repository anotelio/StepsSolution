using System;
using System.Threading.Tasks;
using StepsConsoleApp.Contracts.Dtos;

namespace StepsConsoleApp.Data
{
    public static class DataValues
    {
        public static async Task LabelAddToDb(long returnHeadId, string carrier, string file)
        {
            await Task.Run(() => 
                Console.WriteLine($"Add {file} from {carrier} with id = {returnHeadId} into our godlike database!"));
        }

        public static async Task<AddressDto> AdressGet(long returnHeadId)
        {
            Console.WriteLine($"Get address information for {returnHeadId}.");

            return await Task.FromResult(
                new AddressDto()
                {
                    ReturnHeadId = returnHeadId,
                    AccountNumber = "Acc007",
                    CompanyName = "J.Bond LTD",
                    Street = "Smally St.",
                    City = "Aruba",
                    Carrier = "DHL"
                });
        }

        public static async Task<LabelDto> DhlLabelGet(AddressDto addressDto)
        {
            Console.WriteLine($"Get label file from {addressDto.Carrier} for {addressDto.CompanyName}.");
            
            return await Task.FromResult(
                new LabelDto()
                {
                    ReturnHeadId = addressDto.ReturnHeadId,
                    Carrier = addressDto.Carrier,
                    LabelFile = "BrutalFile.pdf"
                });
        }

        public static async Task LabelDbOperations()
        {
            Console.WriteLine($"Do some database operations with added label files.");

            await Task.Run(() => 0);
        }
    }
}
