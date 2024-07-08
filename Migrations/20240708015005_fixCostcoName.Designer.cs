﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTraceLib.Tables;

#nullable disable

namespace MyTraceTrawler.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240708015005_fixCostcoName")]
    partial class fixCostcoName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyTraceLib.Tables.Barcodes", b =>
                {
                    b.Property<string>("BarcodesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BarcodesId");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("MyTraceLib.Tables.ColesBrand", b =>
                {
                    b.Property<string>("ColesBrandId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColesBrandId");

                    b.ToTable("ColesBrands");
                });

            modelBuilder.Entity("MyTraceLib.Tables.ColesProduct", b =>
                {
                    b.Property<string>("ColesProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EANs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerPartNumbers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPCs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColesProductId");

                    b.ToTable("ColesProducts");
                });

            modelBuilder.Entity("MyTraceLib.Tables.CostcoBrand", b =>
                {
                    b.Property<string>("CostcoBrandId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InternalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostcoBrandId");

                    b.ToTable("CostcoBrands");
                });

            modelBuilder.Entity("MyTraceLib.Tables.CostcoProduct", b =>
                {
                    b.Property<string>("CostcoProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EANs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerPartNumbers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPCs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CostcoProductId");

                    b.ToTable("CostcoProducts");
                });

            modelBuilder.Entity("MyTraceLib.Tables.IngredientBreakdown", b =>
                {
                    b.Property<string>("IngredientBreakdownId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CarcinogenicProperties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommonUses")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnvironmentalImpact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HealthierAlternatives")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegulatoryStatusInAustralia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Toxicity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientBreakdownId");

                    b.ToTable("IngredientBreakdowns");
                });

            modelBuilder.Entity("MyTraceLib.Tables.VendorStockCode", b =>
                {
                    b.Property<string>("VendorStockCodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockCode")
                        .HasColumnType("int");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorStockCodeId");

                    b.ToTable("StockCodes");
                });

            modelBuilder.Entity("MyTraceLib.Tables.WoolworthsProduct", b =>
                {
                    b.Property<string>("WoolworthsProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllergenMayBePresent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AllergyStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOriginAltText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOriginDisclaimer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CountryOfOriginIngredientPercentage")
                        .HasColumnType("float");

                    b.Property<string>("CupMeasure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CupPrice")
                        .HasColumnType("float");

                    b.Property<string>("CupString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCupPrice")
                        .HasColumnType("bit");

                    b.Property<bool>("HasInStoreCupPrice")
                        .HasColumnType("bit");

                    b.Property<double>("HealthStarRating")
                        .HasColumnType("float");

                    b.Property<double>("InStoreCupPrice")
                        .HasColumnType("float");

                    b.Property<string>("InStoreCupString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InStorePrice")
                        .HasColumnType("float");

                    b.Property<double>("InStoreSavingsAmount")
                        .HasColumnType("float");

                    b.Property<double>("InStoreWasPrice")
                        .HasColumnType("float");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAddedVitaminsAndMinerals")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAgeRestricted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAntibacterial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAntioxidant")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAntiseptic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBPAFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContainGluten")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContainNuts")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEdrSpecial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsExcludedFromSubstitution")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForCollection")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForExpress")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreezable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGiftable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHalfPrice")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStoreAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStoreOnSpecial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInStorePurchaseable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMarketProduct")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMicrowaveSafe")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMicrowaveable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnSpecial")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnlineOnly")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOvenCook")
                        .HasColumnType("bit");

                    b.Property<bool>("IsParabenFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPmDelivery")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPurchaseable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRanged")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRestrictedByDeliveryMethod")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSponsoredAd")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSulfateFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTobacco")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUntraceable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("LargeImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LifestyleAndDietaryStatement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LifestyleClaim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediumImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NextAvailabilityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NutritionalInformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("RestrictionMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SapCategory")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("SapDepartment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("SapSegment")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("SapSubCategory")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<double>("SavingsAmount")
                        .HasColumnType("float");

                    b.Property<string>("SmallFormatDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallImageFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockCode")
                        .HasColumnType("int");

                    b.Property<string>("StorageInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuitableFor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TgaWarning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TgaWarningUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitWeightInGrams")
                        .HasColumnType("int");

                    b.Property<string>("Variety")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WarningMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("WasPrice")
                        .HasColumnType("float");

                    b.HasKey("WoolworthsProductId");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
