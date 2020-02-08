using System;
using StepsConsoleApp.Contracts.Dtos;

namespace StepsConsoleApp.Data
{
    public static class DataValues
    {
        public static void LabelAddToDb(long returnHeadId, string carrier, string file)
        {
            Console.WriteLine($"Add {file} from {carrier} with id = {returnHeadId} into our godlike database!");
        }

        public static AddressDto AdressGet(long returnHeadId)
        {
            Console.WriteLine($"Get address information for {returnHeadId}.");

            return new AddressDto()
            {
                ReturnHeadId = returnHeadId,
                AccountNumber = "Acc007",
                CompanyName = "J.Bond LTD",
                Street = "Smally St.",
                City = "Aruba",
                Carrier = "DHL"
            };
        }

        public static LabelDto DhlLabelGet(AddressDto addressDto)
        {
            Console.WriteLine($"Get label file from {addressDto.Carrier} for {addressDto.CompanyName}.");

            return new LabelDto()
            {
                ReturnHeadId = addressDto.ReturnHeadId,
                Carrier = addressDto.Carrier,
                LabelFile = "BrutalFile.pdf"
            };
        }
    }
}
