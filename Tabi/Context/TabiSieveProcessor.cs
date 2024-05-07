using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using Tabi.Model;

namespace Tabi.Context
{
    public class TabiSieveProcessor(IOptions<SieveOptions> options) : SieveProcessor(options)
    {
        // Ability for searching and sorting by UserID. Poor security measure.
        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Lot>(lot => lot.Farm!.UserID).CanFilter();
            mapper.Property<Crop>(crop => crop.Lot!.Farm!.UserID).CanFilter();
            mapper.Property<CropManagement>(cropManagement => cropManagement.Crop!.Lot!.Farm!.UserID).CanFilter();
            mapper.Property<Harvest>(harvest => harvest.Crop!.Lot!.Farm!.UserID).CanFilter();
            mapper.Property<HarvestPayment>(harvestPayment => harvestPayment.Harvest!.Crop!.Lot!.Farm!.UserID).CanFilter();

            return mapper;
        }
    }
}
